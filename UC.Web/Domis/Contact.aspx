<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="UC.UI.Contact" %>

<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/ContactForm.ascx" TagName="ContactForm" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <div style="padding-top: 10px;">
            <table>
                <tr>
                    <td>
                        <p>
                            <h3>
                                Офис компании</h3>
                            <div class="wizard">
                                <table cellpadding="5px">
                                    <tr>
                                        <td style="width:210px">
                                            <b>Адрес:</b>
                                        </td>
                                        <td style="width:330px">
                                            115516 г. Москва, ул. Домодедовская, дом 42
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Тел:</b>
                                        </td>
                                        <td>
                                            (495) 514-86-37, (916) 124-98-36
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Факс:</b>
                                        </td>
                                        <td>
                                            (495) 234-05-34
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>E-mail:</b>
                                        </td>
                                        <td>
                                            <a href="mailto:info@domis.ru">info@domis.ru</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <h3>
                                Реквизиты компании</h3>
                            <div class="wizard">
                                <table cellpadding="5px">
                                    <tr>
                                        <td style="width:210px">
                                            <b>Наименование организации</b>
                                        </td>
                                        <td style="width:330px">
                                            Вэлтон, ООО
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Юридический адрес</b>
                                        </td>
                                        <td>
                                            127018, г. Москва, ул Сущевский вал, д. 5, стр. 20
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>ИНН</b>
                                        </td>
                                        <td>
                                            7720602940
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>КПП</b>
                                        </td>
                                        <td>
                                            771501001
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>ОГРН</b>
                                        </td>
                                        <td>
                                            1077764062991
                                        </td>
                                    </tr>
                                    <%--                    <tr>
                        <td>
                            <b>Телефон</b>
                        </td>
                        <td>
                            +7 (495) 7307818
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <b>Факс</b>
                        </td>
                        <td>
                            +7 (495) 2340534
                        </td>
                    </tr>--%>
                                </table>
                            </div>
                            <h3>
                                Время работы магазина</h3>
                            <div class="wizard">
                                <table cellpadding="5px">
                                    <tr>
                                        <td style="width:210px">
                                            <b>Понедельник - Пятница</b>
                                        </td>
                                        <td style="width:330px">
                                            с 9:00 до 20:00
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <b>Суббота - Воскресенье</b>
                                        </td>
                                        <td>
                                            с 10:00 до 19:00
                                        </td>
                                    </tr>
                                </table>
                            </div>                            
                        </p>
                        <p>
                            <h3>
                                Форма обратной связи</h3>
                        </p>
                        <mb:ContactForm ID="ContactForm1" runat="server" Title="Хотите задать вопрос? Оставить свой отзыв? Получить консультацию? Заполните эту форму. Мы обязательно свяжемся с вами." />
                    </td>
                    <%--                    <td style="width: 200px; text-align: center">
                        <div style="padding: 17px">
                            <div style="padding: 7px">
                                <a href="#ref0">
                                    <img src="App_Themes/CClimate/images/by_foot.png" /></a>
                            </div>
                            <a href="#ref0">Как добраться пешком</a>
                            <div style="padding: 7px">
                                <a href="#ref1">
                                    <img src="App_Themes/CClimate/images/by_bus.png" /></a>
                            </div>
                            <a href="#ref1">Как добраться на общественном транспорте</a>
                            <div style="padding: 7px">
                                <a href="#ref2">
                                    <img src="App_Themes/CClimate/images/by_car.png" /></a>
                            </div>
                            <a href="#ref2">Как добраться на машине</a>
                        </div>
                    </td>--%>
                </tr>
            </table>
            <%--            <p>
                <h3>
                    Схемы проезда:</h3>
            </p>
            <p>
                <a name="ref0"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_foot_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                Если Вы идете пешком, то:</h1>
                        </td>
                    </tr>
                </table>
                от станции метро Кантемировская – первый вагон из центра, выход по подземному переходу
                прямо, далее поворот направо и по лестнице вверх на улицу. С левой стороны перед
                Вами будет магазин «Мебель» с правой – магазин «Продукты». Между ними по асфальтированной
                дорожке идете прямо до улицы Бехтерева, до перекрестка со светофором. Примыкающая
                на перекрестке к Бехтерева будет улица Промышленная. Далее идете по улице Промышленная
                до первых въездных ворот слева, рядом будет автобусная остановка. В качестве ориентира,
                на территории находится труба из красного кирпича. При входе на территорию службе
                охраны сказать, что Вы в компанию Сити-Климат.
                <p>
                    <b>Время в пути – 15 минут.</b></p>
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_foot_map.gif" />
                </div>
            </p>
            <p>
                <a name="ref1"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_bus_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                Если Вы едете общественным транспортом, то:</h1>
                        </td>
                    </tr>
                </table>
                от станции метро Кантемировская – первый вагон из центра, выход по подземному переходу
                прямо, далее поворот направо и по лестнице вверх на улицу. Далее идете в сторону
                автобусной остановки - автобус № 150, маршрутка № 150. Едете до остановки «Улица
                Промышленная», это 8-я остановка от метро. Слева будут въездные ворота. В качестве
                ориентира, на территории находится труба из красного кирпича. При входе на территорию
                службе охраны сказать, что Вы в компанию Сити-Климат.
                <p>
                    <b>Время в пути – 10-15 минут.</b></p>
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_bus_map.gif" />
                </div>
            </p>
            <p>
                <a name="ref2"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_car_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                Если Вы едете на машине, то:</h1>
                        </td>
                    </tr>
                </table>
                с Каширского шоссе поворачиваете на Пролетарский проспект (стрелка на светофоре
                как при движении из Центра, так и в сторону Центра), далее до улицы Кантемировская
                на светофоре стрелка направо, далее едете до первого светофора со стрелкой, поворачиваете
                налево (ул.Бехтерева). Едете до следующего светофора – поворачиваете направо на
                улицу Промышленная. Далее двигаетесь прямо, до первых въездных ворот слева, рядом
                будет автобусная остановка. В качестве ориентира, на территории находится труба
                из красного кирпича. При входе на территорию службе охраны сказать, что Вы в компанию
                Сити-Климат.
                <p />
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_car_map.gif" />
                </div>
            </p>--%>
        </div>
</asp:Content>
