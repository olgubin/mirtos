<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRelatedControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ProductRelatedControl" %>
<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectProductControl.ascx" TagName="SelectProductControl" TagPrefix="mb" %>

<asp:UpdatePanel ID="updpnlRelatedProducts" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvProductRelated" runat="server" AutoGenerateColumns="false"
            DataKeyNames="ProductRelatedID" OnRowDeleting="gvProductRelated_RowDeleting" Width="100%" OnRowDataBound="gvProductRelated_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Раздел" ItemStyle-Width="60%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblProductRelated" Text='<%# Eval("Product2.Title") %>'/>
                        <asp:HiddenField ID="hfProductRelatedID" runat="server" Value='<%# Eval("ProductRelatedID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtProductRelatedDisplayOrder"
                            Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="ProductSpecification"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Image runat="server" ID="imgVisible" ImageUrl="~/Images/vis.gif" />
                     </ItemTemplate>         
                     <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" />         
                  </asp:TemplateField>                 
                <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteProductRelated" runat="server" CssClass="adminButton"
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
                    <b>Добавление товара</b>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Товар:
                </td>
                <td class="adminData">
                    <mb:SelectProductControl ID="ddlProducts" runat="server" SelectedProductId='<%# Bind("ProductID") %>'/>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Порядок отображения:
                </td>
                <td class="adminData">
                    <mb:NumericTextBox runat="server" CssClass="adminInput" ID="txtNewProductRelatedDisplayOrder"
                        Value="1" RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                        RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                        MaximumValue="99999"></mb:NumericTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewProductRelated" CssClass="adminButton" Text="Добавить товар" OnClick="btnNewProductRelated_Click"/>
                    <asp:Label ID="lblNewProductRelated" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>            
    </ContentTemplate>
</asp:UpdatePanel>