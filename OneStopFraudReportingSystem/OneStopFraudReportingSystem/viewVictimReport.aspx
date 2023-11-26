<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="viewVictimReport.aspx.cs" Inherits="OneStopFraudReportingSystem.viewVictimReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 text-center">
                    <h1 class="alert-heading-section" style="font-size: 25pt;"><asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label></h1>

                    <div style="padding-bottom: 20px;">
                        <p>
                            <asp:TextBox ID="txtSearch" style="border-radius: 25px; height: 30px; width: 270px;" placeholder="🔍🔍🔍....." runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" style="border-radius: 25px; height: 30px; width: 90px;" Text="Search" />
                        </p>
                        <asp:Button ID="btnViewAll" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="View All" />

                        <br />
                        <br />

                        <p>
                            <asp:Label ID="lblUID" runat="server" Text="Staff ID: " Font-Bold="true"></asp:Label>
                            &nbsp;
                            <asp:Label ID="txtUID" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblUName" runat="server" Text="Name: " Font-Bold="true"></asp:Label>
                            &nbsp;
                            <asp:Label ID="txtUName" runat="server"></asp:Label>
                        </p>
                           
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div>
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
                                            <th>Handled By</th>
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
                                            <td><asp:Label ID="lblHandledBy" runat="server" Text='<%# Eval("HANDLED_BY") %>'></asp:Label></td>
                                            <td><a href="reportDetails.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">View</a></td>
                                            <td><a href="forwardReport.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">Forward</a></td>
                                            <td><a href="updateReportStatus.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">Update</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptCasesInCharge" runat="server">
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
                                            <th>Handled By</th>
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
                                            <td><asp:Label ID="lblHandledBy" runat="server" Text='<%# Eval("HANDLED_BY") %>'></asp:Label></td>
                                            <td><a href="reportDetails.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">View</a></td>
                                            <td><a href="forwardReport.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">Forward</a></td>
                                            <td><a href="updateReportStatus.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">Update</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptAdminView" runat="server">
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
                                            <th>Handled By</th>
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
                                            <td><asp:Label ID="lblHandledBy" runat="server" Text='<%# Eval("HANDLED_BY") %>'></asp:Label></td>
                                            <td><a href="reportDetails.aspx?id=<%# Eval("REPORT_ID")%>" class="btn btn-primary">View</a></td>
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