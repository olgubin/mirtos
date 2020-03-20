<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="Admin.master"
    Inherits="UC.UI.Admin._Default" Culture="auto" UICulture="auto" EnableViewState="false"%>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Главная</asp:HyperLink></td>
                <td>
                    <asp:Image runat="server" SkinID="Separator"/>
                </td>
                <td><h1>Администрирование</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p/>
        <asp:Panel runat="server" ID="panCommon">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal61" runat="server" Text="Общие настройки" />
            </div>
            <ul style="list-style-type: square">
                <li><a href="CommonSettings.aspx">
                    <asp:Literal ID="Literal62" runat="server" Text="Общие настройки"/>
                </a>
                    <asp:Literal ID="Literal63" runat="server" Text=": общие настройки магазина."/>
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panAdmin">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="Действия" />
            </div>
            <ul style="list-style-type: square">
                <li><a href="ManageUsers.aspx">
                    <asp:Literal runat="server" Text="Управление пользователями"/>
                </a>
                    <asp:Literal runat="server" Text=": поиск пользователей по имени или адресу электронной почты, просмотр и изменение учетных данных пользователей и статуса."/>
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panEditor">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="Действия для редактирования" /></div>
            <ul style="list-style-type: square">
<%--                <li><a href="ManageForums.aspx">
                    <asp:Literal runat="server" Text="Управление форумом" /></a>
                    <asp:Literal runat="server" Text=": добавлять/редактировать/удалять форумы, управлять и подтверждать посты." /></li>--%>
                <li><a href="ManagePolls.aspx">
                    <asp:Literal ID="Literal9" runat="server" Text="Управление опросами" /></a>
                    <asp:Literal runat="server" Text=": добавлять/редактировать/удалять опросы и опции опросов просматривать архив опросов." /></li>
            </ul>
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal24" runat="server" Text="Управление новостями" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageNewsletters.aspx">
                    <asp:Literal ID="Literal29" runat="server" Text="Управление новостями" /></a>
                    <asp:Literal ID="Literal30" runat="server" Text=": добавление, удаление, редактирование новостей." />
                </li>
                <li><a href="AddEditNewsletter.aspx">
                    <asp:Literal ID="Literal11" runat="server" Text="Добавление новости" /></a>
                    <asp:Literal ID="Literal25" runat="server" Text=": добавление новости, рассылка новости подписчикам." />
                </li>                
            </ul>            
        </asp:Panel>
        <asp:Panel runat="server" ID="panStoreKeeper">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="Управление каталогом и заказами" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageDepartments.aspx">
                    <asp:Literal ID="Literal4" runat="server" Text="Управление разделами" /></a>
                    <asp:Literal ID="Literal5" runat="server" Text=": добавление/редактирование/удаление разделов каталога продуктов" />
                </li>                
                <li><a href="ManageDepartmentTemplates.aspx">
                    <asp:Literal ID="Literal52" runat="server" Text="Управление шаблонами разделов" /></a>
                    <asp:Literal ID="Literal53" runat="server" Text=": добавление/редактирование/удаление шаблонов разделов" />
                </li>                                
                <li><a href="ManageProducts.aspx">
                    <asp:Literal runat="server" Text="Управление товарами" /></a>
                    <asp:Literal runat="server" Text=": добавление/редактирование/удаление разделов каталога продуктов, способов доставки и статусов заказа." />
                </li>
                <li><a href="ManageProductFeatured.aspx">
                    <asp:Literal ID="Literal10" runat="server" Text="Рекомендуемые товары" /></a>
                    <asp:Literal ID="Literal12" runat="server" Text=": добавление/удаление товаров отображаемых в блоке Рекомендуемые товары." />
                </li>                
                <li><a href="ManageManufacturers.aspx">
                    <asp:Literal ID="Literal35" runat="server" Text="Каталог брендов/производителей" /></a>
                    <asp:Literal ID="Literal36" runat="server" Text=": добавление/редактирование/удаление брендов (производителей)." />
                </li>                
                <li><a href="ManageProductTypes.aspx">
                    <asp:Literal ID="Literal59" runat="server" Text="Типы товаров" /></a>
                    <asp:Literal ID="Literal60" runat="server" Text=": добавление/редактирование/удаление типов товаров из справочника" />
                </li>                   
                <li><a href="ManageProductAttributes.aspx">
                    <asp:Literal ID="Literal44" runat="server" Text="Характеристики товаров" /></a>
                    <asp:Literal ID="Literal45" runat="server" Text=": добавление/редактирование/удаление характеристики товаров из справочника" />
                </li>                                
                <li><a href="ManageFilters.aspx">
                    <asp:Literal ID="Literal48" runat="server" Text="Фильтры" /></a>
                    <asp:Literal ID="Literal49" runat="server" Text=": добавлять/редактировать/удалять фильтры и критерии фильтрации товаров." />
                </li>                
                <li><a href="ManageFilterCriteriaProduct.aspx">
                    <asp:Literal ID="Literal50" runat="server" Text="Фильтрация товаров" /></a>
                    <asp:Literal ID="Literal51" runat="server" Text=": управление связью критериев фильтрации и товаров." />
                </li>
                <li><a href="ManageCurrency.aspx">
                    <asp:Literal ID="Literal54" runat="server" Text="Управление валютами" /></a>
                    <asp:Literal ID="Literal55" runat="server" Text=": добавление/кдаление валют, задание курсов." />
                </li>                
                <li><a href="ManageOrders.aspx">
                    <asp:Literal runat="server" Text="Управление заказами" /></a>
                    <asp:Literal runat="server" Text=": поиск, просмотр и управление заказами." />
                </li>
                <li><a href="ManageShippingMethods.aspx">
                    <asp:Literal ID="Literal37" runat="server" Text="Управление способами доставки" /></a>
                    <asp:Literal ID="Literal38" runat="server" Text=": поиск, просмотр и управление способами доставки." />
                </li>
                <li><a href="ManageOrderStatuses.aspx">
                    <asp:Literal ID="Literal39" runat="server" Text="Управление статусами заказа" /></a>
                    <asp:Literal ID="Literal40" runat="server" Text=": поиск, просмотр и управление статусами заказов." />
                </li>                                
            </ul>
        </asp:Panel>
<%--        <asp:Panel runat="server" ID="panModerator">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="Действия для модератора" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageUnapprovedPosts.aspx">
                    <asp:Literal runat="server" Text="Утверждение постов форума" /></a>
                    <asp:Literal runat="server" Text=": просмотр, утверждение, редактирование или удаление сообщений постов при модерировании форума." />
                </li>
            </ul>
        </asp:Panel>--%>
        <asp:Panel runat="server" ID="panContributor">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="Статьи" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageArticles.aspx">
                    <asp:Literal ID="Literal18" runat="server" Text="Управление статьями" /></a>
                    <asp:Literal ID="Literal19" runat="server" Text=": добавлять, удалять, редактировать статьи, управлять комментариями" />
                </li>            
                <li><a href="ManageCategories.aspx">
                    <asp:Literal ID="Literal20" runat="server" Text="Управление темами" /></a>
                    <asp:Literal ID="Literal21" runat="server" Text=": добавлять, удалять, редактировать темы для статей" />
                </li>                            
                <li><a href="ManageComments.aspx">
                    <asp:Literal ID="Literal28" runat="server" Text="Управление комментариями" /></a>
                    <asp:Literal ID="Literal31" runat="server" Text=": просмотр, редактирование и удаление комментариев, оставленных пользователями к статьям." />
                </li>                
                <li><a href="AddEditArticle.aspx">
                    <asp:Literal runat="server" Text="Добавление статьи" /></a>
                    <asp:Literal runat="server" Text=": добавление статей в разделы. Если вы писатель, ваша статья должна быть утверждена администратором или редактором перед опубликованием." />
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panPortfolio">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal13" runat="server" Text="Галерея объектов" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManagePortfolio.aspx">
                    <asp:Literal ID="Literal46" runat="server" Text="Управление галереей объектов" /></a>
                    <asp:Literal ID="Literal47" runat="server" Text=": добавление/удаление/редактирование объектов." />
                </li>
            </ul>
        </asp:Panel>         
        <asp:Panel runat="server" ID="panSearch">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal1" runat="server" Text="Поисковые запросы" /></div>
            <ul style="list-style-type: square">
                <li><a href="SearchRequests.aspx">
                    <asp:Literal ID="Literal2" runat="server" Text="Анализ поисковых запросов" /></a>
                    <asp:Literal ID="Literal3" runat="server" Text=": просмотр поисковых запросов посетителей магазина." />
                </li>
            </ul>
        </asp:Panel>        
        <asp:Panel runat="server" ID="panStatistics">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal6" runat="server" Text="Статистика временно недоступна" /></div>
            <ul style="list-style-type: square">
                <li><a href="Statistics.aspx">
                    <asp:Literal ID="Literal7" runat="server" Text="Статистика посещения магазина" /></a>
                    <asp:Literal ID="Literal8" runat="server" Text=": просмотр статистики запросов к магазину." />
                </li>
                <li><a href="StatisticsHosts.aspx">
                    <asp:Literal ID="Literal14" runat="server" Text="Хосты"/></a>
                    <asp:Literal ID="Literal15" runat="server" Text=": показывает уникальные IP адреса (хосты) с которых приходили посетители и количество запросов сделанных с них. Может использоваться для выявления и блокировки нежелательных для учета в статистике адресов." />
                </li>       
                <li><a href="StatisticsPages.aspx">
                    <asp:Literal ID="Literal16" runat="server" Text="Страницы" /></a>
                    <asp:Literal ID="Literal17" runat="server" Text=": показывает популярность страниц, позволяет оценить что интересует пользователей на сайте." />
                </li>            
                <li><a href="StatisticsSearches.aspx">
                    <asp:Literal ID="Literal22" runat="server" Text="Поисковики" /></a>
                    <asp:Literal ID="Literal23" runat="server" Text=": показывает с каких поисковиков и по каким запросам приходили пользователи на наш сайт. Позволяет оценить положение сайта в поисковиках и интерес пользователей интернета." />
                </li>                   
                <li><a href="StatisticsSites.aspx">
                    <asp:Literal ID="Literal26" runat="server" Text="Сайты" /></a>
                    <asp:Literal ID="Literal27" runat="server" Text=": показывает с каких сайтов приходили пользователи на наш сайт. Позволяет оценить цитируемость нашего сайта на внешних ресурсах, что является важным показателем для поисковиков." />
                </li>                                   
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panSiteMap">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal32" runat="server" Text="Файл sitemap.xml" /></div>
            <ul style="list-style-type: square">
                <li><a href="SiteMapFile.aspx">
                    <asp:Literal ID="Literal33" runat="server" Text="Сгенерировать файл" /></a>
                    <asp:Literal ID="Literal34" runat="server" Text=": автоматически генерирует файл sitemap.xml, который используется поисковыми роботами для нахождения и индексации страниц. Генерация обычно нужна при добавлении товаров, статей, новостей или других объектов." />
                </li>
            </ul>
        </asp:Panel>                  
        <asp:Panel runat="server" ID="panYandexMarket">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal56" runat="server" Text="Выгрузка в YandexMarket" /></div>
            <ul style="list-style-type: square">
                <li><a href="YandexMarketFile.aspx">
                    <asp:Literal ID="Literal57" runat="server" Text="Сгенерировать файл" /></a>
                    <asp:Literal ID="Literal58" runat="server" Text=": создает файл в формате yml для YandexMarket." />
                </li>
            </ul>
        </asp:Panel>         
        <asp:Panel runat="server" ID="panManageDatabase">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal41" runat="server" Text="Администрирование БД" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageDatabase.aspx">
                    <asp:Literal ID="Literal42" runat="server" Text="Администрирование БД" /></a>
                    <asp:Literal ID="Literal43" runat="server" Text=": автоматизированный контроль и очистка БД от анонимных пользователей, их профилей, запросов с игнорируемых ip адресов." />
                </li>
            </ul>
        </asp:Panel>         
    </div>
</asp:Content>
