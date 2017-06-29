<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Acme.Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    <table style="width= 100%">
        <tr>
            <td>
                Customer ID: 
            </td>
            <td>
                <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validID" runat="server" ControlToValidate="txtCustID" ErrorMessage=" Customer ID Required!">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Integer" MinimumValue="1" MaximumValue="1000" ControlToValidate="txtCustID" ErrorMessage="ID Must Be Integer and within 1 to 1000!">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                First Name: 
            </td>
            <td>
                <asp:TextBox ID="txtFName" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFName" ErrorMessage="First Name Cannot Be Empty!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Surname: 
            </td>
            <td>
                <asp:TextBox ID="txtSName" runat="server" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSName" ErrorMessage="Surname Cannot Be Empty!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Gender: 
            </td>
            <td>
                <asp:RadioButtonList ID="rdlGender" runat="server">
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdlGender" ErrorMessage="Gender Cannot Be Empty!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Age: 
            </td>
            <td>
                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAge" ErrorMessage="Age Cannot Be Empty!">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" Type="Integer" ErrorMessage="Age Must Be from 16 to 120!" ControlToValidate="txtAge" MinimumValue="16" MaximumValue="120">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address1: 
            </td>
            <td>
                <asp:TextBox ID="txtAdd1" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdd1" ErrorMessage="Address Cannot Be Empty!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address2: 
            </td>
            <td>
                <asp:TextBox ID="txtAdd2" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                City: 
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity" ErrorMessage="City Cannot Be Empty!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Phone Number: 
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Cannot Be Empty!">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPhone" ErrorMessage="Not A Valid Australian Phone Number!" ValidationExpression="^\({0,1}((0|\+61)(2|4|3|7|8)){0,1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3}$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Mobile Number: 
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Not A Valid Australian Mobile Number!" ControlToValidate="txtMobile" ValidationExpression="^\({0,1}((0|\+61)(2|4|3|7|8)){0,1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3}$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Email: 
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validEmail" runat="server" ErrorMessage="Email Cannot Be Empty!" ControlToValidate="txtEmail">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="Not A Valid Email Address!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Confirm Email: 
            </td>
            <td>
                <asp:TextBox ID="txtConEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConEmail" ErrorMessage="Confirm Email Cannot Be Empty!">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="compEmail" runat="server" ErrorMessage="Emails Do Not Match!" ControlToValidate ="txtEmail" ControlToCompare="txtConEmail">*</asp:CompareValidator>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CausesValidation="False" />
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" CausesValidation="False" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CausesValidation="False" /><br /><br />
    <asp:ValidationSummary ID="errorSum" runat="server" HeaderText="You Received Following Error: " />
</asp:Content>
