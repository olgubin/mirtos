<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="EditProfile.aspx.cs" Inherits="UC.UI.EditProfile" Culture="auto"
    UICulture="auto" %>
<%@ Register Src="Controls/UserProfile.ascx" TagName="UserProfile" TagPrefix="mb" %>
<%@ Register Src="Controls/ChangePassword.ascx" TagName="ChangePassword" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Мебель для ванной</asp:HyperLink></td>
                <td><h1><asp:Label runat="server" ID="lblTitle" Text="Мои данные" /></h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>Личные данные используются для авторизации в нашем магазине, а также при обращении к Вам на страницах магазина и по электронной почте. В этом разделе Вы можите изменить личные данные указанные при регистрации. Поля, отмеченные <span style="color:Red">*</span>, обязательны для заполнения.</p>
        <table width="100%">
            <tr>
                <td style="width: 50%;">
                     <mb:UserProfile ID="UserProfile1" runat="server" From="info@domis.ru" FromCaption="DOMIS.RU Мебель для ванной" BodyFileName="~/ChangeProfileMail.txt" Subject="Изменение регистрационных данных"/>
                </td>
                <td style="width: 50%">
                    <table width="100%">
                        <tr style="background-color: #fef7f8">
                            <td class="fieldcaption">
                                Смена пароля
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <mb:ChangePassword runat="server" From="info@domis.ru" FromCaption="DOMIS.RU Мебель для ванной" BodyFileName="~/ChangePasswordMail.txt" Subject="Изменение пароля"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>        
    </div>
</asp:Content>
