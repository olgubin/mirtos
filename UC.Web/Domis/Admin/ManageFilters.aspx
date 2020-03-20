<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageFilters.aspx.cs" Inherits="UC.UI.Admin.ManageFilters" Culture="auto"
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
                        Управление фильтрами</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel ID="updpnlManageDepartment" runat="server">
            <ContentTemplate>
                <asp:GridView ID="gvwFilters" runat="server" AutoGenerateColumns="False" DataSourceID="objFilters"
                    Width="100%" DataKeyNames="FilterID" OnRowCreated="gvwFilters_RowCreated" OnRowDeleted="gvwFilters_RowDeleted"
                    OnSelectedIndexChanged="gvwFilters_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="FilterID" HeaderText="ID" ReadOnly="True">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Название фильтра">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать фильтр"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить фильтр"
                            ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        Нет фильтров для отображения</EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="objFilters" runat="server" SelectMethod="GetFilters" TypeName="UC.BLL.Store.FilterManager"
                    DeleteMethod="DeleteFilter">
                    <DeleteParameters>
                        <asp:Parameter Name="FilterID" Type="Int32" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <p />
                <table width="100%">
                    <tr>
                        <td valign="top" width="40%">
                            <asp:DetailsView ID="dvwFilter" runat="server" AutoGenerateRows="False" DataSourceID="objCurrFilter"
                                Width="50%" HeaderText="Фильтр" DataKeyNames="FilterID" DefaultMode="Insert"
                                OnItemCommand="dvwFilter_ItemCommand" OnItemInserted="dvwFilter_ItemInserted"
                                OnItemUpdated="dvwFilter_ItemUpdated">
                                <FieldHeaderStyle Width="137px" />
                                <Fields>
                                    <asp:BoundField DataField="FilterID" HeaderText="ID" ReadOnly="True" InsertVisible="False" />
                                    <asp:TemplateField HeaderText="Название фильтра *">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' MaxLength="256"
                                                Width="98%"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="valRequireQuestion" runat="server" ControlToValidate="txtName"
                                                SetFocusOnError="True" Text="Название обязательно для заполнения." ToolTip="Название обязательно для заполнения."
                                                Display="Dynamic" ValidationGroup="dvwFilter"/>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
                                        HeaderStyle-BackColor="White">
                                        <InsertItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" ValidationGroup="dvwFilter"/>&nbsp
                                        </InsertItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" ValidationGroup="dvwFilter"/>&nbsp
                                            <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" ValidationGroup="dvwFilter"/>&nbsp
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Fields>
                            </asp:DetailsView>
                            <asp:ObjectDataSource ID="objCurrFilter" runat="server" InsertMethod="InsertFilter"
                                SelectMethod="GetByFilterID" TypeName="UC.BLL.Store.FilterManager" UpdateMethod="UpdateFilter">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="gvwFilters" Name="FilterID" PropertyName="SelectedValue"
                                        Type="Int32" />
                                </SelectParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="FilterID" Type="Int32" />
                                    <asp:Parameter Name="Name" Type="String" />
                                </UpdateParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Name" Type="String" />
                                </InsertParameters>
                            </asp:ObjectDataSource>
                        </td>
                        <td valign="top" width="60%">
                            <asp:Panel runat="server" ID="panFilterCriteria" Visible="False" Width="100%">
                                <asp:GridView ID="gvwFilterCriteria" runat="server" AutoGenerateColumns="False" DataSourceID="objFilterCriteria"
                                    DataKeyNames="FilterCriteriaID" Width="100%" OnRowCreated="gvwFilterCriteria_RowCreated"
                                    OnRowDeleted="gvwFilterCriteria_RowDeleted" OnSelectedIndexChanged="gvwFilterCriteria_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="Criterion" HeaderText="Критерий фильтрации">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfFilterCriteriaID" runat="server" Value='<%# Eval("FilterCriteriaID") %>' />
                                                <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtFilterCriteriaDisplayOrder"
                                                    Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                                                    RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="gvwFilterCriteria"
                                                    MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать критерий"
                                            ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить критерий"
                                            ShowDeleteButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Нет критериев фильтрации для отображения</EmptyDataTemplate>
                                </asp:GridView>
                                <p>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить"
                                        OnClick="btnUpdate_Click" ValidationGroup="gvwFilterCriteria"/><asp:Label ID="lblAttribute" runat="server" EnableViewState="false"
                                            ForeColor="Red" Font-Size="Small"></asp:Label>
                                </p>
                                <asp:ObjectDataSource ID="objFilterCriteria" runat="server" DeleteMethod="DeleteFilterCriteria"
                                    SelectMethod="GetFilterCriteriaByFilterID" TypeName="UC.BLL.Store.FilterCriteriaManager">
                                    <DeleteParameters>
                                        <asp:Parameter Name="FilterCriteriaID" Type="Int32" />
                                    </DeleteParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvwFilters" Name="FilterID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <p>
                                </p>
                                <asp:DetailsView ID="dvwFilterCriteria" runat="server" AutoGenerateRows="False" DataSourceID="objCurrFilterCriteria"
                                    Width="100%" HeaderText="Критерий фильтрации" DataKeyNames="FilterCriteriaID"
                                    DefaultMode="Insert" OnItemCommand="dvwFilterCriteria_ItemCommand" OnItemInserted="dvwFilterCriteria_ItemInserted"
                                    OnItemUpdated="dvwFilterCriteria_ItemUpdated">
                                    <FieldHeaderStyle Width="170px" />
                                    <Fields>
                                        <asp:BoundField DataField="FilterCriteriaID" HeaderText="ID" ReadOnly="True" InsertVisible="False" />
                                        <asp:TemplateField HeaderText="Критерий *">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCriterion" runat="server" Text='<%# Eval("Criterion") %>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtCriterion" runat="server" Text='<%# Bind("Criterion") %>' MaxLength="256"
                                                    Width="98%" />
                                                <asp:RequiredFieldValidator ID="valRequireCriterion" runat="server" ControlToValidate="txtCriterion"
                                                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                                                    Display="Dynamic" ValidationGroup="dvwFilterCriteria"/>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Порядок отображения">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder") %>' />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>'
                                                    MaxLength="256" Width="98%" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
                                            HeaderStyle-BackColor="White">
                                            <InsertItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" ValidationGroup="dvwFilterCriteria"/>&nbsp
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" ValidationGroup="dvwFilterCriteria"/>&nbsp
                                                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" ValidationGroup="dvwFilterCriteria"/>&nbsp
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Fields>
                                </asp:DetailsView>
                                <asp:ObjectDataSource ID="objCurrFilterCriteria" runat="server" InsertMethod="InsertFilterCriteria"
                                    SelectMethod="GetByFilterCriteriaID" TypeName="UC.BLL.Store.FilterCriteriaManager" UpdateMethod="UpdateFilterCriteria">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvwFilterCriteria" Name="FilterCriteriaID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="FilterCriteriaID" Type="Int32" />
                                        <asp:ControlParameter ControlID="gvwFilters" Name="FilterID" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:Parameter Name="Criterion" Type="String" />
                                        <asp:Parameter Name="DisplayOrder" Type="Int32" />
                                    </UpdateParameters>
                                    <InsertParameters>
                                        <asp:ControlParameter ControlID="gvwFilters" Name="FilterID" PropertyName="SelectedValue" Type="Int32" />
                                        <asp:Parameter Name="Criterion" Type="String"/>
                                        <asp:Parameter Name="DisplayOrder" Type="Int32" DefaultValue="0"/>
                                    </InsertParameters>
                                </asp:ObjectDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
