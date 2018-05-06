<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <form id="form1">
        <div >
            <br />
            &nbsp;<asp:Label ID="Label3" runat="server" Text="Name: "></asp:Label>
            <asp:TextBox ID="Name" runat="server" Width="210px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Address:"></asp:Label>
            &nbsp;<asp:TextBox ID="Address" runat="server" Width="210px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Telephone:"></asp:Label>
            <asp:TextBox ID="Telephone" runat="server" Width="210px"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RecordData" runat="server" Text="Record Data" OnClick="RecordData_ClickAsync"  />
            <br />
            <br />
            <asp:TextBox ID="HttpMessageTextBox" runat="server" Rows="10" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
    </form>

</asp:Content>
