<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RefreshParsingProductListing.ascx.cs" Inherits="UC.UI.Controls.RefreshParsingProductListing" %>
<%@ Register Src="../Controls/ParsingProductView.ascx" TagName="ParsingProductView" TagPrefix="mb" %>
<%@ Register Src="../Controls/Paging.ascx" TagName="Paging" TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>
<div id="content">
    <asp:Label runat="server" ID="lblTitle" CssClass="labeltitle" />
    <p>
    </p>
    <asp:LinkButton runat="server" ID="btnRefreshCatalog" OnClick="btnRefreshCatalog_Click">Обновить все товары в БД</asp:LinkButton>
    <table style="width: 100%;">
        <tr>
            <td style="text-align: left; width: 70%;" class="sorting">
                <%--<span>Сортировать по:</span><br />
                <asp:LinkButton runat="server" ID="lbtnTitle" CommandName="Title" OnCommand="Sorting">
                    названию<asp:Image runat="server" ID="imgTitleAsc" SkinID="SortAsc" /><asp:Image
                        runat="server" ID="imgTitleDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnPrice" CommandName="Price" OnCommand="Sorting">
                    цене<asp:Image runat="server" ID="imgPriceAsc" SkinID="SortAsc" /><asp:Image runat="server"
                        ID="imgPriceDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnRating" CommandName="Rating" OnCommand="Sorting">
                    популярности<asp:Image runat="server" ID="imgRatingAsc" SkinID="SortAsc" /><asp:Image
                        runat="server" ID="imgRatingDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnNew" CommandName="New" OnCommand="Sorting">
                    новизне<asp:Image ID="imgNewAsc" runat="server" SkinID="SortAsc" /><asp:Image ID="imgNewDesc"
                        runat="server" SkinID="SortDesc" /></asp:LinkButton>--%>
            </td>
            <td style="text-align: right; width: 30%;" class="sorting">
                <span>Показывать по:</span><br />
                <asp:LinkButton runat="server" ID="lbtn10" CommandName="10" OnCommand="PageSize"
                    ForeColor="white" BackColor="#9aaab1">10</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn20" CommandName="20" OnCommand="PageSize">20</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn30" CommandName="30" OnCommand="PageSize">30</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn40" CommandName="40" OnCommand="PageSize">40</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn50" CommandName="50" OnCommand="PageSize">50</asp:LinkButton></td>
        </tr>
    </table>
    <p>
    </p>
    <mb:Paging runat="server" ID="PagingTop" />
    <asp:DataList ID="dlstProducts" EnableTheming="False" runat="server" DataKeyField="ID"
        Width="100%" RepeatColumns="1" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"
        OnSelectedIndexChanged="dlstProducts_SelectedIndexChanged" OnItemCreated="dlstProducts_ItemCreated" EnableViewState="false">
        <ItemStyle CssClass="product" />
        <HeaderStyle Height="1px" BackColor="#e4e4e4" />
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 50%;">
                        <mb:ParsingProductView runat="server" ID="RefreshProductView"
                            Title = '<%# Eval("Title") %>'
                            NavigateURL = '<%# "~/Admin/RefreshProduct.aspx?CatalogID=" + Eval("CatalogID") + "&ID=" + Eval("ID") %>'
                            DepartmentTitle = '<%#Eval("DepartmentTitle")%>'
                            SKU = '<%#Eval("SKU")%>'
                            Error = '<%# Eval("Error") %>'
                            IsNew = '<%# Eval("IsNew") %>'
                            IsUpdated = '<%# Eval("IsUpdated") %>'
                            IsRestored = '<%# Eval("IsRestored") %>'
                            IsDeleted = '<%# Eval("IsDeleted") %>'
                            ImageURL = '<%# String.IsNullOrEmpty(Eval("SmallImageUrl").ToString())?"~/Images/product.gif":Eval("SmallImageUrl") %>'
                            DiscountPercentage = '<%#Eval("DiscountPercentage")%>'
                            UnitPrice = '<%#Eval("UnitPrice")%>'
                            ShortDescription = '<%#Eval("ShortDescription")%>'
                            />
                    </td>
                    <td style="width: 50%;">
                        <mb:ParsingProductView runat="server" ID="ParsingProductView"
                            Title = '<%# Eval("LinkProduct.Title") %>'
                            NavigateURL = '<%# "~/Admin/RefreshProduct.aspx?CatalogID=" + Eval("CatalogID") + "&ID=" + Eval("ID") %>'
                            DepartmentTitle = '<%#Eval("LinkProduct.DepartmentTitle")%>'
                            SKU = '<%#Eval("LinkProduct.SKU")%>'
                            Error = '<%# Eval("LinkProduct") == null ? "" : Eval("LinkProduct.Error") %>'
                            IsNew = '<%# Eval("LinkProduct") == null ? false : Eval("LinkProduct.IsNew") %>'
                            IsUpdated = '<%# Eval("LinkProduct") == null ? false : Eval("LinkProduct.IsUpdated") %>'
                            IsRestored = '<%# Eval("LinkProduct") == null ? false : Eval("LinkProduct.IsRestored") %>'
                            IsDeleted = '<%# Eval("LinkProduct") == null ? false : Eval("LinkProduct.IsDeleted") %>'
                            ImageURL = '<%# Eval("LinkProduct") == null ? "~/Images/product.gif" : String.IsNullOrEmpty(Eval("LinkProduct.SmallImageUrl").ToString())?"~/Images/product.gif":Eval("LinkProduct.SmallImageUrl") %>'
                            DiscountPercentage = '<%# Eval("LinkProduct") == null ? 0 : Eval("LinkProduct.DiscountPercentage")%>'
                            UnitPrice = '<%# Eval("LinkProduct") == null ? 0.0m : Eval("LinkProduct.UnitPrice")%>'
                            ShortDescription = '<%#Eval("LinkProduct.ShortDescription")%>'
                            />                    
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList><mb:Paging runat="server" ID="PagingBottom"/>
</div>
