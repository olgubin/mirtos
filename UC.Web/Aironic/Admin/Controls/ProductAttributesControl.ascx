<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAttributesControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ProductAttributesControl" %>
<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SimpleTextBox.ascx" TagName="SimpleTextBox" TagPrefix="mb" %>

<asp:UpdatePanel ID="updpnlProductSpecification" runat="server">
    <ContentTemplate>
                    <asp:GridView ID="gvProductAttributesMapping" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="ProductAttributeMappingID" OnRowDeleting="gvProductAttributesMapping_RowDeleting"
                        OnRowDataBound="gvProductAttributesMapping_RowDataBound" 
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="В краткое описание" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbDisplayInShort" runat="server" Checked='<%# Eval("DisplayInShort") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Характеристика" ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlProductAttribute" runat="server" />
                                    <asp:HiddenField ID="hfProductAttributesMappingID" runat="server" Value='<%# Eval("ProductAttributeMappingID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Значение" ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <mb:SimpleTextBox ID="txtProductAttributeMappingValue" runat="server" Text='<%# Eval("AttributeValue") %>'
                                        ValidationGroup="ProductSpecification" ErrorMessage="Обязательно для заполнения" Width="97%"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtProductAttributesMappingDisplayOrder"
                                        Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                                        RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="ProductSpecification"
                                        MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteProductAttributesMapping" runat="server" CssClass="adminButton"
                                        Text="Удалить" CausesValidation="false" CommandName="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
        <p>
        <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" 
            Text="Обновить" onclick="btnUpdate_Click"/><asp:Label ID="lblAttribute" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
           </p> 
        
        <table class="adminContent">
            <tr>
                <td colspan="2">
                    <b>Добавление новой характеристики товара</b>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Выберите характеристику:
                </td>
                <td class="adminData">
                    <asp:DropDownList class="text" ID="ddlNewProductAttribute" AutoPostBack="False" CssClass="adminInput"
                        runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Значение характеристики:
                </td>
                <td class="adminData">
                    <mb:SimpleTextBox ID="txtNewProductAttributeMappingValue" runat="server" ValidationGroup="NewProductSpecification"
                        ErrorMessage="Значение характеристики обязательно для заполнения" />
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Порядок отображения:
                </td>
                <td class="adminData">
                    <mb:NumericTextBox runat="server" CssClass="adminInput" ID="txtNewProductAttributeMappingDisplayOrder"
                        Value="1" RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                        RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                        MaximumValue="99999" ValidationGroup="NewProductSpecification"></mb:NumericTextBox>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Отображать в кратком описании:
                </td>
                <td class="adminData">
                    <asp:CheckBox ID="cbDisplayInShort" runat="server" Checked="true" />
                </td>
            </tr>                                    
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewProductAttribute" CssClass="adminButton" Text="Добавить характеристику"
                        ValidationGroup="NewProductSpecification" OnClick="btnNewProductAttribute_Click">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>