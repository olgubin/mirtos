<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="StatisticsRequests.aspx.cs" Inherits="UC.UI.Admin.StatisticsRequests"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Статистика по запросам</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>Показывает запросы пользователей, позволяет в первую очередь определить нежелательные для статистики хосты, распределение запроса к определенным страницам по времени.</p>
    <asp:Label runat="server" ID="lblFiltr" ForeColor="#9aaab1" Font-Bold="true"/>
            <p>Отображать записей на странице:
                <asp:DropDownList ID="ddlPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestsPerPage_SelectedIndexChanged">
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="40">40</asp:ListItem>
                    <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                </asp:DropDownList>
</p>                
            <asp:GridView ID="gvwRequests" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                DataKeyNames="IP" AllowSorting="true" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwPages_RowDataBound"> <%--DataSourceID="objRequests" DataSourceID="objRequests" OnRowCreated="gvwPages_RowCreated">--%>
                <Columns>
                    <asp:BoundField HeaderText="Дата" DataField="RequestDate" DataFormatString="{0:dd/MM/yy} {0:HH:mm}" ItemStyle-HorizontalAlign="Center" SortExpression="requestdate" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="IP адрес" DataField="IP" SortExpression="ip" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="Пользователь" DataField="UserID" SortExpression="userid" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="Страница" DataField="URL" SortExpression="url"/>
                    <asp:BoundField HeaderText="Броузер" DataField="BrowserString" SortExpression="browserstring"/>
                </Columns>
                <EmptyDataTemplate>
                    <b>
                        <asp:Literal ID="Literal1" runat="server" Text="Нет данных" />
                    </b>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objRequests" runat="server" EnablePaging="true" 
                 SortParameterName="SortExpression" TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>
    </div>
</asp:Content>
