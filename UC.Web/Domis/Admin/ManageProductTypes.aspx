<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageProductTypes.aspx.cs" Inherits="UC.UI.Admin.ManageProductTypes"
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
                        Типы товаров</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:DetailsView ID="dvwProductType" runat="server" AutoGenerateRows="False"
                    DataSourceID="objCurrProductType" Height="50px" Width="50%" HeaderText="Тип товара"
                    OnItemInserted="dvwProductType_ItemInserted" OnItemUpdated="dvwProductType_ItemUpdated"
                    OnItemCommand="dvwProductType_ItemCommand" DataKeyNames="ProductTypeID"
                    DefaultMode="Insert">
                    <FieldHeaderStyle Width="170px" />
                    <Fields>
                        <asp:BoundField DataField="ProductTypeID" HeaderText="ID" ReadOnly="True" SortExpression="ProductTypeID"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="Тип товара" SortExpression="Type">
                            <ItemTemplate>
                                <asp:Label ID="lblProductType" runat="server" Text='<%# Eval("Type") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtProductType" runat="server" Text='<%# Bind("Type") %>' MaxLength="256"
                                    Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtProductType"
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
                <asp:GridView ID="gvwProductTypes" runat="server" AutoGenerateColumns="False"
                    DataSourceID="objProductTypes" Width="100%" DataKeyNames="ProductTypeID"
                    OnRowDeleted="gvwProductTypes_RowDeleted" OnRowCreated="gvwProductTypes_RowCreated"
                    OnSelectedIndexChanged="gvwProductTypes_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Type" HeaderText="Тип товара" SortExpression="Type" />
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
                <asp:ObjectDataSource ID="objProductTypes" runat="server" SelectMethod="GetProductTypes"
                    TypeName="UC.BLL.Store.ProductTypeManager" DeleteMethod="DeleteProductType">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCurrProductType" runat="server" InsertMethod="InsertProductType"
                    SelectMethod="GetByProductTypeID" TypeName="UC.BLL.Store.ProductTypeManager"
                    UpdateMethod="UpdateProductType">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwProductTypes" Name="ProductTypeID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
