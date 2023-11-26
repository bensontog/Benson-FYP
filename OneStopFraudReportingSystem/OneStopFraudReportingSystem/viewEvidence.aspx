<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="viewEvidence.aspx.cs" Inherits="OneStopFraudReportingSystem.viewEvidence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main1" runat="server">
    <style>
        .autp-style1{
            width: 800px;
        }
    </style>
    
    <table style="width:100%; background-color: #f2f2f2;">
        <tr>
            <td class="autostyle1" style="border-left: thin solid #C0C0C0;text-align:center">
                <asp:Image ID="imageEvidence" runat="server" CssClass="vimg" Height="800px" Width="550px"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" class="btn btn-primary" runat="server" Text="Back" OnClick="btnBack_Click"/>
            </td>
        </tr>
    </table>

</asp:Content>