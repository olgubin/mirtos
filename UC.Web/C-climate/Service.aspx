<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Service.aspx.cs" Inherits="UC.UI.Service" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
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
                        Сервис</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <p>
            Сервисная служба компании «Холод Сервис» осуществляет все виды сервисного обслуживания
            систем кондиционирования, вентиляции, климатического и теплового оборудования.
        </p>
        <p>
            Специалисты технического отдела и сервисной службы компании имеют квалификационные
            аттестаты учебных центров ведущих производителей систем кондиционирования и вентиляции,
            это: <b>Daikin, Toshiba, Carrier, Samsung, Panasonic, Systemair</b>.
        </p>
        <p>
            Мы применяем расходные части и материалы импортного производства высокого качества.
        </p>
        <p>
            Стоимость профилактических и сервисных работ по обслуживанию систем кондиционирования
            и вентиляции определяется после выезда инженера на объект Заказчика.
        </p>
        <p>
            Выезд инженера сервисной службы для проведения диагностики оборудования, а также
            определения стоимости ремонтных работ осуществляется - платно.
        </p>
        <p>
            <b>На все выполненные работы мы предоставляем гарантию 1 год.</b>
        </p>
        <p />
    </div>
</asp:Content>
