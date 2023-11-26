<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="adminDetails.aspx.cs" Inherits="OneStopFraudReportingSystem.adminDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6 text-center">
                    <h1 class="alert-heading-section" style="font-size: 40pt;">Admin Details</h1>

                    <div style="padding-bottom: 20px;">
                        <p>
                            <asp:TextBox ID="txtSearch" style="border-radius: 25px; height: 30px; width: 270px;" placeholder="🔍🔍🔍....." runat="server"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" style="border-radius: 25px; height: 30px; width: 90px;" Text="Search" OnClick="btnSearch_Click"/>
                        </p>
                        <asp:Button ID="btnViewAll" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="View All" OnClick="btnViewAll_Click"/>
                        
                        <br />
                        <br />

                        <asp:Button ID="btnAdd" runat="server" style="border-radius: 25px; height:30px; width: 270px" Text="Admin Registration" OnClick="btnAdd_Click"/>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div>
                        <asp:Repeater ID="rptAdmin" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Admin ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone No.</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("ADM_ID")  %></td>
                                            <td><asp:Label ID="lblAName" runat="server" Text='<%# Eval("ADM_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAGender" runat="server" Text='<%# Eval("ADM_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAEmail" runat="server" Text='<%# Eval("ADM_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAPhone" runat="server" Text='<%# Eval("ADM_PHONE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAPosition" runat="server" Text='<%# Eval("ADM_POSITION") %>'></asp:Label></td>
                                            <td><a href="promoteAdmin.aspx?aid=<%#Eval("ADM_ID") %>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptViewAdmin" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Admin ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone No.</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("ADM_ID")  %></td>
                                            <td><asp:Label ID="lblAName" runat="server" Text='<%# Eval("ADM_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAGender" runat="server" Text='<%# Eval("ADM_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAEmail" runat="server" Text='<%# Eval("ADM_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAPhone" runat="server" Text='<%# Eval("ADM_PHONE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblAPosition" runat="server" Text='<%# Eval("ADM_POSITION") %>'></asp:Label></td>
                                            <td><a href="promoteAdmin.aspx?aid=<%#Eval("ADM_ID") %>" class="btn btn-primary">View</a></td>
                                            <td><a href="deleteAdmin.aspx?aid=<%#Eval("ADM_ID") %>" class="btn btn-danger">Delete</a></td>
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