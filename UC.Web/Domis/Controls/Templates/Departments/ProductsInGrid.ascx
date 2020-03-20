<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsInGrid.ascx.cs" Inherits="UC.UI.Controls.ProductsInGrid" %>
<%@ Register Src="~/Controls/FilterBoxControl.ascx" TagName="FilterBoxControl" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Product/ProductView.ascx" TagName="ProductView" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Paging.ascx" TagName="Paging" TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>
<div id="content">
    <mb:FilterBoxControl runat="server" ID="ucFilter" OnFiltered="ucFilter_Filtered"/>
    <table style="width: 100%;">
        <tr>
            <td style="text-align: left; width: 70%;" class="sorting">
                <span>Сортировать по:</span><br />
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
<%--                |
                <asp:LinkButton runat="server" ID="lbtnNew" CommandName="New" OnCommand="Sorting">
                    новизне<asp:Image ID="imgNewAsc" runat="server" SkinID="SortAsc" /><asp:Image ID="imgNewDesc"
                        runat="server" SkinID="SortDesc" /></asp:LinkButton>--%>
            </td>
            <td style="text-align: right; width: 30%;" class="sorting">
                <span>Показывать по:</span><br />
                <asp:LinkButton runat="server" ID="lbtn10" CommandName="10" OnCommand="PageSize"
                    ForeColor="white" BackColor="#ee8d9e">10</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn20" CommandName="20" OnCommand="PageSize">20</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn30" CommandName="30" OnCommand="PageSize">30</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn40" CommandName="40" OnCommand="PageSize">40</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn50" CommandName="50" OnCommand="PageSize">50</asp:LinkButton>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <mb:Paging runat="server" ID="PagingTop" />
    <asp:DataList ID="dlstProducts" EnableTheming="False" runat="server" DataKeyField="ProductID"
        Width="100%" RepeatColumns="1" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"
        OnSelectedIndexChanged="dlstProducts_SelectedIndexChanged" EnableViewState="true">
        <ItemStyle CssClass="product" />
        <%--<AlternatingItemStyle CssClass="productalt" />--%>
        <HeaderStyle Height="1px" BackColor="#e4e4e4" />
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <mb:ProductView runat="server" ID="ProductView" Title='<%# Eval("Title") %>' ProductID='<%# Eval("ProductID") %>'
                ImageURL='<%# String.IsNullOrEmpty(Eval("SmallImageUrl").ToString())?"~/Images/product.gif":Eval("SmallImageUrl") %>'
                DiscountPercentage='<%#Eval("DiscountPercentage")%>' CurrencyID='<%#Eval("CurrencyID")%>' UnitPrice='<%#Eval("Price")%>'
                FinalPrice='<%#Eval("FinalPrice")%>' ShortDescription='<%#Eval("ShortDescription")%>'
                Votes='<%# Eval("Votes") %>' AverageRating='<%# Eval("AverageRating") %>' SKU='<%# Eval("SKU") %>'
                ManufacturerTitle='<%# Eval("Manufacturer.Title") %>' ManufacturerID='<%# Eval("ManufacturerID") %>' UnitsInStock='<%# Eval("UnitsInStock") %>'/>
        </ItemTemplate>
    </asp:DataList><mb:Paging runat="server" ID="PagingBottom" />
    <asp:Literal runat="server" ID="_litLongDescription" Visible="false"/>
</div>
