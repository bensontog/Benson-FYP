<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="victimDetails.aspx.cs" Inherits="OneStopFraudReportingSystem.victimDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 text-center">
                    <h1 class="alert-heading-section" style="font-size: 40pt;">Victim Details</h1>

                    <div style="padding-bottom: 20px;">
                        <p>
                            <asp:TextBox ID="txtSearch" style="border-radius: 25px; height: 30px; width: 270px;" placeholder="🔍🔍🔍....." runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" style="border-radius: 25px; height: 30px; width: 90px;" Text="Search" OnClick="btnSearch_Click"/>
                        </p>
                        <asp:Button ID="btnViewAll" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="View All" OnClick="btnViewAll_Click"/>
                        
                        <br />
                        <br />

                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div>
                        <asp:Repeater ID="rptVictim" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Victim ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone No.</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("VICTIM_ID")  %></td>
                                            <td><asp:Label ID="lblVName" runat="server" Text='<%# Eval("VICTIM_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVGender" runat="server" Text='<%# Eval("VICTIM_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVEmail" runat="server" Text='<%# Eval("VICTIM_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVPhone" runat="server" Text='<%# Eval("VICTIM_PHONE") %>'></asp:Label></td>
                                            <td><a href="viewVictim.aspx?id=<%#Eval("VICTIM_ID") %>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptViewVictim" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Victim ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone No.</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("VICTIM_ID")  %></td>
                                            <td><asp:Label ID="lblVName" runat="server" Text='<%# Eval("VICTIM_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVGender" runat="server" Text='<%# Eval("VICTIM_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVEmail" runat="server" Text='<%# Eval("VICTIM_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblVPhone" runat="server" Text='<%# Eval("VICTIM_PHONE") %>'></asp:Label></td>
                                            <td><a href="viewVictim.aspx?id=<%#Eval("VICTIM_ID") %>" class="btn btn-primary">View</a></td>
                                            <td><a href="deleteVictim.aspx?id=<%#Eval("VICTIM_ID") %>" class="btn btn-danger">Delete</a></td>
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
                        <asp:Button class="btn-primary btn-lg" ID="btnBack" runat="server" Text="Back" Onclick="btnBack_Click"/>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>