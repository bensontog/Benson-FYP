<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="userDashboard.aspx.cs" Inherits="OneStopFraudReportingSystem.userDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .lbl1{
            padding-left: 43%;
            font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
        }

        .css2{
            padding-left: 74%;
            font-size:16px;
            font-family:Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
        }

        .css3{
            padding-right: 10%;
        }

    </style>

    <div class="container" align="center">
        <h2>
            <b><asp:Label ID="lblWelcome" runat="server" Text="Welcome,"></asp:Label>
            
            <asp:Label ID="lblUName" runat="server"></asp:Label></b>
        </h2>

        <br />

        <hr />

        <h3><asp:Label ID="lblAnnouncement" runat="server" Text="Announcement"></asp:Label></h3>

        <br />

        <asp:Repeater ID="rptAnnouncement" runat="server">
                        <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Announcement Title</th>
                                            <th>Announcement Date</th>
                                            <th>Announcement Details</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><asp:Label ID="lblAnnTitle" runat="server" Text='<%# Eval("ANN_TITLE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDate" runat="server" Text='<%# Eval("ANN_DATE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDetails" runat="server" Text='<%# Eval("ANN_Details") %>'></asp:Label></td>
                                            <td><a href="announcementDetails.aspx?id=<%# Eval("ANN_ID")%>" class="btn btn-primary">View Announcement Details</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                </table>
                                </FooterTemplate>
                    </asp:Repeater>

        <hr />

        <asp:Repeater ID="rptCasesReport" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Report ID</th>
                                            <th>Date</th>
                                            <th>Cases Category</th>
                                            <th>Victim ID</th>
                                            <th>Name</th>
                                            <th>Status</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("REPORT_ID")  %></td>
                                            <td><asp:Label ID="lblReportDate" runat="server" Text='<%# Eval("REPORT_DATETIME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblReportCategory" runat="server" Text='<%# Eval("REPORT_CATEGORY") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVictimID" runat="server" Text='<%# Eval("VICTIM_ID") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVictimName" runat="server" Text='<%# Eval("VICTIM_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblReportStatus" runat="server" Text='<%# Eval("REPORT_STATUS") %>'></asp:Label></td>
                                            <td><a href="reportDetails.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">View</a></td>
                                            <td><a href="addEvidence.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">Add Evidence</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h3><p>Total Cases Reported: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h3>
                                            <br />
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
    </div>
</asp:Content>
