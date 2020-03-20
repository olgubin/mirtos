<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UC.UI.Controls.AdminMenu"
    EnableViewState="false" %>
<div class="box">
    <div class="boxtitle">
        Администрирование</div>
    <div class="boxcontent departmentmenu">
        <div class="transparent">
        </div>
        <div class="menu" style="padding-left: 5px;">
            <table>
                <tr>
                    <th>
                        <b>Общие настройки</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink29" Text="Общие настройки" NavigateUrl="~/Admin/CommonSettings.aspx" />
                    </td>
                </tr>            
                <tr>
                    <th>
                        <b>Действия</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="lnkDepTitle" Text="Управление пользователями" NavigateUrl="~/Admin/ManageUsers.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Действия для редактирования</b>
                    </th>
                </tr>
<%--                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink2" Text="Управление форумом" NavigateUrl="~/Admin/ManageForums.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink3" Text="Управление опросами" NavigateUrl="~/Admin/ManagePolls.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Управление новостями</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" Text="Управление новостями" NavigateUrl="~/Admin/ManageNewsletters.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" Text="Добавление новости" NavigateUrl="~/Admin/AddEditNewsletter.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Управление каталогом и заказами</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink5" Text="Управление разделами" NavigateUrl="~/Admin/ManageDepartments.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink25" Text="Управление шаблонами разделов" NavigateUrl="~/Admin/ManageDepartmentTemplates.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink6" Text="Управление товарами" NavigateUrl="~/Admin/ManageProducts.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink2" Text="Рекомендуемые товары" NavigateUrl="~/Admin/ManageProductFeatured.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink19" Text="Каталог производителей" NavigateUrl="~/Admin/ManageManufacturers.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink28" Text="Типы товаров" NavigateUrl="~/Admin/ManageProductTypes.aspx" />
                    </td>
                </tr>                 
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink23" Text="Характеристики товаров" NavigateUrl="~/Admin/ManageProductAttributes.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink12" Text="Фильтры" NavigateUrl="~/Admin/ManageFilters.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink24" Text="Фильтрация товаров" NavigateUrl="~/Admin/ManageFilterCriteriaProduct.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink26" Text="Управление валютами" NavigateUrl="~/Admin/ManageCurrency.aspx" />
                    </td>
                </tr>                                 
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink7" Text="Управление заказами" NavigateUrl="~/Admin/ManageOrders.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink20" Text="Управление доставкой" NavigateUrl="~/Admin/ManageShippingMethods.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink21" Text="Управление статусами" NavigateUrl="~/Admin/ManageOrderStatuses.aspx" />
                    </td>
                </tr>
<%--                <tr>
                    <th>
                        <b>Действия для модератора</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink8" Text="Утверждение постов форума" NavigateUrl="~/Admin/ManageUnapprovedPosts.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        <b>Статьи</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink1" Text="Управление статьями" NavigateUrl="~/Admin/ManageArticles.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink15" Text="Управление темами" NavigateUrl="~/Admin/ManageCategories.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink17" Text="Управление комментариями" NavigateUrl="~/Admin/ManageComments.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink9" Text="Добавление статьи" NavigateUrl="~/Admin/AddEditArticle.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Галерея объектов</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink8" Text="Управление галереей объектов" NavigateUrl="~/Admin/ManagePortfolio.aspx" />
                    </td>
                </tr>
                <tr>                
                <tr>
                    <th>
                        <b>Поисковые запросы</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink10" Text="Анализ поисковых запросов" NavigateUrl="~/Admin/SearchRequests.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Статистика</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink11" Text="Статистика посещения магазина"
                            NavigateUrl="~/Admin/Statistics.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink13" Text="Хосты" NavigateUrl="~/Admin/StatisticsHosts.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink14" Text="Страницы" NavigateUrl="~/Admin/StatisticsPages.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink16" Text="Поисковики" NavigateUrl="~/Admin/StatisticsSearches.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink4" Text="Сайты" NavigateUrl="~/Admin/StatisticsSites.aspx" />
                    </td>
                </tr>
<%--                <tr>
                    <th>
                        <b>Парсинг каталогов</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink12" Text="Управление внешними каталогами"
                            NavigateUrl="~/Admin/ManageParsingCatalogs.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        <b>Файл sitemap.xml</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink18" Text="Сгенерировать файл" NavigateUrl="~/Admin/SiteMapFile.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Выгрузка в YandexMarket</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink27" Text="Сгенерировать файл" NavigateUrl="~/Admin/YandexMarketFile.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Администрирование БД</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink22" Text="Администрирование БД" NavigateUrl="~/Admin/ManageDatabase.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>Выход</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton runat="server" ID="lnkBtn" Text="Выход" OnClick="lnkBtn_Click">Выход</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
