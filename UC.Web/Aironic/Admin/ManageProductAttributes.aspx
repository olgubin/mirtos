<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageProductAttributes.aspx.cs" Inherits="UC.UI.Admin.ManageProductAttributes"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="false" %>

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
                        Характеристики товаров</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:DetailsView ID="dvwProductAttribute" runat="server" AutoGenerateRows="False"
                    DataSourceID="objCurrProductAttribute" Height="50px" Width="50%" HeaderText="Характеристика товаров"
                    OnItemInserted="dvwProductAttribute_ItemInserted" OnItemUpdated="dvwProductAttribute_ItemUpdated"
                    OnItemCommand="dvwProductAttribute_ItemCommand" DataKeyNames="ProductAttributeID"
                    DefaultMode="Insert">
                    <FieldHeaderStyle Width="170px" />
                    <Fields>
                        <asp:BoundField DataField="ProductAttributeID" HeaderText="ID" ReadOnly="True" SortExpression="ProductAttributeID"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="Название" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Name") %>' MaxLength="256"
                                    Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
                            HeaderStyle-BackColor="White">
                            <InsertItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" />&nbsp
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" />&nbsp
                                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" />&nbsp
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
                <p />
                <asp:GridView ID="gvwProductAttributes" runat="server" AutoGenerateColumns="False"
                    DataSourceID="objProductAttributes" Width="100%" DataKeyNames="ProductAttributeID"
                    OnRowDeleted="gvwProductAttributes_RowDeleted" OnRowCreated="gvwProductAttributes_RowCreated"
                    OnSelectedIndexChanged="gvwProductAttributes_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить"
                            ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        <b>Каталог пуст</b></EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:GridView>
                <asp:ObjectDataSource ID="objProductAttributes" runat="server" SelectMethod="GetProductAttributes"
                    TypeName="UC.BLL.Store.ProductAttributeManager" DeleteMethod="DeleteProductAttribute">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCurrProductAttribute" runat="server" InsertMethod="InsertProductAttribute"
                    SelectMethod="GetByProductAttributeID" TypeName="UC.BLL.Store.ProductAttributeManager"
                    UpdateMethod="UpdateProductAttribute">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwProductAttributes" Name="ProductAttributeID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
