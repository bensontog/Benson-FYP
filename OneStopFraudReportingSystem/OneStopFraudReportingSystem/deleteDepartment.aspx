<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="deleteDepartment.aspx.cs" Inherits="OneStopFraudReportingSystem.deleteDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .word{
            color:red;
        }

        .word1{
            font-family: 'Times New Roman', Times, serif;
            font-size: 18px;
        }
    </style>

    <div class="container">
        <div>
            <div class="row">
                <div class="col-md-7 mx-auto">
                    <div class="card-body" style="background-clip: border-box; border: 1px solid rgba(0,0,0,.125); border-radius: .25rem;">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/uic.png" width="135" height="135"/>
                                    <h4>Delete Department</h4>
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
                            <div class="col">
                                <asp:Label ID="lblDID" runat="server" Text="Department ID" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDID" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblDName" runat="server" Text="Department Name" Font-Bold="true"></asp:Label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtDName" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-danger btn-block btn-lg" ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>
                                        </div>
                                    </div>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>