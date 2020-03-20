<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Newsletter.aspx.cs" Inherits="UC.UI.ShowNewsletter" %>
<%@ Register Src="Controls/404.ascx" TagName="Control404" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Newsletters.aspx">Новости</a>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <mb:Control404 runat="server" ID="ctrl404" />
        <asp:Panel runat="server" ID="pnlContent">
            <br />
            <asp:Panel runat="server" ID="panEditNews" Width="100%" HorizontalAlign="Right">
                <asp:HyperLink runat="server" ID="lnkEditNews" ImageUrl="~/Images/Edit.gif" ToolTip="Редактировать новость"
                    NavigateUrl="~/Admin/AddEditNewsletter.aspx?ID={0}" />&nbsp;<asp:ImageButton runat="server"
                        ID="btnDelete" CausesValidation="false" AlternateText="Удалить новость" ImageUrl="~/Images/Delete.gif"
                        OnClientClick="if (confirm('Подтвердите удаление новости') == false) return false;"
                        OnClick="btnDelete_Click" /></asp:Panel>
            <asp:Label runat="server" ID="lblAddedDate" ForeColor="#9aaab1" Font-Size="Smaller" />
            <h2 style="font-size: small">
                <asp:Literal runat="server" ID="lblSubject" /></h2>
            <div style="padding: 0px 7px 17px 7px; text-align: justify">
                <%--<asp:Label runat="server" ID="lblAbstract" ForeColor="#777777" /><br />
            <br />--%>
                <asp:Literal runat="server" ID="lblHtmlBody" /></div>
        </asp:Panel>
    </div>
</asp:Content>
