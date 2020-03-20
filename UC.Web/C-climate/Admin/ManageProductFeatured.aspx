<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageProductFeatured.aspx.cs" Inherits="UC.UI.Admin.ManageProductFeatured"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="false" %>

<%@ Register Src="../Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox"
    TagPrefix="mb" %>
<%@ Register Src="../Admin/Controls/SelectDepartmentControl.ascx" TagName="SelectDepartmentControl"
    TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        Рекомендуемые товары</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <p />
                <asp:UpdateProgress ID="progress" runat="server" DisplayAfter="0">
                    <ProgressTemplate>
                        <div style="width: 100%; background-color: Red; color: White; padding: 3px; margin-bottom: 7px">
                            Выполнение запроса...</div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="100%" cellpadding="3px">
                <tr>
                <td colspan="2">Раздел для добавляемых товаров: <mb:SelectDepartmentControl ID="ddlDepartments" runat="server" AutoPostBack="true"
                                OnSelectedIndexChange="ddlDepartments_SelectedIndexChanged"></mb:SelectDepartmentControl>
                </td>
                </tr>
                    <tr>
                        <td style="width: 65%">
                            <p>
                                <h3>
                                    Выбранные товары</h3>
                                <asp:GridView ID="gvwProductFeatured" runat="server" AutoGenerateColumns="False"
                                    DataSourceID="objProductFeatured" Width="100%" DataKeyNames="ProductFeaturedID"
                                    OnRowDeleted="gvwProductFeatured_RowDeleted" OnRowCreated="gvwProductFeatured_RowCreated">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Товар" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40%"
                                            ItemStyle-HorizontalAlign="left">
                                            <ItemTemplate>
                                                <%# Eval("Product.Title") %>
                                                <asp:HiddenField ID="hfProductFeaturedID" runat="server" Value='<%# Eval("ProductFeaturedID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Реклама" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="60%"
                                            ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtDescription" MaxLength="125" Width="97%" Text='<%# Eval("Description") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="п/п" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <mb:NumericTextBox runat="server" CssClass="adminInput" Width="40px" ID="txtDisplayOrder"
                                                    Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Обязательно для заполнения"
                                                    RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                                                    MaximumValue="99999"></mb:NumericTextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить"
                                            ShowDeleteButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <b>Каталог пуст</b></EmptyDataTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="objProductFeatured" runat="server" SelectMethod="GetProductFeatured"
                                    TypeName="UC.BLL.Store.ProductFeaturedManager" DeleteMethod="DeleteProductFeatured">
                                </asp:ObjectDataSource>
                                <p>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить"
                                        OnClick="btnUpdate_Click" /><asp:Label ID="lblAttribute" runat="server" EnableViewState="false"
                                            ForeColor="Red" Font-Size="Small"></asp:Label>
                                </p>
                                <p>
                                    * рекламное описание не должно превышать 125 символов</p>
                        </td>
                        <td style="width: 35%">
                            <h3>
                                Добавление товаров</h3>
                            <asp:GridView ID="gvFeaturedProducts" runat="server" AutoGenerateColumns="false"
                                AllowPaging="True" PageSize="30" Width="100%" OnPageIndexChanging="gvFeaturedProducts_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Список товаров" ItemStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbProductInfo" runat="server" Text='<%# Server.HtmlEncode(Eval("ProductInfo").ToString()) %>'
                                                Checked='<%# Eval("IsMapped") %>' />
                                            <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                            <asp:HiddenField ID="hfProductFeaturedID" runat="server" Value='<%# Eval("ProductFeaturedID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <p>
                                <asp:Button ID="btnProductFeatured" runat="server" CssClass="adminButton" Text="Обновить"
                                    OnClick="btnProductFeatured_Click" />&nbsp&nbsp<asp:Label ID="lblFeedBack" runat="server"
                                        EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label></p>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
