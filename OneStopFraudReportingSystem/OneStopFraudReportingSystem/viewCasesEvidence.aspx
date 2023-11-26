<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="viewCasesEvidence.aspx.cs" Inherits="OneStopFraudReportingSystem.viewCasesEvidence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <div class="container" style="width: 1000px;">
        <article class="card" style="width:1000px;">
            <header class="card-header">
                <h1>Cases Report Details</h1>
            </header>
            <div class="card-body" style="padding: 50px;">
                <h3><b>Report ID: <asp:Label ID="lblReportID" runat="server" Text=""></asp:Label></b></h3>

                <article class="card" style="padding:30px;">
                    <div class="card-body">
                        <table>
                            <tr>
                                <td style="padding-right:30px;"><strong>Victim ID: </strong></td>
                                <td><asp:Label ID="lblVictimID" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="padding-right:30px;"><strong>Report Date: </strong></td>
                                <td><asp:Label ID="lblReportDate" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="padding-right:30px;"><strong>Report Category: </strong></td>
                                <td><asp:Label ID="lblReportCategory" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="padding-right:30px;"><strong>Report Details: </strong></td>
                                <td><asp:Label ID="lblReportDetails" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </article>
            </div>

            <hr />

            <div class="card-body">
                <div class="col">
                    <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Bold="true"></asp:Label>
                    <div class="form-group">
                        <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Under Investigation</asp:ListItem>
                            <asp:ListItem>Investigation Complete</asp:ListItem>                
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="lblComment" runat="server" Text="Comment" Font-Bold="true"></asp:Label>
                    <div class="form-group">
                        <asp:TextBox ID="txtComment" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                        <asp:Button ID="btnBack" class="btn btn-primary" runat="server" Text="Back" OnClick="btnBack_Click" CausesValidation="false"/>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row">
                <div class="col-md-12">
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
                                            <td><img src='<%# Eval("EVIDENCE") %>'' width="75" height="75" class="img-sm border"/></td>
                                            <td><a href="viewEvidence.aspx?id=<%# Eval("EVIDENCE_ID")%>" class="btn btn-primary">View Evidence</a></td>
                                        </ItemTemplate><FooterTemplate>
                                    </tbody>
                                    <h2><p>Total Record: <%#Convert.ToString(((System.Data.DataTable)((Repeater)Container.Parent).DataSource).Rows.Count) %></p></h2>
                                </table>
                                </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

        </article>
    </div>
</asp:Content>