<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageDatabase.aspx.cs"
    Inherits="UC.UI.Admin.ManageDatabase" Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Климатическое оборудование</a>
                </td>
                <td class="s">
                    |</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Администрирование БД</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
            <p>
                Количество анонимных пользователей: <asp:Label runat="server" ID="lblAnonymousUsersCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteAnonymousUsers" CommandName="DeleteAnonymousUsers" OnCommand="ManageDatabase_Command">Удалить анонимных пользователей</asp:LinkButton>
            </p>
            <p>
                Количество профилей анонимных пользователей: <asp:Label runat="server" ID="lblInnactiveProfileCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteInnactiveProfiles" CommandName="DeleteInnactiveProfiles" OnCommand="ManageDatabase_Command">Удалить профили анонимных пользователей</asp:LinkButton>
            </p>            
            <p>
                Количество событий: <asp:Label runat="server" ID="lblWebEventsCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteWebEvents" CommandName="DeleteWebEvents" OnCommand="ManageDatabase_Command">Удалить события</asp:LinkButton>
            </p>              
    </div>
</asp:Content>
