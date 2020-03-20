<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Vacancy.aspx.cs" Inherits="UC.UI.Vacancy" %>
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
                        Вакансии</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>
            <b>ООО «Холод Сервис»</b> - поставки систем вентиляции и кондиционирования, отопительных 
            систем, проектно-сметные работы</p>
        <p>
            <b>Должность: </b>
        </p>
        <ul>
            <li>
                Инженер по продажам ОВК</li>
        </ul>
        <p>
            </p>
        <p>
            <b>Место работы:</b> 
        </p>
        <ul>
            <li>г. 
                Москва, ул. Промышленная, 11, стр. 8 (м. Кантемировская)</li>
        </ul>
        <p>
            </p>
        <p>
            <b>Должностные обязанности: </b>
        </p>
        <ul>
            <li>Активный поиск новых клиентов; </li>
            <li>Установление и поддержание партнерских взаимоотношений с клиентами, проведение переговоров, выявление их текущих и потенциальных потребностей;</li>
            <li>Технические консультации и подбор оборудования;</li>
            <li>Составление технико-коммерческих предложений, выставление счетов на оплату, заключение договоров;</li>
            <li>Выполнение плана продаж;</li>
            <li>Контроль и отслеживание дебиторской задолженности;</li>
            <li>Организация и проведение презентаций.</li>
        </ul>
        <p>
            </p>
        <p>
            <b>Требования:</b></p>
        <ul>
            <li>Высшее образование (желательно техническое);</li>
            <li>Возраст 23-35 лет;</li>
            <li>Опыт работы в области продаж систем кондиционирования и вентиляции от 3-х лет;</li>
            <li>Знание оборудования, работа в программах подбора;</li>
            <li>Знание рынка инженерного оборудования (климатическая техника);</li>
            <li>Навыки проведения презентаций;</li>
            <li>ПК – уверенный пользователь (1С 7.0);</li>
        </ul>
        <p></p>
        <p><b>Условия работы:</b></p>
        <ul>
            <li>Оклад  + % с продаж + премии;</li>
            <li>График работы: 5х2 с 9.00 до 18.00;</li>
            <li>Оформление по ТК РФ;</li>
            <li>Карьерный рост;</li>
        </ul>
        <br />
    </div>
</asp:Content>
