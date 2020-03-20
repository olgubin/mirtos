<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shipping.aspx.cs" Inherits="UC.UI.Shipping" MasterPageFile="~/Template.master" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server"/>
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
                        Доставка</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <p>
            Стоимость доставки автотранспортом по Москве от <b>500 руб</b>.
        </p>
        <p>
            Доставка автотранспортом осуществляется в течение 3-х рабочих дней.
        </p>
        <p>
            Доставка товара, приобретенного с монтажом, осуществляется бесплатно.
        </p>
        <p>
            Также осуществляется отправка любого оборудования во все регионы РФ, посредством
            привлечения транспортных компаний (авто, ж/д, авиа), предоставляющих данные услуги.
        </p>
        <p />
    </div>
</asp:Content>
