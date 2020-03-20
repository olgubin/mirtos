<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="YandexMarketFile.aspx.cs"
    Inherits="UC.UI.Admin.YandexMarketFile" Culture="auto" UICulture="auto" %>

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
                    <h1>Генерация файла yml для Яндекс Маркет</h1>
                </td>
            </tr>
        </table>
    </div>    
    <div id="content">
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:Label runat="server" ID="lblResult" EnableViewState="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button runat="server" Text="Создать yml файл" CssClass="adminButton" ID="btnGenerate" OnClick="btnGenerate_Click"></asp:Button>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
