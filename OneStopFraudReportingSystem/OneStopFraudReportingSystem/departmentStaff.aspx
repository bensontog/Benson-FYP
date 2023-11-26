<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="departmentStaff.aspx.cs" Inherits="OneStopFraudReportingSystem.departmentStaff" %>
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
                            <asp:Button ID="btnSearch" runat="server" style="border-radius: 25px; height: 30px; width: 90px;" Text="Search" OnClick="btnSearch_Click"/>
                        </p>
                        <asp:Button ID="btnViewAll" runat="server" style="border-radius: 25px; height: 30px; width: 270px;" Text="View All" OnClick="btnViewAll_Click"/>
                        
                        <br />
                        <br />

                        <asp:Button ID="btnAdd" runat="server" style="border-radius: 25px; height:30px; width: 270px" Text="Staff Registration" OnClick="btnAdd_Click"/>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div>
                        <asp:Repeater ID="rptDepartmentStaff" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Staff ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("UICS_ID")  %></td>
                                            <td><asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("UICS_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffGender" runat="server" Text='<%# Eval("UICS_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffEmail" runat="server" Text='<%# Eval("UICS_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffPhone" runat="server" Text='<%# Eval("UICS_PHONE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffPosition" runat="server" Text='<%# Eval("UICS_POSITION") %>'></asp:Label></td>
                                            <td><a href="promoteStaff.aspx?uid=<%# Eval("UICS_ID")%>" class="btn btn-primary">View</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptViewStaff" runat="server">
                            <HeaderTemplate>
                                <table class="table table-striped" style="border: 0.5px #212529 solid;">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>Staff ID</th>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Phone</th>
                                            <th>Position</th>
                                        </tr>
                                    </thead></HeaderTemplate><ItemTemplate>
                                    <tbody>
                                        
                                            <td>
                                                <%# Container.ItemIndex + 1 %>
                                            </td>
                                            <td><%# Eval("UICS_ID")  %></td>
                                            <td><asp:Label ID="lblStaffName" runat="server" Text='<%# Eval("UICS_NAME") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffGender" runat="server" Text='<%# Eval("UICS_GENDER") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffEmail" runat="server" Text='<%# Eval("UICS_EMAIL") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffPhone" runat="server" Text='<%# Eval("UICS_PHONE") %>'></asp:Label></td>
                                            <td><asp:Label ID="lblStaffPosition" runat="server" Text='<%# Eval("UICS_POSITION") %>'></asp:Label></td>
                                            <td><a href="promoteStaff.aspx?uid=<%# Eval("UICS_ID")%>" class="btn btn-primary">Promote</a></td>
                                            <td><a href="deleteStaff.aspx?uid=<%# Eval("UICS_ID")%>" class="btn btn-danger">Delete</a></td>
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