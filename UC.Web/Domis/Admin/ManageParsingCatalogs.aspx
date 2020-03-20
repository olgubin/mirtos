<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="ManageParsingCatalogs.aspx.cs" Inherits="UC.UI.Admin.ManageParsingCatalogs"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="../Controls/FileUploader.ascx" TagName="FileUploader" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Управление внешними каталогами</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <%--        <ul style="list-style-type: square">
            <li>
                <asp:HyperLink runat="server" ID="lnkManageDepartments" NavigateUrl="ManageProducts.aspx"
                    meta:resourcekey="lnkManageDepartmentsResource1">Управление товарами</asp:HyperLink></li>
            <li>
                <asp:HyperLink runat="server" ID="lnkManageShippingMethods" NavigateUrl="ManageShippingMethods.aspx"
                    meta:resourcekey="lnkManageShippingMethodsResource1">Управление способами доставки</asp:HyperLink></li>
            <li>
                <asp:HyperLink runat="server" ID="lnkManageOrderStatuses" NavigateUrl="ManageOrderStatuses.aspx"
                    meta:resourcekey="lnkManageOrderStatusesResource1">Управление статусами заказа</asp:HyperLink></li>
        </ul>--%>
        <p>
        </p>
        <asp:GridView ID="gvwCatalogs" runat="server" AutoGenerateColumns="False" DataSourceID="objCatalogs"
            Width="100%" DataKeyNames="ID" OnRowDeleted="gvwCatalogs_RowDeleted" OnRowCreated="gvwCatalogs_RowCreated"
            OnSelectedIndexChanged="gvwCatalogs_SelectedIndexChanged" ShowHeader="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 200px;">
                                    <b>Каталог:</b>
                                </td>
                                <td>
                                    <%# Eval("Title") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Провайдер:</b>
                                </td>
                                <td>
                                    <%# Eval("SiteProviderType") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Последнее обновление:</b>
                                </td>
                                <td>
                                    <%# Eval("UpdateDate") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать каталог"
                    ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить каталог"
                    ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:CommandField>
                <asp:HyperLinkField Text="&lt;img border='0' src='../Images/ArrowR.gif' alt='Отобразить каталог' /&gt;"
                    DataNavigateUrlFormatString="ManageParsingProducts.aspx?CatalogID={0}" DataNavigateUrlFields="ID">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:HyperLinkField>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal runat="server" Text="Каталогов нет" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objcatalogs" runat="server" SelectMethod="GetCatalogs"
            TypeName="UC.BLL.Parsing.ParsingCatalog" DeleteMethod="DeleteCatalog">
        </asp:ObjectDataSource>
        <p>
        </p>
        <asp:DetailsView ID="dvwCatalog" runat="server" AutoGenerateRows="False" DataSourceID="objCurrCatalog"
            Height="50px" Width="50%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True"
            HeaderText="Информация о каталоге" OnItemInserted="dvwCatalog_ItemInserted" OnItemUpdated="dvwCatalog_ItemUpdated"
            DataKeyNames="ID" DefaultMode="Insert" OnItemCommand="dvwCatalog_ItemCommand">
            <Fields>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                    InsertVisible="False" />
                <asp:TemplateField HeaderText="Название" SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' MaxLength="256"
                            Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                            SetFocusOnError="True" Text="Поле название обязательно для заполнения." ToolTip="Поле название обязательно для заполнения."
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemStyle Width="100%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Провайдер" SortExpression="SiteProviderType">
                    <ItemTemplate>
                        <asp:Label ID="lblProviderType" runat="server" Text='<%# Eval("SiteProviderType") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtProviderType" runat="server" Text='<%# Bind("SiteProviderType") %>'
                            MaxLength="256" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireProviderType" runat="server" ControlToValidate="txtProviderType"
                            SetFocusOnError="True" Text="Поле провайдера обязательно для заполнения." ToolTip="Поле провайдера обязательно для заполнения."
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="UpdateDate" HeaderText="Последнее обновление" InsertVisible="False"
                    ReadOnly="True" SortExpression="UpadetDate" />
            </Fields>
        </asp:DetailsView>
        <asp:ObjectDataSource ID="objCurrCatalog" runat="server" InsertMethod="InsertCatalog"
            SelectMethod="GetCatalogByID" TypeName="UC.BLL.Parsing.ParsingCatalog"
            UpdateMethod="UpdateCatalog">
            <SelectParameters>
                <asp:ControlParameter ControlID="gvwCatalogs" Name="catalogID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
