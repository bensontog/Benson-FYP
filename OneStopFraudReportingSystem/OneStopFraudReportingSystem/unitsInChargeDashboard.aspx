<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="unitsInChargeDashboard.aspx.cs" Inherits="OneStopFraudReportingSystem.unitsInChargeDashboard" %>
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
        <h2><b>
            <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></b>
            <br />
            <br />
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome,"></asp:Label>
            
            <asp:Label ID="lblUPosition" runat="server"></asp:Label>
        </h2>
        
        <br />

        <hr />
        
        <h3>Announcement</h3>

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

        <h3>
            <asp:Label ID="lblTotalReport" runat="server" Text="Total Cases In-Charged By Department"></asp:Label>
        </h3>

        <br />

        <asp:GridView ID="gvCases" runat="server" AutoGenerateColumns="True" BorderWidth="1px" CellPadding="4" Width="100%" Height="200" EmptyDataText="No Record Found !" EmptyDataRowStyle-BackColor="White">
            <HeaderStyle BackColor="Yellow" ForeColor="Black" />
            <RowStyle BackColor="White" />
        </asp:GridView>

        <br />

        <asp:Label ID="lblTotal" runat="server" CssClass="css2"></asp:Label>
        
    </div>
</asp:Content>