<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="UC.UI.AccessDenied" MasterPageFile="~/Template.master" Culture="auto" UICulture="auto" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="Default.aspx">Климатическое оборудование</a>
                </td>
                <td><h1>Регистрация</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>
    <asp:Label runat="server" ID="lblLoginRequired">
    Для получения доступа к этой странице нужно зарегистрироваться. Если Вы уже регистрировались, воспользуйтесь
    <a href="Login.aspx">службой авторизации</a> нашего магазина. если не регистрировались, воспользуйтесь <a href="Register.aspx">службой регистрации</a>.
    </asp:Label>
    <asp:Label runat="server" ID="lblInsufficientPermissions">
    Извените, у Вас нет прав доступа к этой странице.
    </asp:Label>
    <asp:Label runat="server" ID="lblInvalidCredentials">
    Введенные Вами данные недействительны. Проверьте их и попробуйте снова. 
    Если Вы забыли пароль, <a href="PasswordRecovery.aspx">нажмите здесь</a>.
    </asp:Label>
    </p>
</div>
</asp:Content>

