<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectArticleControl.ascx.cs"
    Inherits="UC.UI.Admin.Controls.SelectArticleControl" %>
<asp:DropDownList runat="server" ID="ddlArticles" AutoPostBack="False" DataTextField="Title" DataValueField="ID" AppendDataBoundItems="True">
    <asp:ListItem Text="" Value="0" />
</asp:DropDownList>
