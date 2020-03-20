﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManufacturerDescriptionControl.ascx.cs"
    Inherits="UC.UI.Admin.Controls.ManufacturerDescriptionControl" %>
<%@ Register Src="~/Controls/FileUploader.ascx" TagName="FileUploader" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectArticleControl.ascx" TagName="SelectArticleControl"
    TagPrefix="mb" %>
<asp:DetailsView ID="dvwManufacturer" runat="server" AutoGenerateRows="False" DataSourceID="objCurrManufacturer"
    Height="50px" Width="50%" HeaderText="Бренд/производитель" DataKeyNames="ManufacturerID"
    DefaultMode="Insert" OnItemInserted="dvwManufacturer_ItemInserted" OnItemUpdated="dvwManufacturer_ItemUpdated"
    OnItemCreated="dvwManufacturer_ItemCreated" OnItemCommand="dvwManufacturer_ItemCommand"
    OnItemDeleted="dvwManufacturer_ItemDeleted">
    <FieldHeaderStyle Width="170px" />
    <Fields>
        <asp:BoundField DataField="ManufacturerID" HeaderText="ID" ReadOnly="True" SortExpression="ManufacturerID"
            InsertVisible="False" />
        <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False"
            ReadOnly="True" SortExpression="AddedDate" />
        <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True"
            SortExpression="AddedBy" />
        <asp:CheckBoxField DataField="Published" HeaderText="Отображать" />
        <asp:TemplateField HeaderText="Бренд/производитель" SortExpression="Title">
            <ItemTemplate>
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' MaxLength="256"
                    Width="100%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Описание" SortExpression="Description" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                    Rows="5" TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Сайт производителя" SortExpression="Url" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblUrl" runat="server" Text='<%# Eval("Url") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtUrl" runat="server" Text='<%# Bind("Url") %>' Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Логотип" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Image ID="imgImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText='<%# Eval("Title") %>'
                    Visible='<%# !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageUrl").ToString()) %>' />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>' MaxLength="256"
                    Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Статья" ConvertEmptyStringToNull="true" SortExpression="Importance">
            <ItemTemplate>
                <%# Eval("ArticleID")%>
            </ItemTemplate>
            <EditItemTemplate>
                <mb:SelectArticleControl ID="ddlArticle" runat="server" SelectArticleID='<%# Bind("ArticleID") %>'>
                </mb:SelectArticleControl>
            </EditItemTemplate>
            <InsertItemTemplate>
                <mb:SelectArticleControl ID="ddlArticle" runat="server" SelectArticleID='<%# Bind("ArticleID") %>'>
                </mb:SelectArticleControl>
            </InsertItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Порядок" SortExpression="DisplayOrder">
            <ItemTemplate>
                <asp:Label ID="lblImportance" runat="server" Text='<%# Eval("DisplayOrder") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtImportance" runat="server" Text='<%# Bind("DisplayOrder") %>'
                    MaxLength="256" Width="100%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireImportance" runat="server" ControlToValidate="txtImportance"
                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valImportanceType" runat="server" Operator="DataTypeCheck"
                    Type="Integer" ControlToValidate="txtImportance" Text="Значение должно быть целым числом."
                    ToolTip="Значение должно быть целым числом." Display="Dynamic" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Meta Title" SortExpression="MetaTitle" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblMetaTitle" runat="server" Text='<%# Eval("MetaTitle") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtMetaTitle" runat="server" Text='<%# Bind("MetaTitle") %>' MaxLength="400"
                    Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Meta Description" SortExpression="MetaDescription"
            ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblMetaDescription" runat="server" Text='<%# Eval("MetaDescription") %>'
                    Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtMetaDescription" runat="server" Text='<%# Bind("MetaDescription") %>'
                    Rows="5" TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Meta Keywords" SortExpression="MetaKeywords" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblKeywords" runat="server" Text='<%# Eval("MetaKeywords") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtKeywords" runat="server" Text='<%# Bind("MetaKeywords") %>' Rows="5"
                    TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
            HeaderStyle-BackColor="White">
            <InsertItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" />&nbsp
            </InsertItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ID="ImageButton4" runat="server" SkinID="Delete" CommandName="Delete" />&nbsp
                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" />&nbsp
                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" />&nbsp
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<table style="width: 100%">
    <tr>
        <td style="height: 27px; vertical-align: middle;">
            Ссылка на загруженный рисунок:
        </td>
        <td colspan="2" style="height: 27px; vertical-align: middle">
            <asp:Literal runat="server" ID="lblImgUrl" />
        </td>
    </tr>
    <tr>
        <td style="width: 230px; vertical-align: middle;">
            Загрузить изображение из файла:
        </td>
        <td>
            <asp:FileUpload ID="imgUpload" runat="server" Width="100%" EnableViewState="false" />
        </td>
        <td>
            <asp:Button runat="server" ID="btnFileUpload" Text="Загрузить" OnClick="btnFileUpload_Click"
                CausesValidation="false" />
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="objCurrManufacturer" runat="server" InsertMethod="InsertManufacturer"
    SelectMethod="GetManufacturerByID" TypeName="UC.BLL.Store.ManufacturerManager"
    UpdateMethod="UpdateManufacturer" DeleteMethod="DeleteManufacturer">
    <SelectParameters>
        <asp:ControlParameter ControlID="gvwManufacturers" Name="manufacturerID" PropertyName="SelectedValue"
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
