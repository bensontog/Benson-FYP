<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="announcement.aspx.cs" Inherits="OneStopFraudReportingSystem.announcement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 text-center">
                    <h1 class="alert-heading-section" style="font-size: 40pt;">Announcement</h1>
                    <h3><asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></h3>
                    <div style="padding-bottom: 20px;">
                        <p>
                            <asp:TextBox ID="txtSearch" style="border-radius: 25px; height: 30px; width: 270px;" placeholder="🔍🔍🔍Title....." runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" style="border-radius: 25px; height: 30px; width: 90px;" Text="Search" OnClick="btnSearch_Click"/>
                        </p>
                        <asp:Button ID="btnViewAll" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="View All" OnClick="btnViewAll_Click"/>
                        
                        <br />
                        <br />

                        <asp:Button ID="btnAdd" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="Add New Announcement" OnClick="btnAdd_Click" CausesValidation="false"/>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div>
                        <asp:Repeater ID="rptAnnouncement" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Announcement Title</th>
                                            <th>Announcement Date</th>
                                            <th>Announcement Details</th>
                                            <th>Department</th>
                                            <th>Posted By</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><asp:Label ID="lblAnnTitle" runat="server" Text='<%# Eval("ANN_TITLE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDate" runat="server" Text='<%# Eval("ANN_DATE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDetails" runat="server" Text='<%# Eval("ANN_Details") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DEPARTMENT") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPostedBy" runat="server" Text='<%# Eval("POSTED_BY") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPosition" runat="server" Text='<%# Eval("POSITION") %>'></asp:Label></td>
                                            <td><a href="announcementDetails.aspx?id=<%# Eval("ANN_ID")%>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptUpdateAnnouncement" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Announcement Title</th>
                                            <th>Announcement Date</th>
                                            <th>Announcement Details</th>
                                            <th>Department</th>
                                            <th>Posted By</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><asp:Label ID="lblAnnTitle" runat="server" Text='<%# Eval("ANN_TITLE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDate" runat="server" Text='<%# Eval("ANN_DATE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDetails" runat="server" Text='<%# Eval("ANN_Details") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DEPARTMENT") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPostedBy" runat="server" Text='<%# Eval("POSTED_BY") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPosition" runat="server" Text='<%# Eval("POSITION") %>'></asp:Label></td>
                                            <td><a href="announcementDetails.aspx?id=<%# Eval("ANN_ID")%>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptModifyAnnouncement" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Announcement Title</th>
                                            <th>Announcement Date</th>
                                            <th>Announcement Details</th>
                                            <th>Department</th>
                                            <th>Posted By</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><asp:Label ID="lblAnnTitle" runat="server" Text='<%# Eval("ANN_TITLE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDate" runat="server" Text='<%# Eval("ANN_DATE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAnnDetails" runat="server" Text='<%# Eval("ANN_Details") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DEPARTMENT") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPostedBy" runat="server" Text='<%# Eval("POSTED_BY") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblPosition" runat="server" Text='<%# Eval("POSITION") %>'></asp:Label></td>
                                            <td><a href="announcementDetails.aspx?id=<%# Eval("ANN_ID")%>" class="btn btn-primary">View</a></td>
                                            <td><a href="deleteAnnouncement.aspx?id=<%# Eval("ANN_ID")%>" class="btn btn-danger">Delete</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <center>
                        <asp:Button class="btn-primary btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                    </center>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
