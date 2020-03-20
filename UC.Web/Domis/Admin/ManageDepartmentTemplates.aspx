<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageDepartmentTemplates.aspx.cs" Inherits="UC.UI.Admin.ManageDepartmentTemplates" Culture="auto"
    UICulture="auto" %>

<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox"
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
                        Управление шаблонами разделов</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:DetailsView ID="dvwDepartmentTemplate" runat="server" AutoGenerateRows="False"
                    DataSourceID="objCurrDepartmentTemplate" Height="50px" Width="50%" HeaderText="Шаблон разделов"
                    OnItemInserted="dvwDepartmentTemplate_ItemInserted" OnItemUpdated="dvwDepartmentTemplate_ItemUpdated"
                    OnItemCommand="dvwDepartmentTemplate_ItemCommand" DataKeyNames="DepartmentTemplateID"
                    DefaultMode="Insert">
                    <FieldHeaderStyle Width="170px" />
                    <Fields>
                        <asp:BoundField DataField="DepartmentTemplateID" HeaderText="ID" ReadOnly="True" SortExpression="DepartmentTemplateID"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="Название" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' MaxLength="256"
                                    Width="99%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireName" runat="server" ControlToValidate="txtName"
                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Путь к шаблону" SortExpression="TemplatePath">
                            <ItemTemplate>
                                <asp:Label ID="lblTemplatePath" runat="server" Text='<%# Eval("TemplatePath") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtTemplatePath" runat="server" Text='<%# Bind("TemplatePath") %>' MaxLength="256"
                                    Width="99%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireTemplatePath" runat="server" ControlToValidate="txtTemplatePath"
                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="Порядок отображения">
                            <ItemTemplate>
                                <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>'
                                    MaxLength="256" Width="99%" />
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
                <asp:GridView ID="gvwDepartmentTemplate" runat="server" AutoGenerateColumns="False"
                    DataSourceID="objDepartmentTemplates" Width="100%" DataKeyNames="DepartmentTemplateID"
                    OnRowDeleted="gvwDepartmentTemplate_RowDeleted" OnRowCreated="gvwDepartmentTemplate_RowCreated"
                    OnSelectedIndexChanged="gvwDepartmentTemplate_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name" />
                        <asp:BoundField DataField="TemplatePath" HeaderText="Путь к шаблону" SortExpression="TemplatePath" />
                        <asp:BoundField DataField="DisplayOrder" HeaderText="Порядок" SortExpression="DisplayOrder" />
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
                <asp:ObjectDataSource ID="objDepartmentTemplates" runat="server" SelectMethod="GetAllDepartmentTemplates"
                    TypeName="UC.BLL.Store.DepartmentTemplateManager" DeleteMethod="DeleteDepartmentTemplate">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCurrDepartmentTemplate" runat="server" InsertMethod="InsertDepartmentTemplate"
                    SelectMethod="GetByDepartmentTemplateID" TypeName="UC.BLL.Store.DepartmentTemplateManager"
                    UpdateMethod="UpdateDepartmentTemplate">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwDepartmentTemplate" Name="DepartmentTemplateID"
                            PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
