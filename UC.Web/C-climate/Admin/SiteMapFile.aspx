<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="SiteMapFile.aspx.cs"
    Inherits="UC.UI.Admin.SiteMapFile" Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>Генерация файла sitemap.xml</h1>
                </td>
            </tr>
        </table>
    </div>    
    <div id="content">
            <p>
                <asp:Label runat="server" ID="lblResult" Font-Bold="true"/>
            </p>
    </div>
</asp:Content>
