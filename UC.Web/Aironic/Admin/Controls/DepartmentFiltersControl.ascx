<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentFiltersControl.ascx.cs" Inherits="UC.UI.Admin.Controls.DepartmentFiltersControl" %>

<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectFilterControl.ascx" TagName="SelectFilterControl" TagPrefix="mb" %>

<asp:UpdatePanel ID="updpnlRelatedProducts" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDepartmentID" runat="server" />
        <asp:GridView ID="gvFilterDepartment" runat="server" AutoGenerateColumns="false"
            DataKeyNames="FilterDepartmentID" OnRowDeleting="gvFilterDepartment_RowDeleting" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Фильтер" ItemStyle-Width="60%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFilterDepartment" Text='<%# Eval("Filter.Name") %>'/>
                        <asp:HiddenField ID="hfFilterDepartmentID" runat="server" Value='<%# Eval("FilterDepartmentID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtDisplayOrder"
                            Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="gvFilterDepartment"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteFilterDepartment" runat="server" CssClass="adminButton"
                            Text="Удалить" CausesValidation="false" CommandName="Delete"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p>
        <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить" onclick="btnUpdate_Click" ValidationGroup="gvFilterDepartment"/>
        <asp:Label ID="lblAttribute" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"/>
           </p> 
        
        <table class="adminContent">
            <tr>
                <td colspan="2">
                    <b>Добавление фильтра</b>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Фильтер:
                </td>
                <td class="adminData">
                    <mb:SelectFilterControl ID="ddlFilters" runat="server" SelectedFilterId='<%# Bind("FilterID") %>'/>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Порядок отображения:
                </td>
                <td class="adminData">
                    <mb:NumericTextBox runat="server" CssClass="adminInput" ID="txtNewDisplayOrder"
                        Value="1" RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                        RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                        MaximumValue="99999" ValidationGroup="FilterDepartment"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewFilterDepartment" CssClass="adminButton" Text="Добавить фильтр" OnClick="btnNewFilterDepartment_Click" ValidationGroup="FilterDepartment"/>
                    <asp:Label ID="lblNewFilterDepartment" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>                