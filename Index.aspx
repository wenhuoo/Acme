<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Acme.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>Home Page</h1>
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br /><br />
    <asp:DropDownList ID="ddlSetTheme" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSetTheme_SelectedIndexChanged">
        <asp:ListItem>Blue</asp:ListItem>
        <asp:ListItem>Gray</asp:ListItem>
        <asp:ListItem>Purple</asp:ListItem>
    </asp:DropDownList>
    <p>Welcome to my companys home page. Our company headquarters is shown below.</p>
    <p><img alt="" class="style3" src="Images/HeadQuarters.jpg" /></p>
</asp:Content>