<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="StatisticsRequests.aspx.cs" Inherits="UC.UI.Admin.StatisticsRequests"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">������ ��� ������</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td><h1>���������� �� ��������</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>���������� ������� �������������, ��������� � ������ ������� ���������� ������������� ��� ���������� �����, ������������� ������� � ������������ ��������� �� �������.</p>
    <asp:Label runat="server" ID="lblFiltr" ForeColor="#9aaab1" Font-Bold="true"/>
            <p>���������� ������� �� ��������:
                <asp:DropDownList ID="ddlPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestsPerPage_SelectedIndexChanged">
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="40">40</asp:ListItem>
                    <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                </asp:DropDownList>
</p>                
            <asp:GridView ID="gvwRequests" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                DataKeyNames="IP" AllowSorting="true" EmptyDataText="<b>��� ������</b>" OnRowDataBound="gvwPages_RowDataBound"> <%--DataSourceID="objRequests" DataSourceID="objRequests" OnRowCreated="gvwPages_RowCreated">--%>
                <Columns>
                    <asp:BoundField HeaderText="����" DataField="RequestDate" DataFormatString="{0:dd/MM/yy} {0:HH:mm}" ItemStyle-HorizontalAlign="Center" SortExpression="requestdate" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="IP �����" DataField="IP" SortExpression="ip" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="������������" DataField="UserID" SortExpression="userid" ItemStyle-Width="100px"/>
                    <asp:BoundField HeaderText="��������" DataField="URL" SortExpression="url"/>
                    <asp:BoundField HeaderText="�������" DataField="BrowserString" SortExpression="browserstring"/>
                </Columns>
                <EmptyDataTemplate>
                    <b>
                        <asp:Literal ID="Literal1" runat="server" Text="��� ������" />
                    </b>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objRequests" runat="server" EnablePaging="true" 
                 SortParameterName="SortExpression" TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>
    </div>
</asp:Content>
