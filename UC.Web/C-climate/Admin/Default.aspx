<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" MasterPageFile="Admin.master"
    Inherits="UC.UI.Admin._Default" Culture="auto" UICulture="auto" EnableViewState="false"%>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">�������</asp:HyperLink></td>
                <td>
                    <asp:Image runat="server" SkinID="Separator"/>
                </td>
                <td><h1>�����������������</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p/>
        <asp:Panel runat="server" ID="panCommon">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal61" runat="server" Text="����� ���������" />
            </div>
            <ul style="list-style-type: square">
                <li><a href="CommonSettings.aspx">
                    <asp:Literal ID="Literal62" runat="server" Text="����� ���������"/>
                </a>
                    <asp:Literal ID="Literal63" runat="server" Text=": ����� ��������� ��������."/>
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panAdmin">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="��������" />
            </div>
            <ul style="list-style-type: square">
                <li><a href="ManageUsers.aspx">
                    <asp:Literal runat="server" Text="���������� ��������������"/>
                </a>
                    <asp:Literal runat="server" Text=": ����� ������������� �� ����� ��� ������ ����������� �����, �������� � ��������� ������� ������ ������������� � �������."/>
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panEditor">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="�������� ��� ��������������" /></div>
            <ul style="list-style-type: square">
<%--                <li><a href="ManageForums.aspx">
                    <asp:Literal runat="server" Text="���������� �������" /></a>
                    <asp:Literal runat="server" Text=": ���������/�������������/������� ������, ��������� � ������������ �����." /></li>--%>
                <li><a href="ManagePolls.aspx">
                    <asp:Literal ID="Literal9" runat="server" Text="���������� ��������" /></a>
                    <asp:Literal runat="server" Text=": ���������/�������������/������� ������ � ����� ������� ������������� ����� �������." /></li>
            </ul>
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal24" runat="server" Text="���������� ���������" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageNewsletters.aspx">
                    <asp:Literal ID="Literal29" runat="server" Text="���������� ���������" /></a>
                    <asp:Literal ID="Literal30" runat="server" Text=": ����������, ��������, �������������� ��������." />
                </li>
                <li><a href="AddEditNewsletter.aspx">
                    <asp:Literal ID="Literal11" runat="server" Text="���������� �������" /></a>
                    <asp:Literal ID="Literal25" runat="server" Text=": ���������� �������, �������� ������� �����������." />
                </li>                
            </ul>            
        </asp:Panel>
        <asp:Panel runat="server" ID="panStoreKeeper">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="���������� ��������� � ��������" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageDepartments.aspx">
                    <asp:Literal ID="Literal4" runat="server" Text="���������� ���������" /></a>
                    <asp:Literal ID="Literal5" runat="server" Text=": ����������/��������������/�������� �������� �������� ���������" />
                </li>                
                <li><a href="ManageDepartmentTemplates.aspx">
                    <asp:Literal ID="Literal52" runat="server" Text="���������� ��������� ��������" /></a>
                    <asp:Literal ID="Literal53" runat="server" Text=": ����������/��������������/�������� �������� ��������" />
                </li>                                
                <li><a href="ManageProducts.aspx">
                    <asp:Literal runat="server" Text="���������� ��������" /></a>
                    <asp:Literal runat="server" Text=": ����������/��������������/�������� �������� �������� ���������, �������� �������� � �������� ������." />
                </li>
                <li><a href="ManageProductFeatured.aspx">
                    <asp:Literal ID="Literal10" runat="server" Text="������������� ������" /></a>
                    <asp:Literal ID="Literal12" runat="server" Text=": ����������/�������� ������� ������������ � ����� ������������� ������." />
                </li>                
                <li><a href="ManageManufacturers.aspx">
                    <asp:Literal ID="Literal35" runat="server" Text="������� �������/��������������" /></a>
                    <asp:Literal ID="Literal36" runat="server" Text=": ����������/��������������/�������� ������� (��������������)." />
                </li>                
                <li><a href="ManageProductTypes.aspx">
                    <asp:Literal ID="Literal59" runat="server" Text="���� �������" /></a>
                    <asp:Literal ID="Literal60" runat="server" Text=": ����������/��������������/�������� ����� ������� �� �����������" />
                </li>                   
                <li><a href="ManageProductAttributes.aspx">
                    <asp:Literal ID="Literal44" runat="server" Text="�������������� �������" /></a>
                    <asp:Literal ID="Literal45" runat="server" Text=": ����������/��������������/�������� �������������� ������� �� �����������" />
                </li>                                
                <li><a href="ManageFilters.aspx">
                    <asp:Literal ID="Literal48" runat="server" Text="�������" /></a>
                    <asp:Literal ID="Literal49" runat="server" Text=": ���������/�������������/������� ������� � �������� ���������� �������." />
                </li>                
                <li><a href="ManageFilterCriteriaProduct.aspx">
                    <asp:Literal ID="Literal50" runat="server" Text="���������� �������" /></a>
                    <asp:Literal ID="Literal51" runat="server" Text=": ���������� ������ ��������� ���������� � �������." />
                </li>
                <li><a href="ManageCurrency.aspx">
                    <asp:Literal ID="Literal54" runat="server" Text="���������� ��������" /></a>
                    <asp:Literal ID="Literal55" runat="server" Text=": ����������/�������� �����, ������� ������." />
                </li>                
                <li><a href="ManageOrders.aspx">
                    <asp:Literal runat="server" Text="���������� ��������" /></a>
                    <asp:Literal runat="server" Text=": �����, �������� � ���������� ��������." />
                </li>
                <li><a href="ManageShippingMethods.aspx">
                    <asp:Literal ID="Literal37" runat="server" Text="���������� ��������� ��������" /></a>
                    <asp:Literal ID="Literal38" runat="server" Text=": �����, �������� � ���������� ��������� ��������." />
                </li>
                <li><a href="ManageOrderStatuses.aspx">
                    <asp:Literal ID="Literal39" runat="server" Text="���������� ��������� ������" /></a>
                    <asp:Literal ID="Literal40" runat="server" Text=": �����, �������� � ���������� ��������� �������." />
                </li>                                
            </ul>
        </asp:Panel>
<%--        <asp:Panel runat="server" ID="panModerator">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="�������� ��� ����������" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageUnapprovedPosts.aspx">
                    <asp:Literal runat="server" Text="����������� ������ ������" /></a>
                    <asp:Literal runat="server" Text=": ��������, �����������, �������������� ��� �������� ��������� ������ ��� ������������� ������." />
                </li>
            </ul>
        </asp:Panel>--%>
        <asp:Panel runat="server" ID="panContributor">
            <div class="sectionsubtitle">
                <asp:Literal runat="server" Text="������" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageArticles.aspx">
                    <asp:Literal ID="Literal18" runat="server" Text="���������� ��������" /></a>
                    <asp:Literal ID="Literal19" runat="server" Text=": ���������, �������, ������������� ������, ��������� �������������" />
                </li>            
                <li><a href="ManageCategories.aspx">
                    <asp:Literal ID="Literal20" runat="server" Text="���������� ������" /></a>
                    <asp:Literal ID="Literal21" runat="server" Text=": ���������, �������, ������������� ���� ��� ������" />
                </li>                            
                <li><a href="ManageComments.aspx">
                    <asp:Literal ID="Literal28" runat="server" Text="���������� �������������" /></a>
                    <asp:Literal ID="Literal31" runat="server" Text=": ��������, �������������� � �������� ������������, ����������� �������������� � �������." />
                </li>                
                <li><a href="AddEditArticle.aspx">
                    <asp:Literal runat="server" Text="���������� ������" /></a>
                    <asp:Literal runat="server" Text=": ���������� ������ � �������. ���� �� ��������, ���� ������ ������ ���� ���������� ��������������� ��� ���������� ����� ��������������." />
                </li>
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panPortfolio">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal13" runat="server" Text="������� ��������" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManagePortfolio.aspx">
                    <asp:Literal ID="Literal46" runat="server" Text="���������� �������� ��������" /></a>
                    <asp:Literal ID="Literal47" runat="server" Text=": ����������/��������/�������������� ��������." />
                </li>
            </ul>
        </asp:Panel>         
        <asp:Panel runat="server" ID="panSearch">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal1" runat="server" Text="��������� �������" /></div>
            <ul style="list-style-type: square">
                <li><a href="SearchRequests.aspx">
                    <asp:Literal ID="Literal2" runat="server" Text="������ ��������� ��������" /></a>
                    <asp:Literal ID="Literal3" runat="server" Text=": �������� ��������� �������� ����������� ��������." />
                </li>
            </ul>
        </asp:Panel>        
        <asp:Panel runat="server" ID="panStatistics">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal6" runat="server" Text="���������� �������� ����������" /></div>
            <ul style="list-style-type: square">
                <li><a href="Statistics.aspx">
                    <asp:Literal ID="Literal7" runat="server" Text="���������� ��������� ��������" /></a>
                    <asp:Literal ID="Literal8" runat="server" Text=": �������� ���������� �������� � ��������." />
                </li>
                <li><a href="StatisticsHosts.aspx">
                    <asp:Literal ID="Literal14" runat="server" Text="�����"/></a>
                    <asp:Literal ID="Literal15" runat="server" Text=": ���������� ���������� IP ������ (�����) � ������� ��������� ���������� � ���������� �������� ��������� � ���. ����� �������������� ��� ��������� � ���������� ������������� ��� ����� � ���������� �������." />
                </li>       
                <li><a href="StatisticsPages.aspx">
                    <asp:Literal ID="Literal16" runat="server" Text="��������" /></a>
                    <asp:Literal ID="Literal17" runat="server" Text=": ���������� ������������ �������, ��������� ������� ��� ���������� ������������� �� �����." />
                </li>            
                <li><a href="StatisticsSearches.aspx">
                    <asp:Literal ID="Literal22" runat="server" Text="����������" /></a>
                    <asp:Literal ID="Literal23" runat="server" Text=": ���������� � ����� ����������� � �� ����� �������� ��������� ������������ �� ��� ����. ��������� ������� ��������� ����� � ����������� � ������� ������������� ���������." />
                </li>                   
                <li><a href="StatisticsSites.aspx">
                    <asp:Literal ID="Literal26" runat="server" Text="�����" /></a>
                    <asp:Literal ID="Literal27" runat="server" Text=": ���������� � ����� ������ ��������� ������������ �� ��� ����. ��������� ������� ������������ ������ ����� �� ������� ��������, ��� �������� ������ ����������� ��� �����������." />
                </li>                                   
            </ul>
        </asp:Panel>
        <asp:Panel runat="server" ID="panSiteMap">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal32" runat="server" Text="���� sitemap.xml" /></div>
            <ul style="list-style-type: square">
                <li><a href="SiteMapFile.aspx">
                    <asp:Literal ID="Literal33" runat="server" Text="������������� ����" /></a>
                    <asp:Literal ID="Literal34" runat="server" Text=": ������������� ���������� ���� sitemap.xml, ������� ������������ ���������� �������� ��� ���������� � ���������� �������. ��������� ������ ����� ��� ���������� �������, ������, �������� ��� ������ ��������." />
                </li>
            </ul>
        </asp:Panel>                  
        <asp:Panel runat="server" ID="panYandexMarket">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal56" runat="server" Text="�������� � YandexMarket" /></div>
            <ul style="list-style-type: square">
                <li><a href="YandexMarketFile.aspx">
                    <asp:Literal ID="Literal57" runat="server" Text="������������� ����" /></a>
                    <asp:Literal ID="Literal58" runat="server" Text=": ������� ���� � ������� yml ��� YandexMarket." />
                </li>
            </ul>
        </asp:Panel>         
        <asp:Panel runat="server" ID="panManageDatabase">
            <div class="sectionsubtitle">
                <asp:Literal ID="Literal41" runat="server" Text="����������������� ��" /></div>
            <ul style="list-style-type: square">
                <li><a href="ManageDatabase.aspx">
                    <asp:Literal ID="Literal42" runat="server" Text="����������������� ��" /></a>
                    <asp:Literal ID="Literal43" runat="server" Text=": ������������������ �������� � ������� �� �� ��������� �������������, �� ��������, �������� � ������������ ip �������." />
                </li>
            </ul>
        </asp:Panel>         
    </div>
</asp:Content>
