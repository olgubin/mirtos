<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManagePortfolio.aspx.cs" Inherits="UC.UI.Admin.ManagePortfolio" Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="false" %>
<%@ Register Src="~/Admin/Controls/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="mb" %>
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
                        Галерея объектов</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:DetailsView ID="dvwPortfolio" runat="server" AutoGenerateRows="False"
                    DataSourceID="objCurrPortfolio" Height="50px" Width="50%" HeaderText="Описание объекта"
                    OnItemInserted="dvwPortfolio_ItemInserted" OnItemUpdated="dvwPortfolio_ItemUpdated"
                    OnItemCommand="dvwPortfolio_ItemCommand" DataKeyNames="PortfolioID"
                    DefaultMode="Insert">
                    <FieldHeaderStyle Width="170px" />
                    <Fields>
                        <asp:BoundField DataField="PortfolioID" HeaderText="ID" ReadOnly="True" SortExpression="PortfolioID"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="Описание" SortExpression="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' MaxLength="256"
                                    Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireDescription" runat="server" ControlToValidate="txtDescription"
                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Порядок" SortExpression="DisplayOrder">
                            <ItemTemplate>
                                <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>' MaxLength="256"
                                    Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireImportance" runat="server" ControlToValidate="txtDisplayOrder"
                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="valImportanceType" runat="server" Operator="DataTypeCheck"
                                    Type="Integer" ControlToValidate="txtDisplayOrder" Text="Порядок отображения должен быть целым числом."
                                    ToolTip="Порядок отображения должен быть целым числом." Display="Dynamic"/>
                            </EditItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Изображение" ConvertEmptyStringToNull="False">
                            <ItemTemplate>
                                <asp:Image ID="imgImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' GenerateEmptyAlternateText="true"
                                    Visible='<%# !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageUrl").ToString()) %>'/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>' MaxLength="256" Width="100%"></asp:TextBox>
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
                <asp:Label ID="lblFeedBack" runat="server"/>
                <p>
                <mb:ImageUploader runat="server" ID="imageUploader" AbsoluteUrl="Images\\Portfolio\\" Url="Images/Portfolio/" />
                </p>
                <asp:GridView ID="gvwPortfolio" runat="server" AutoGenerateColumns="False"
                    DataSourceID="objPortfolio" Width="100%" DataKeyNames="PortfolioID"
                    OnRowDeleted="gvwPortfolio_RowDeleted" OnRowCreated="gvwPortfolio_RowCreated"
                    OnSelectedIndexChanged="gvwPortfolio_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="Изображение">
                            <ItemTemplate>
                                    <asp:Image ID="Image3" runat="server" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>'
                                        ImageAlign="AbsMiddle" Width="200px" Height="150px"/>
                            </ItemTemplate>
                        </asp:TemplateField>                    
                        <asp:BoundField DataField="Description" HeaderText="Описание" SortExpression="Description" />
                        <asp:BoundField DataField="DisplayOrder" HeaderText="Порядок отображения" SortExpression="DisplayOrder" ItemStyle-Width="30px"/>
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
                <asp:ObjectDataSource ID="objPortfolio" runat="server" SelectMethod="GetPortfolio"
                    TypeName="UC.BLL.Gallery.PortfolioManager" DeleteMethod="DeletePortfolio">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCurrPortfolio" runat="server" InsertMethod="InsertPortfolio"
                    SelectMethod="GetByPortfolioID" TypeName="UC.BLL.Gallery.PortfolioManager"
                    UpdateMethod="UpdatePortfolio">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwPortfolio" Name="PortfolioID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
