<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="Acme.Queries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Enter SQL Queries: <asp:TextBox ID="txtSQL" runat="server" Width="250px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSQL" ErrorMessage="Required!"></asp:RequiredFieldValidator><br />
    <asp:Button ID="btnRun" runat="server" Text="Run" OnClick="btnRun_Click" /><br /><br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br /><br />

    <asp:GridView ID="gvResult" runat="server"></asp:GridView>
</asp:Content>
