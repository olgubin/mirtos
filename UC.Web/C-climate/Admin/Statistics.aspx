<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="Statistics.aspx.cs" Inherits="UC.UI.Admin.Statistics"
    Culture="auto" UICulture="auto" EnableViewState="false"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
            <table>
                <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><asp:Image ID="Image2" runat="server" SkinID="Separator"/> </td>
                <td><h1>татистика посещения магазина</h1></td>
                </tr>
            </table>
    </div>
    <div id="content">
    <p>Показывает за периоды сколько посетителей пришло на сайт, сколько из них уникальных (хостов), сколько было просмотрено страниц (хитов),
    сколько было переходов с других сайтов и поисковиков.</p>
  <div style="padding-bottom:7px;font-weight:bold">Общая статистика</div>
        <asp:GridView ID="gvwStatisticsAll" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsAll" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwStatisticsAll_RowDataBound">
            <RowStyle HorizontalAlign="Center" Font-Bold="true" />
            <Columns>
           <asp:TemplateField ItemStyle-Width="100px">
            <ItemTemplate>
            <b>Всего:</b>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="Просмотров (хитов)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="Посещений" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="Посетителей" DataField="HostsCount"/>
                <asp:BoundField HeaderText="Уникальных (хостов)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="С сайтов" DataField="SitesCount"/>
                <asp:BoundField HeaderText="С поисковиков" DataField="SearchCount"/>
                <asp:BoundField HeaderText="Боты" DataField="BotsCount"/>
                <asp:BoundField HeaderText="Запросов ботов" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal ID="Literal2" runat="server" Text="Нет данных" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsAll" runat="server" SelectMethod="ReportStatisticsAll"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>    
    
    
<div style="padding:10px 0px 7px 0px;font-weight:bold">За 7 дней</div>  
        <asp:GridView ID="gvwStatisticsDaily" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsDaily" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
                <asp:BoundField HeaderText="Дата" DataField="FirstDate" DataFormatString="{0:dd/MM/yy}" ItemStyle-Width="100px"/>
                <asp:BoundField HeaderText="Просмотров (хитов)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="Посещений" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="Посетителей" DataField="HostsCount"/>
                <asp:BoundField HeaderText="Уникальных (хостов)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="С сайтов" DataField="SitesCount"/>
                <asp:BoundField HeaderText="С поисковиков" DataField="SearchCount"/>
                <asp:BoundField HeaderText="Боты" DataField="BotsCount"/>
                <asp:BoundField HeaderText="Запросов ботов" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="Нет данных" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsDaily" runat="server" SelectMethod="ReportStatisticsDaily"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>
<div style="padding:10px 0px 7px 0px;font-weight:bold">За 7 недель</div>
        <asp:GridView ID="gvwStatisticsWeekly" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsWeekly" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
            <asp:TemplateField HeaderText="Дата" ItemStyle-Width="100px">
            <ItemTemplate>
            <%# "с "+Eval("FirstDate", "{0:dd/MM}") + " по " + Eval("LastDate", "{0:dd/MM}")%>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="Просмотров (хитов)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="Посещений" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="Посетителей" DataField="HostsCount"/>
                <asp:BoundField HeaderText="Уникальных (хостов)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="С сайтов" DataField="SitesCount"/>
                <asp:BoundField HeaderText="С поисковиков" DataField="SearchCount"/>
                <asp:BoundField HeaderText="Боты" DataField="BotsCount"/>
                <asp:BoundField HeaderText="Запросов ботов" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="Нет данных" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsWeekly" runat="server" SelectMethod="ReportStatisticsWeekly"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>            
<div style="padding:10px 0px 7px 0px;font-weight:bold">За 7 месяцев</div>
        <asp:GridView ID="gvwStatisticsMonthly" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsMonthly" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
            <asp:TemplateField HeaderText="Дата" ItemStyle-Width="100px">
            <ItemTemplate>
            <%# Eval("FirstDate", "{0:MMM} {0:yyyy} г.") %>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="Просмотров (хитов)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="Посещений" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="Посетителей" DataField="HostsCount"/>
                <asp:BoundField HeaderText="Уникальных (хостов)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="С сайтов" DataField="SitesCount"/>
                <asp:BoundField HeaderText="С поисковиков" DataField="SearchCount"/>
                <asp:BoundField HeaderText="Боты" DataField="BotsCount"/>
                <asp:BoundField HeaderText="Запросов ботов" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal ID="Literal1" runat="server" Text="Нет данных" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsMonthly" runat="server" SelectMethod="ReportStatisticsMonthly"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>              
    </div>
</asp:Content>
