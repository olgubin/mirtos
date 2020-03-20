<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payments.aspx.cs" Inherits="UC.UI.Payments" MasterPageFile="~/Template.master" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>--%>
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
                    <h1>
                        Оплата</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <h3>
            Наличный:</h3>
        <ul>
            <p>
                Заказ оплачивается в момент получения товара. Оплата производится только в рублях.
               <b>Данный вид оплаты доступен только для Москвы и Mосковской
            области</b>.
        </ul>
        <h3>
            Безналичный:</h3>
        <ul>
            <b>Оплата квитанции через Банк (для физических лиц)</b>
            <br>
            <br>
            <p>
                После оформления заказа Вы получите уведомление о приеме заказа на рассмотрение
                на указанный Вами при регистрации электронный адрес. После подтверждения наличия
                товар по вашему заказу ставится в резерв.
                <p>
                    Вам выставляется счет на оплату который отправляется Вам по электронной почте или факсу, указанным в форме заказа. 
                    <p>
                        Внимание! Выставленная квитанция действительна в течении 3-х банковских дней.
                        <p>
                            Оплачивать можно в любом банке, принимающем платежи от частных лиц. При переводе
                            средств банк взимает комиссию. Пожалуйста, заранее поинтересуйтесь величиной комиссии
                            в вашем банке.
                            <p>
                                После внесения оплаты, просьба выслать копию квитанции на почту <a href="mailto:zakaz@aironic.ru">zakaz@aironic.ru</a> или по факсу.
                                <p><hr style="width:100%;size:1px;color:#d7c5ab" noshade=""/></p>
                                <b>Оплата по безналичному расчету (для юридических лиц)</b>
                                <br>
                                <br>
                                <p>
                                    После оформления заказа Вы получаете уведомление о приеме заказа на рассмотрение
                                    на указанный Вами при регистрации электронный адрес. После подтверждения наличия
                                    товар по вашему заказу ставится в резерв.
                                    <p>
                                        При оплате от Юридического лица, Вам необходимо, при оформлении заказа выбрать способо оплаты "Безналичный расчет".
                                        <p>
                                            Вам выставляется счет, который будет передан по электронной почте или по факсу.
                                            <p>
                                                Внимание! Выставленный счет действителен в течении 3-х банковских дней.
                                                <p>
        После внесения оплаты, просьба выслать копию Платежного поручения на почту <a href="mailto:zakaz@aironic.ru">zakaz@aironic.ru</a> или по факсу.
    </div>
</asp:Content>
