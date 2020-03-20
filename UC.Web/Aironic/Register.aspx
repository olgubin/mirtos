<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="UC.UI.Register" Culture="auto" UICulture="auto" %>

<%@ Register Src="Controls/Register.ascx" TagName="Register" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">Главная</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>Регистрация</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <br />
        <p>
            Заполните пожалуйста регистрационную форму. Указанные e-mail и пароль используйте,
            в дальнейшем, для авторизации в нашем магазине. Поля, отмеченные <span style="color: Red">
                *</span>, обязательны для заполнения.</p>
        <asp:Panel runat="server" DefaultButton="btnEnter">
            <mb:Register runat="server" ID="Reg" BodyFileName="~/RegistrationMail.txt" From="info@aironic.ru"
                FromCaption="AIRONIC.RU тепловое оборудование" Subject="Регистрационные данные" />
            <br />
            <asp:Button ID="btnEnter" runat="server" ValidationGroup="Register" CssClass="enter"
                Text="Зарегистрироваться" OnClick="btnEnter_Click" Width="177px" /></asp:Panel>
    </div>
</asp:Content>
