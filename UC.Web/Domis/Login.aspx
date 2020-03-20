<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="UC.UI.Login"
    MasterPageFile="~/Template.master" Culture="auto" UICulture="auto" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Log" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <br />
        <table style="width: 100%">
            <tr>
                <td class="authorize">
                    Введите адрес электронной почты и пароль, указанные при регистрации.<br />
                    <br />
                    Если Вы забыли пароль, воспользуйтесь
                    <asp:HyperLink ID="lnkPasswordRecovery" runat="server" NavigateUrl="~/PasswordRecovery.aspx">службой напоминания паролей</asp:HyperLink>.
                </td>
                <td class="authorize" style="width: 200px">
                    <mb:Log runat="server" ID="Log" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
