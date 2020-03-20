<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="UC.UI.About" %>

<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
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
                        О компании</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p />
        <p>
            Компания ООО «Холод Сервис» специализируется на проектировании, монтаже и поставке
            оборудования для систем вентиляции и кондиционирования.
        </p>
        <p>
            Наша компания является официальным поставщиком систем вентиляции, кондиционирования
            и теплового оборудования по всей России.
        </p>
        <p>
            Торговые марки, с которыми мы работаем, получили признание покупателей из-за оптимального
            соотношению «цена/качество».
        </p>
        <p>
            Это известные во всём мире производители систем кондиционирования:
        </p>
        <p>
            <b>Daikin, Panasonic, LG, Toshiba, Sanyo, Hitachi, Haier, Mitsubishi, Kentatsu, Fujitsu,
                General</b>
        </p>
        <p>
            Системы вентиляции:
        </p>
        <p>
            <b>Systemair, Lindab, ОВИК, Вингс-М</b>
        </p>
        <p>
            Тепловые завесы:
        </p>
        <p>
            <b>ЕuroHeat, 2VV, Frico, Ned, Remak, Olefini/General</b>
        </p>
        <p>
            Инженеры «Холод Сервис» всегда проконсультируют Вас и ответят на все вопросы по техническим
            характеристикам оборудования. Благодаря богатому выбору товара, наши специалисты
            предложат Вам несколько вариантов оборудования, подходящего для Вашего случая.
        </p>
        <p>
            Всё оборудование сертифицировано и обеспечивается гарантийным обслуживанием.
        </p>
        <p>
            Мы надеемся видеть Вас нашим клиентом и партнёром.
        </p>
        <p>
            <strong><a name="quest4"></a>Реквизиты компании</strong></p>
        <p>
            <div class="wizard">
                <table cellpadding="5px">
                    <tr>
                        <td>
                            <b>Наименование организации</b>
                        </td>
                        <td>
                            Холод Сервис, ООО
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Юридический адрес</b>
                        </td>
                        <td>
                            115230,г.Москва, проезд Хлебозаводский, 7
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>ОГРН</b>
                        </td>
                        <td>
                            1167746553754
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>ИНН/КПП</b>
                        </td>
                        <td>
                            7724368592/7772401001
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Телефон</b>
                        </td>
                        <td>
                            +7 (495) 005-53-95, +7 (499) 394-04-09
                        </td>
                    </tr>
                </table>
            </div>
            <p />
    </div>
</asp:Content>
