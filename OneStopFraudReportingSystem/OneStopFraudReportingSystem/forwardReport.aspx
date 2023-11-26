<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="forwardReport.aspx.cs" Inherits="OneStopFraudReportingSystem.forwardReport" %>
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
                                <asp:Label ID="lblHandledBy" runat="server" Text="Handled By: "></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtHandledBy" runat="server"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblStatus" runat="server" Text="Status: "></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtStatus" runat="server"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblComment" runat="server" Text="Comment: "></asp:Label>
                                <div class="form-group">
                                    <asp:Label ID="txtComment" runat="server"></asp:Label>
                                </div>
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
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                </table>
                                </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            
            <hr />

            <div class="row">
                <div class="col-md-12">
                    <div class="form-group">
                        <asp:Label ID="lblForward" runat="server" Text="Forward To: " Font-Bold="true" Font-Size="15pt"></asp:Label>
                        <div class="form-group">
                            <asp:DropDownList CssClass="form-control" ID="ddlStaff" runat="server">

                            </asp:DropDownList>
                        </div>
                    </div>
                </div>    
            </div>

            <div class="row">
                <div class="col-8 mx-auto">
                    <center>
                        <div class="form-group">
                            <div class="col-md-6">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="btnForward" runat="server" Text="Forward" OnClick="btnForward_Click"/>
                            </div>
                            <div class="col-md-6">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false"/>
                            </div>
                        </div>
                    </center>
                </div>
            </div>

        </div>
    </section>
</asp:Content>