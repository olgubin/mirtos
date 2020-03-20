<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDepartmentsControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ProductDepartmentsControl" %>
<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectDepartmentControl.ascx" TagName="SelectDepartmentControl" TagPrefix="mb" %>

<asp:UpdatePanel ID="updpnlRelatedProducts" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvProductDepartmentMapping" runat="server" AutoGenerateColumns="false"
            DataKeyNames="ProductDepartmentID" OnRowDeleting="gvProductDepartmentMapping_RowDeleting" Width="100%" 
            OnRowDataBound="gvProductDepartmentMapping_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Раздел" ItemStyle-Width="60%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblProductDepartment" />
                        <asp:HiddenField ID="hfProductDepartmentMappingID" runat="server" Value='<%# Eval("ProductDepartmentID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtProductDepartmentMappingDisplayOrder"
                            Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="ProductSpecification"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteProductDepartmentMapping" runat="server" CssClass="adminButton"
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
                    <b>Добавление раздела</b>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Раздел:
                </td>
                <td class="adminData">
                    <mb:SelectDepartmentControl ID="ddlDepartments" runat="server" SelectedDepartmentId='<%# Bind("DepartmentID") %>'/>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Порядок отображения:
                </td>
                <td class="adminData">
                    <mb:NumericTextBox runat="server" CssClass="adminInput" ID="txtNewProductDepartmentMappingDisplayOrder"
                        Value="1" RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                        RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                        MaximumValue="99999"></mb:NumericTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewProductDepartment" CssClass="adminButton" Text="Добавить раздел" OnClick="btnNewProductDepartment_Click"/>
                    <asp:Label ID="lblNewProductDepartment" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>                