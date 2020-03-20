<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Dealer.aspx.cs" Inherits="UC.UI.Dealer" %>
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
                        Дилерам</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>
            Работая на рынке климатической техники, Вы можете расширить ассортимент групп товаров,
            по направлению ОВК став нашим партнером.</p>
        <p>
            Мы заинтересованы в продвижении качественного профессионального оборудования.</p>
        <p>
            На сегодняшний день сложился устойчивый спрос на качественное импортное оборудование,
            зарекомендовавшее себя надежностью, эффективностью действия и отличным внешним видом.</p>
        <p>
            Преимущества работы с нашей компанией:</p>
        <ul type="disc">
            <li>Размещение заказа и его прием в работу осуществляется в первоочередном порядке</li>
            <li>Осуществление поставок продукции по специальным, согласованным условиям и цене</li>
            <li>Большой ассортимент оборудования</li>
            <li><b>Технический отдел</b> (консультации по техническим вопросам, программы подбора)</li>
            <li><b>Монтажный отдел</b> (возможность проведения шеф-монтажа, пуско-наладочные работы,
                выезд инженера на объект)</li>
            <li><b>Отдел сервиса и послепродажного обслуживания</b> (заключение договоров по обеспечению
                сервисного обслуживания оборудования и установок) </li>
            <li><b>Проектный отдел</b> (подготовка технической документации; выполнение проектов
                по системам вентиляции, кондиционирования, отопления и водоснабжения; сметные работы)</li>
            <li>Доставка по России через транспортные компании, которые удобны Вам</li>
            <li>Оказание информационной поддержки (каталоги, буклеты, презентации, обучение)</li>
        </ul>
        <p><b>Ассортимент оборудования следующих производителей:</b></p>
        <div class="wizard">
            <table style="width:100%">
                <tbody>
                    <tr>
                        <th>Системы кондиционирования</th>
                        <th>Тепловое оборудование</th>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>Daikin</b></li>
                        <li><b>General Fujitsu</b></li>
                        <li><b>Toshiba</b></li>
                        <li><b>Sanyo</b></li>
                        <li><b>Mitsubishi Electric</b></li>
                        <li><b>General Climate</b></li>
                        <li><b>Panasonic</b></li>
                        <li><b>Hitachi</b></li>
                        <li><b>Haier</b></li>
                        <li><b>Kentatsu</b></li>
                        <li><b>LG</b></li>
                        <li><b>Midea</b></li>
                        <li><b>Lessar</b></li>
                    </ul>
                        </td>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>Тепломаш</b></li>
                        <li><b>Frico</b></li>
                        <li><b>Тропик</b></li>
                        <li><b>2VV</b></li>
                        <li><b>EuroHeat</b></li>
                        <li><b>Olefini/General</b></li>
                        <li><b>NED</b></li>
                        <li><b>Korf</b></li>
                        <li><b>Remak</b></li>
                        <li><b>Pyrox</b></li>
                        <li><b>Ensto</b></li>
                    </ul>
                        </td>
                    </tr>
                    <tr>
                        <th>Системы вентиляции</th>
                        <th>Отопление</th>
                    </tr>
                    <tr>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>NED</b></li>
                        <li><b>Вингс-М</b></li>
                        <li><b>Lindab</b></li>
                        <li><b>Systemair</b></li>
                    </ul>
                        </td>
                        <td style="vertical-align:top">
                    <ul style="list-style-type:none">
                        <li><b>Global</b></li>
                        <li><b>Purmo</b></li>
                        <li><b>Danfoss</b></li>
                        <li><b>Bugatti</b></li>
                        <li><b>RBM</b></li>
                    </ul>
                        </td>
                    </tr>
                </tbody>
            </table>        
        </div>
        <p>
        </p>
    </div>
</asp:Content>
