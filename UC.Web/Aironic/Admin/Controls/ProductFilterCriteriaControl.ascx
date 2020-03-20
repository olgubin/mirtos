<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductFilterCriteriaControl.ascx.cs" Inherits="UC.UI.Admin.Controls.ProductFilterCriteriaControl" %>
<%@ Register Src="~/Admin/Controls/SelectFilterCriteriaControl.ascx" TagName="SelectFilterCriteriaControl" TagPrefix="mb" %>
<asp:UpdatePanel ID="updpnlFilterCriteriaProduct" runat="server">
    <ContentTemplate>
        <asp:GridView ID="gvFilterCriteriaProduct" runat="server" AutoGenerateColumns="false"
            DataKeyNames="FilterCriteriaProductID" OnRowDeleting="gvFilterCriteriaProduct_RowDeleting" Width="100%" 
            OnRowDataBound="gvFilterCriteriaProduct_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Критерии фильтрации" ItemStyle-Width="60%">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFilterCriteriaProduct" />
                        <asp:HiddenField ID="hfFilterCriteriaProductID" runat="server" Value='<%# Eval("FilterCriteriaProductID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Удалить" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteFilterCriteriaProduct" runat="server" CssClass="adminButton"
                            Text="Удалить" CausesValidation="false" CommandName="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p/>
        <table class="adminContent">
            <tr>
                <td colspan="2">
                    <b>Добавление критерия</b>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Критерий:
                </td>
                <td class="adminData">
                    <mb:SelectFilterCriteriaControl ID="ddlFilterCriteria" runat="server" SelectedFilterCriteriaId='<%# Bind("FilterCriteriaID") %>'/>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <asp:Button runat="server" ID="btnNewFilterCriteriaProduct" CssClass="adminButton" Text="Добавить раздел" OnClick="btnNewFilterCriteriaProduct_Click"/>
                    <asp:Label ID="lblNewFilterCriteriaProduct" runat="server" EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>                