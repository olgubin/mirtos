﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDescriptionControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ProductDescriptionControl" %>
<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="mb" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Controls/FileUploader.ascx" TagName="FileUploader" TagPrefix="mb" %>
<%--<%@ Register Src="../Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>--%>

<asp:DetailsView ID="dvwProduct" runat="server" AutoGenerateDeleteButton="True" AutoGenerateRows="False"
    DataKeyNames="ProductID" DataSourceID="objCurrProduct" DefaultMode="Insert" HeaderText="Product Details"
    OnItemCreated="dvwProduct_ItemCreated" OnDataBound="dvwProduct_DataBound" 
    OnItemUpdated="dvwProduct_ItemUpdated" OnItemUpdating="dvwProduct_ItemUpdating">
    <FieldHeaderStyle Width="108px" />
    <Fields>
        <asp:BoundField DataField="ProductID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
            SortExpression="ProductID"/>
        <asp:BoundField DataField="AddedDate" HeaderText="Добавлено" InsertVisible="False"
            ReadOnly="True" SortExpression="AddedDate" HtmlEncode="False" DataFormatString="{0:f}"/>
        <asp:BoundField DataField="AddedBy" HeaderText="Добавил" InsertVisible="False" ReadOnly="True"
            SortExpression="AddedBy" />
        <asp:BoundField DataField="Votes" HeaderText="Голосов" InsertVisible="False" ReadOnly="True"
            SortExpression="Votes"/>
        <asp:BoundField DataField="AverageRating" HeaderText="Рейтинг" InsertVisible="False"
            HtmlEncode="False" DataFormatString="{0:N2}" ReadOnly="True" SortExpression="AverageRating"/>
        <asp:CheckBoxField DataField="Visible" HeaderText="Отображать" />
        <asp:TemplateField HeaderText="Бренд" SortExpression="ManufacturerID">
            <ItemTemplate>
                <asp:Label ID="lblManufacturer" runat="server" Text='<%# Eval("ManufacturerTitle") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlManufacturers" runat="server" DataSourceID="objManufacturers"
                    AutoPostBack="False" DataTextField="Title" DataValueField="ManufacturerID" AppendDataBoundItems="True"
                    SelectedValue='<%# Bind("ManufacturerID") %>' Width="100%">
                    <asp:ListItem Text="" Value="0" />
                </asp:DropDownList>
                <asp:ObjectDataSource ID="objManufacturers" runat="server" SelectMethod="GetManufacturers"
                    TypeName="UC.BLL.Store.ManufacturerManager"></asp:ObjectDataSource>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Тип товара" SortExpression="ProductTypeID">
            <ItemTemplate>
                <asp:Label ID="lblProductType" runat="server" Text='<%# Eval("ProductType.Type") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlProductTypes" runat="server" DataSourceID="objProductTypes"
                    AutoPostBack="False" DataTextField="Type" DataValueField="ProductTypeID" AppendDataBoundItems="True"
                    SelectedValue='<%# Bind("ProductTypeID") %>' Width="100%">
                    <asp:ListItem Text="" Value="0" />
                </asp:DropDownList>
                <asp:ObjectDataSource ID="objProductTypes" runat="server" SelectMethod="GetProductTypes"
                    TypeName="UC.BLL.Store.ProductTypeManager"></asp:ObjectDataSource>
            </EditItemTemplate>
        </asp:TemplateField>            
        <asp:TemplateField HeaderText="Модель " SortExpression="Model">
            <ItemTemplate>
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Model") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Model") %>' Width="100%"
                    MaxLength="256"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                    SetFocusOnError="True" Text="Заголовок обязателен." ToolTip="Заголовок обязателен."
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Краткое описание" SortExpression="ShortDescription">
            <ItemTemplate>
                <asp:Label ID="lblShortDescription" runat="server" Text='<%# Eval("ShortDescription") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <FCKeditorV2:FCKeditor ID="txtShortDescription" runat="server" Value='<%# Bind("ShortDescription") %>'
                    Height="200px" Width="100%" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Полное описание" SortExpression="LongDescription">
            <ItemTemplate>
                <asp:Label ID="lblLongDescription" runat="server" Text='<%# Eval("LongDescription") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <FCKeditorV2:FCKeditor ID="txtLongDescription" runat="server" Value='<%# Bind("LongDescription") %>'
                    Height="600px" Width="100%" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Артикул" SortExpression="SKU">
            <ItemTemplate>
                <asp:Label ID="lblSKU" runat="server" Text='<%# Eval("SKU") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtSKU" runat="server" Text='<%# Bind("SKU") %>' Width="100%" MaxLength="256"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        
        
        <asp:TemplateField HeaderText="Валюта" SortExpression="CurrencyID">
            <ItemTemplate>
                <asp:Label ID="lblCurrency" runat="server" Text='<%# Eval("Currency.Name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlCurrencues" runat="server" DataSourceID="objCurrencies"
                    AutoPostBack="False" DataTextField="Name" DataValueField="CurrencyID" AppendDataBoundItems="True"
                    SelectedValue='<%# Bind("CurrencyID") %>' Width="100%">
                    <asp:ListItem Text="" Value="0" />
                </asp:DropDownList>
                <asp:ObjectDataSource ID="objCurrencies" runat="server" SelectMethod="GetCurrencies"
                    TypeName="UC.BLL.Store.CurrencyManager"></asp:ObjectDataSource>
            </EditItemTemplate>
        </asp:TemplateField>        
        
        
        
        <asp:TemplateField HeaderText="Цена" SortExpression="UnitPrice">
            <ItemTemplate>
                <asp:Label ID="lblUnitPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>' Width="100%"
                    MaxLength="256" meta:resourcekey="txtUnitPriceResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireUnitPrice" runat="server" ControlToValidate="txtUnitPrice"
                    SetFocusOnError="True" Text="The Unit Price field is required." ToolTip="The Unit Price field is required."
                    Display="Dynamic" meta:resourcekey="valRequireUnitPriceResource1"></asp:RequiredFieldValidator>
                <%--               <asp:CompareValidator ID="valUnitPriceType" runat="server" Operator="DataTypeCheck" Type="Currency"
          ControlToValidate="txtUnitPrice" Text="The Unit Price must be a double."
          ToolTip="The Unit Price must be a double." Display="Dynamic" meta:resourcekey="valUnitPriceTypeResource1" />--%>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Скидка %" SortExpression="MarginPercentage">
            <ItemTemplate>
                <asp:Label ID="lblMarginPercentage" runat="server" Text='<%# Eval("MarginPercentage") %>'/>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtMarginPercentage" runat="server" Text='<%# Bind("MarginPercentage") %>' Width="100%" MaxLength="256" />
                <asp:RequiredFieldValidator ID="valRequireMarginPercentage" runat="server" ControlToValidate="txtMarginPercentage"
                    SetFocusOnError="True" Text="Обязательно для заполнения" ToolTip="Обязательно для заполнения"
                    Display="Dynamic" />
                <asp:CompareValidator ID="valMarginPercentageType" runat="server" Operator="DataTypeCheck"
                    Type="Integer" ControlToValidate="txtMarginPercentage" Text="Значение долждно быть целым числом"
                    ToolTip="Значение долждно быть целым числом" Display="Dynamic" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Цена дня %" SortExpression="DiscountPercentage" meta:resourcekey="TemplateFieldResource6">
            <ItemTemplate>
                <asp:Label ID="lblDiscountPercentage" runat="server" Text='<%# Eval("DiscountPercentage") %>'
                    meta:resourcekey="lblDiscountPercentageResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDiscountPercentage" runat="server" Text='<%# Bind("DiscountPercentage") %>'
                    Width="100%" MaxLength="256" meta:resourcekey="txtDiscountPercentageResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireDiscountPercentage" runat="server" ControlToValidate="txtDiscountPercentage"
                    SetFocusOnError="True" Text="The Discount Percentage field is required." ToolTip="The Discount Percentage field is required."
                    Display="Dynamic" meta:resourcekey="valRequireDiscountPercentageResource1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valDiscountPercentageType" runat="server" Operator="DataTypeCheck"
                    Type="Integer" ControlToValidate="txtDiscountPercentage" Text="The Discount Percentage must be an integer."
                    ToolTip="The Discount Percentage must be an integer." Display="Dynamic" meta:resourcekey="valDiscountPercentageTypeResource1" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Units in Stock" SortExpression="UnitsInStock" meta:resourcekey="TemplateFieldResource7">
            <ItemTemplate>
                <asp:Label ID="lblUnitsInStock" runat="server" Text='<%# Eval("UnitsInStock", "{0:N2}") %>'
                    meta:resourcekey="lblUnitsInStockResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtUnitsInStock" runat="server" Text='<%# Bind("UnitsInStock") %>'
                    Width="100%" MaxLength="256" meta:resourcekey="txtUnitsInStockResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireUnitsInStock" runat="server" ControlToValidate="txtUnitsInStock"
                    SetFocusOnError="True" Text="The Discount Units In Stock field is required."
                    ToolTip="The Units In Stock field is required." Display="Dynamic" meta:resourcekey="valRequireUnitsInStockResource1"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valUnitsInStockType" runat="server" Operator="DataTypeCheck"
                    Type="Integer" ControlToValidate="txtUnitsInStock" Text="The Units In Stock must be an integer."
                    ToolTip="The Units In Stock must be an integer." Display="Dynamic" meta:resourcekey="valUnitsInStockTypeResource1" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Small Image Url" SortExpression="SmallImageUrl" meta:resourcekey="TemplateFieldResource8">
            <ItemTemplate>
                <asp:Label ID="lblSmallImageUrl" runat="server" Text='<%# Eval("SmallImageUrl") %>'
                    meta:resourcekey="lblSmallImageUrlResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtSmallImageUrl" runat="server" Text='<%# Bind("SmallImageUrl") %>'
                    Width="100%" MaxLength="256" meta:resourcekey="txtSmallImageUrlResource1"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Full Image Url" SortExpression="FullImageUrl" meta:resourcekey="TemplateFieldResource9">
            <ItemTemplate>
                <asp:Label ID="lblFullImageUrl" runat="server" Text='<%# Eval("FullImageUrl") %>'
                    meta:resourcekey="lblFullImageUrlResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtFullImageUrl" runat="server" Text='<%# Bind("FullImageUrl") %>'
                    Width="100%" MaxLength="256" meta:resourcekey="txtFullImageUrlResource1"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
            HeaderStyle-BackColor="White">
            <InsertItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" />
                &nbsp;
            </InsertItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" />
                &nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" />
                &nbsp;
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>
<asp:ObjectDataSource ID="objCurrProduct" runat="server" DeleteMethod="DeleteProduct"
    InsertMethod="InsertProduct" SelectMethod="GetByProductID" TypeName="UC.BLL.Store.ProductManager"
    UpdateMethod="UpdateProduct" OnInserted="objCurrProduct_Inserted">
    <DeleteParameters>
        <asp:Parameter Name="ProductID" Type="Int32" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="ProductID" Type="Int32" />
        <%--<asp:Parameter Name="title" Type="String" ConvertEmptyStringToNull="False" />--%>
        <asp:Parameter Name="ProductTypeID" Type="Int32" />
        <asp:Parameter Name="model" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="manufacturerID" Type="Int32" />
        <asp:Parameter Name="shortdescription" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="longdescription" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="sku" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="unitPrice" Type="Decimal" />
        <asp:Parameter Name="discountPercentage" Type="Int32" />
        <asp:Parameter Name="marginPercentage" Type="Int32" />
        <asp:Parameter Name="unitsInStock" Type="Int32" />
        <asp:Parameter Name="smallImageUrl" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="fullImageUrl" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="Visible" Type="Boolean"/>
    </UpdateParameters>
    <SelectParameters>
        <asp:QueryStringParameter Name="productID" QueryStringField="ID" Type="Int32" />
    </SelectParameters>
    <InsertParameters>
        <%--<asp:Parameter Name="title" Type="String" ConvertEmptyStringToNull="False" />--%>
        <asp:Parameter Name="ProductTypeID" Type="Int32" />
        <asp:Parameter Name="model" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="manufacturerID" Type="Int32" />
        <asp:Parameter Name="shortdescription" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="longdescription" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="sku" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="unitPrice" Type="Decimal" />
        <asp:Parameter Name="discountPercentage" Type="Int32" />
        <asp:Parameter Name="marginPercentage" Type="Int32" />
        <asp:Parameter Name="unitsInStock" Type="Int32" />
        <asp:Parameter Name="smallImageUrl" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="fullImageUrl" Type="String" ConvertEmptyStringToNull="False" />
        <asp:Parameter Name="visible" Type="Boolean"/>
    </InsertParameters>
</asp:ObjectDataSource>
<p>
</p>
<table style="width: 100%">
    <tr>
        <td style="width: 230px; vertical-align: middle;">
            <asp:Literal ID="Literal1" runat="server" Text="Загрузить изображение по ссылке: " />
        </td>
        <td>
            <asp:TextBox ID="txtImageUrl" runat="server" Width="100%" MaxLength="256"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 230px; vertical-align: middle;">
            <asp:Literal ID="Literal2" runat="server" Text="Загрузить изображение из файла: " />
        </td>
        <td>
            <asp:FileUpload ID="imgUpload" runat="server" Width="100%" />
        </td>
    </tr>
</table>