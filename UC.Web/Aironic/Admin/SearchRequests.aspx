<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="SearchRequests.aspx.cs" Inherits="UC.UI.Admin.SearchRequests"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">������������� ������������</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td><h1>������ ��������� ��������</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <div style="padding-top: 7px; padding-bottom: 7px; text-align: right; width: 100%;">
            <asp:Literal runat="server" Text="<small><b>�������� �� ��������:</b></small>"></asp:Literal>
            <asp:DropDownList ID="ddlRequestsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestsPerPage_SelectedIndexChanged">
                <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="40">40</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:GridView ID="gvwRequests" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="SearchID" DataSourceID="objAllRequests" AllowSorting="True" EmptyDataText="<b>��� ��������</b>">
            <Columns>
                <asp:BoundField HeaderText="��������" DataField="SearchDate" DataFormatString="{0:dd/MM/yy} {0:t}"
                    SortExpression="searchdate" />
                <asp:BoundField HeaderText="������" DataField="Request" SortExpression="searchrequest" />
                <asp:BoundField HeaderText="�������" DataField="Result" SortExpression="result" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="��������" DataField="PageFrom" SortExpression="pagefrom" />
                <%--<asp:BoundField HeaderText="������" DataField="PageRequest" SortExpression="pagerequest"/>--%>
                <asp:BoundField HeaderText="������������" DataField="SearchBy" SortExpression="searchby" />
                <asp:BoundField HeaderText="IP" DataField="SearchByIP" SortExpression="searchbyip" />
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="��� �����������" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objAllRequests" runat="server" SortParameterName="sortExpression"
            SelectMethod="GetSearchRequests" SelectCountMethod="GetRequestCount" EnablePaging="True"
            TypeName="UC.BLL.Search.SearchRequest"></asp:ObjectDataSource>
    </div>
</asp:Content>
