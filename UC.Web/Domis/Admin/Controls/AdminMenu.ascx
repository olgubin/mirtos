<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UC.UI.Controls.AdminMenu"
    EnableViewState="false" %>
<div class="box">
    <div class="boxtitle">
        �����������������</div>
    <div class="boxcontent departmentmenu">
        <div class="transparent">
        </div>
        <div class="menu" style="padding-left: 5px;">
            <table>
                <tr>
                    <th>
                        <b>����� ���������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink29" Text="����� ���������" NavigateUrl="~/Admin/CommonSettings.aspx" />
                    </td>
                </tr>            
                <tr>
                    <th>
                        <b>��������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="lnkDepTitle" Text="���������� ��������������" NavigateUrl="~/Admin/ManageUsers.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>�������� ��� ��������������</b>
                    </th>
                </tr>
<%--                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink2" Text="���������� �������" NavigateUrl="~/Admin/ManageForums.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink3" Text="���������� ��������" NavigateUrl="~/Admin/ManagePolls.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>���������� ���������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" Text="���������� ���������" NavigateUrl="~/Admin/ManageNewsletters.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" Text="���������� �������" NavigateUrl="~/Admin/AddEditNewsletter.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>���������� ��������� � ��������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink5" Text="���������� ���������" NavigateUrl="~/Admin/ManageDepartments.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink25" Text="���������� ��������� ��������" NavigateUrl="~/Admin/ManageDepartmentTemplates.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink6" Text="���������� ��������" NavigateUrl="~/Admin/ManageProducts.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink2" Text="������������� ������" NavigateUrl="~/Admin/ManageProductFeatured.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink19" Text="������� ��������������" NavigateUrl="~/Admin/ManageManufacturers.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink28" Text="���� �������" NavigateUrl="~/Admin/ManageProductTypes.aspx" />
                    </td>
                </tr>                 
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink23" Text="�������������� �������" NavigateUrl="~/Admin/ManageProductAttributes.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink12" Text="�������" NavigateUrl="~/Admin/ManageFilters.aspx" />
                    </td>
                </tr>                
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink24" Text="���������� �������" NavigateUrl="~/Admin/ManageFilterCriteriaProduct.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink26" Text="���������� ��������" NavigateUrl="~/Admin/ManageCurrency.aspx" />
                    </td>
                </tr>                                 
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink7" Text="���������� ��������" NavigateUrl="~/Admin/ManageOrders.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink20" Text="���������� ���������" NavigateUrl="~/Admin/ManageShippingMethods.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink21" Text="���������� ���������" NavigateUrl="~/Admin/ManageOrderStatuses.aspx" />
                    </td>
                </tr>
<%--                <tr>
                    <th>
                        <b>�������� ��� ����������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink8" Text="����������� ������ ������" NavigateUrl="~/Admin/ManageUnapprovedPosts.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        <b>������</b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink1" Text="���������� ��������" NavigateUrl="~/Admin/ManageArticles.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink15" Text="���������� ������" NavigateUrl="~/Admin/ManageCategories.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink17" Text="���������� �������������" NavigateUrl="~/Admin/ManageComments.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink9" Text="���������� ������" NavigateUrl="~/Admin/AddEditArticle.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>������� ��������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink8" Text="���������� �������� ��������" NavigateUrl="~/Admin/ManagePortfolio.aspx" />
                    </td>
                </tr>
                <tr>                
                <tr>
                    <th>
                        <b>��������� �������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink10" Text="������ ��������� ��������" NavigateUrl="~/Admin/SearchRequests.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>����������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink11" Text="���������� ��������� ��������"
                            NavigateUrl="~/Admin/Statistics.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink13" Text="�����" NavigateUrl="~/Admin/StatisticsHosts.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink14" Text="��������" NavigateUrl="~/Admin/StatisticsPages.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink16" Text="����������" NavigateUrl="~/Admin/StatisticsSearches.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink4" Text="�����" NavigateUrl="~/Admin/StatisticsSites.aspx" />
                    </td>
                </tr>
<%--                <tr>
                    <th>
                        <b>������� ���������</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink12" Text="���������� �������� ����������"
                            NavigateUrl="~/Admin/ManageParsingCatalogs.aspx" />
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        <b>���� sitemap.xml</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink18" Text="������������� ����" NavigateUrl="~/Admin/SiteMapFile.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>�������� � YandexMarket</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink27" Text="������������� ����" NavigateUrl="~/Admin/YandexMarketFile.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>����������������� ��</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" ID="HyperLink22" Text="����������������� ��" NavigateUrl="~/Admin/ManageDatabase.aspx" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>�����</b>
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton runat="server" ID="lnkBtn" Text="�����" OnClick="lnkBtn_Click">�����</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
