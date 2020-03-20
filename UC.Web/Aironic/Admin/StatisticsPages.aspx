<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="StatisticsPages.aspx.cs" Inherits="UC.UI.Admin.StatisticsPages"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Климатическое оборудование</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Статистика по страницам</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>Показывает популярность страниц, позволяет оценить что интересует пользователей на сайте.</p>
            <p>Отображать записей на странице:
                <asp:DropDownList ID="ddlPagesPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestsPerPage_SelectedIndexChanged">
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="40">40</asp:ListItem>
                    <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                </asp:DropDownList>
</p>                
            <asp:GridView ID="gvwPages" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                DataKeyNames="Url" DataSourceID="objPages" AllowSorting="true" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwPages_RowDataBound">
                <Columns>
                    <asp:HyperLinkField HeaderText="Просмотров" DataTextField="Hits" DataNavigateUrlFields="Url" DataNavigateUrlFormatString="StatisticsRequests.aspx?url={0}" SortExpression="hits" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px"/>
                    <%--<asp:BoundField HeaderText="Просмотров" DataField="Hits" SortExpression="hits" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="70px"/>--%>
                    <asp:BoundField HeaderText="Страница" DataField="Url" SortExpression="url"/>
                    <asp:BoundField HeaderText="Описание"/>
                    <asp:BoundField HeaderText="Последний просмотр" DataField="LastDate" DataFormatString="{0:dd/MM/yy}" ItemStyle-HorizontalAlign="Center" SortExpression="lastdate" ItemStyle-Width="100px"/>
                </Columns>
                <EmptyDataTemplate>
                    <b>
                        <asp:Literal ID="Literal1" runat="server" Text="Нет данных" />
                    </b>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objPages" runat="server" SelectMethod="ReportPages" SelectCountMethod="ReportPagesCount" EnablePaging="true" 
                 SortParameterName="SortExpression" TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>         
    </div>
</asp:Content>
