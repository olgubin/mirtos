<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageArticles.aspx.cs" Inherits="UC.UI.Admin.ManageArticles"%>
<%@ Register Src="../Controls/ArticleListing.ascx" TagName="ArticleListing" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Управление статьями</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
   <br/>
   <mb:ArticleListing id="ArticleListing1" runat="server" PublishedOnly="False" />
   </div>
</asp:Content>

