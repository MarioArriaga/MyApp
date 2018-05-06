<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="MyApp.WebUserControl1" %>
Name:<br /><asp:TextBox ID="Name" runat="server"></asp:TextBox>
<br />
<br />
Address:<br /><asp:TextBox ID="Address" runat="server"></asp:TextBox>
<br />
<br />
Telephone:<br /><asp:TextBox ID="Telephone" runat="server"></asp:TextBox>
<br />
<p>
    <asp:Button ID="RecordData" runat="server" Text="Button" OnClick="RecordData_Click" />
</p>

