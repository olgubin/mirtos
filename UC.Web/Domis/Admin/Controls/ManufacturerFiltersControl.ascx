<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManufacturerFiltersControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ManufacturerFiltersControl" %>

<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectFilterControl.ascx" TagName="SelectFilterControl" TagPrefix="mb" %>

<asp:UpdatePanel ID="updpnlRelatedProducts" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfManufacturerID" runat="server" />
        <asp:GridView ID="gvFilterManufacturer" runat="server" AutoGenerateColumns="false"
            DataKeyNames="FilterManufacturerID" OnRowDeleting="gvFilterManufacturer_RowDeleting" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Фильтер" ItemStyle-Width="60%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFilterManufacturer" Text='<%# Eval("Filter.Name") %>'/>
                        <asp:HiddenField ID="hfFilterManufacturerID" runat="server" Value='<%# Eval("FilterManufacturerID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtDisplayOrder"
                            Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Порядок отображения обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" ValidationGroup="gvFilterManufacturer"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteFilterManufacturer" runat="server" CssClass="adminButton"
                            Text="Удалить" CausesValidation="false" CommandName="Delete"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p>
        <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить" onclick="btnUpdate_Click" ValidationGroup="gvFilterManufacturer"/>
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
                        MaximumValue="99999" ValidationGroup="FilterManufacturer"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewFilterManufacturer" CssClass="adminButton" Text="Добавить фильтр" OnClick="btnNewFilterManufacturer_Click" ValidationGroup="FilterManufacturer"/>
                    <asp:Label ID="lblNewFilterManufacturer" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>                