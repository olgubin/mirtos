<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageUploader.ascx.cs" Inherits="UC.UI.Admin.Controls.ImageUploader" %>
        <table style="width: 100%">
            <tr>
                <td style="height:27px;vertical-align:middle;">Ссылка на загруженный рисунок:</td>
                <td colspan="2" style="height:27px;vertical-align:middle">
                    <asp:Literal runat="server" ID="lblImgUrl" />
                </td>
            </tr>           
            <tr>
                <td style="width: 230px; vertical-align: middle;">
                    Загрузить изображение по ссылке:</td>
                <td>
                    <asp:TextBox ID="txtImageUrl" Width="97%" runat="server" MaxLength="256"></asp:TextBox></td>
                <td>
                <asp:Button runat="server" ID="brnUrlUpload" Text="Загрузить" OnClick="btnUrlUpload_Click" CausesValidation="false"/>
                </td>
            </tr>
            <tr>
                <td style="width: 230px; vertical-align: middle;">
                    Загрузить изображение из файла:</td>
                <td>
                    <asp:FileUpload ID="imgUpload" runat="server" Width="100%" EnableViewState="false"/>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnFileUpload" Text="Загрузить" OnClick="btnFileUpload_Click" CausesValidation="false"/>
                </td>
            </tr>
        </table> 