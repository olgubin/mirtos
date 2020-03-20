<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="Statistics.aspx.cs" Inherits="UC.UI.Admin.Statistics"
    Culture="auto" UICulture="auto" EnableViewState="false"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
            <table>
                <tr>
                <td class="h1">
                    <a href="../Default.aspx">�������</a>
                </td>
                <td><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td><asp:Image ID="Image2" runat="server" SkinID="Separator"/> </td>
                <td><h1>��������� ��������� ��������</h1></td>
                </tr>
            </table>
    </div>
    <div id="content">
    <p>���������� �� ������� ������� ����������� ������ �� ����, ������� �� ��� ���������� (������), ������� ���� ����������� ������� (�����),
    ������� ���� ��������� � ������ ������ � �����������.</p>
  <div style="padding-bottom:7px;font-weight:bold">����� ����������</div>
        <asp:GridView ID="gvwStatisticsAll" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsAll" EmptyDataText="<b>��� ������</b>" OnRowDataBound="gvwStatisticsAll_RowDataBound">
            <RowStyle HorizontalAlign="Center" Font-Bold="true" />
            <Columns>
           <asp:TemplateField ItemStyle-Width="100px">
            <ItemTemplate>
            <b>�����:</b>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="���������� (�����)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="���������" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="�����������" DataField="HostsCount"/>
                <asp:BoundField HeaderText="���������� (������)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="� ������" DataField="SitesCount"/>
                <asp:BoundField HeaderText="� �����������" DataField="SearchCount"/>
                <asp:BoundField HeaderText="����" DataField="BotsCount"/>
                <asp:BoundField HeaderText="�������� �����" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal ID="Literal2" runat="server" Text="��� ������" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsAll" runat="server" SelectMethod="ReportStatisticsAll"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>    
    
    
<div style="padding:10px 0px 7px 0px;font-weight:bold">�� 7 ����</div>  
        <asp:GridView ID="gvwStatisticsDaily" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsDaily" EmptyDataText="<b>��� ������</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
                <asp:BoundField HeaderText="����" DataField="FirstDate" DataFormatString="{0:dd/MM/yy}" ItemStyle-Width="100px"/>
                <asp:BoundField HeaderText="���������� (�����)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="���������" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="�����������" DataField="HostsCount"/>
                <asp:BoundField HeaderText="���������� (������)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="� ������" DataField="SitesCount"/>
                <asp:BoundField HeaderText="� �����������" DataField="SearchCount"/>
                <asp:BoundField HeaderText="����" DataField="BotsCount"/>
                <asp:BoundField HeaderText="�������� �����" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="��� ������" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsDaily" runat="server" SelectMethod="ReportStatisticsDaily"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>
<div style="padding:10px 0px 7px 0px;font-weight:bold">�� 7 ������</div>
        <asp:GridView ID="gvwStatisticsWeekly" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsWeekly" EmptyDataText="<b>��� ������</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
            <asp:TemplateField HeaderText="����" ItemStyle-Width="100px">
            <ItemTemplate>
            <%# "� "+Eval("FirstDate", "{0:dd/MM}") + " �� " + Eval("LastDate", "{0:dd/MM}")%>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="���������� (�����)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="���������" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="�����������" DataField="HostsCount"/>
                <asp:BoundField HeaderText="���������� (������)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="� ������" DataField="SitesCount"/>
                <asp:BoundField HeaderText="� �����������" DataField="SearchCount"/>
                <asp:BoundField HeaderText="����" DataField="BotsCount"/>
                <asp:BoundField HeaderText="�������� �����" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="��� ������" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsWeekly" runat="server" SelectMethod="ReportStatisticsWeekly"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>            
<div style="padding:10px 0px 7px 0px;font-weight:bold">�� 7 �������</div>
        <asp:GridView ID="gvwStatisticsMonthly" runat="server" AutoGenerateColumns="False"
            DataKeyNames="FirstDate" DataSourceID="objStatisticsMonthly" EmptyDataText="<b>��� ������</b>" OnRowDataBound="gvwStatistics_RowDataBound">
            <RowStyle HorizontalAlign="Center"/>
            <Columns>
            <asp:TemplateField HeaderText="����" ItemStyle-Width="100px">
            <ItemTemplate>
            <%# Eval("FirstDate", "{0:MMM} {0:yyyy} �.") %>
            </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="���������� (�����)" DataField="HitsCount"/>
                <asp:BoundField HeaderText="���������" DataField="SessionsCount"/>
                <asp:BoundField HeaderText="�����������" DataField="HostsCount"/>
                <asp:BoundField HeaderText="���������� (������)" DataField="UniqueHostsCount"/>
                <asp:BoundField HeaderText="� ������" DataField="SitesCount"/>
                <asp:BoundField HeaderText="� �����������" DataField="SearchCount"/>
                <asp:BoundField HeaderText="����" DataField="BotsCount"/>
                <asp:BoundField HeaderText="�������� �����" DataField="BotsRequestsCount"/>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal ID="Literal1" runat="server" Text="��� ������" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objStatisticsMonthly" runat="server" SelectMethod="ReportStatisticsMonthly"
            TypeName="UC.BLL.Statistics.StatisticsReport"></asp:ObjectDataSource>              
    </div>
</asp:Content>
