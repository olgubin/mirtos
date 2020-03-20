<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductView.ascx.cs" Inherits="UC.UI.Controls.ProductView" %>
<%@ Register Src="~/Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="~/Controls/AvailabilityDisplay.ascx" TagName="AvailabilityDisplay" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Product/ProductAttributes.ascx" TagName="ProductAttributes" TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>
<table style="width: 100%">
    <tr>
        <td style="padding-right: 3px">
            <asp:HyperLink runat="server" ID="HyperLink2" NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + ProductID %>'
                ToolTip='<%# Title %>'>
                <asp:Image runat="server" ID="Image1" BorderWidth="1px" GenerateEmptyAlternateText="true"
                    ImageUrl='<%# ImageURL %>' Width="100px" Height="100px" BorderColor="#d7c5ab" /></asp:HyperLink>
            <div class="rait">
                <mb:RatingDisplay runat="server" ID="RatingDisplay1" Value='<%# AverageRating %>' />
            </div>
        </td>
        <td class="producttitle">
            <asp:HyperLink runat="server" ID="lnkProductTitle" Text='<%# Title %>' NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + ProductID %>' />
            <div>
                <asp:Label ID="Label1" runat="server" Text='<%# "Артикул: " + SKU %>' Font-Bold="false" />
            </div>
            <%--            <asp:Panel runat="server" Visible='<%# ManufacturerID==0 ? false : true %>'>
                <span style="font-weight: normal">Производитель: </span>
                <asp:HyperLink runat="server" ID="lnkManTitle" Text='<%# ManufacturerTitle %>' NavigateUrl='<%# "~/BrowseProducts.aspx?ManID=" + ManufacturerID %>' Font-Bold="false" />
            </asp:Panel>--%>
            <div class="prodattr">
                <mb:ProductAttributes runat="server" ID="tblProductAttributes" ProductID='<%# ProductID %>' />
            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="s_prodprice">
            <asp:Panel runat="server" ID="pnlToCart" Visible='<%# UnitPrice > 0 & UnitsInStock > 0 %>'>
                <table>
                    <tr>
                        <th>
                            <%# (this.Page as BasePage).FormatPrice(FinalUnitPrice) %>
                            <asp:Panel runat="server" Visible='<%# DiscountPercentage > 0 %>'>
                                <s>
                                    <%# (this.Page as BasePage).FormatPrice(UnitPrice) %></s>
                            </asp:Panel>
                        </th>
                        <td>
                            <asp:Panel runat="server" ID="pnlAddToCart" Visible='<%# VisisbleAddToCart %>' CssClass="addToCart">
                                <asp:TextBox runat="server" ID="txtQuantity" Text="1" MaxLength="6" Width="30px"
                                    Font-Size="11px"></asp:TextBox>&nbsp
                                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Select"
                                    AlternateText="В корзину" ImageUrl="~/App_Themes/CClimate/images/buy.gif" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlToOrder" Visible='<%# UnitPrice <= 0 || UnitsInStock <= 0 %>'>
                <table>
                    <tr>
                        <th>
                            Товар под заказ
                        </th>
                        <td>
                            <asp:Panel runat="server" ID="pnlAddToOrder" CssClass="addToCart">
                                <asp:TextBox runat="server" ID="txtQuantityOrder" Text="1" MaxLength="6" Width="30px"
                                    Font-Size="11px"></asp:TextBox>&nbsp
                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Select"
                                    AlternateText="Заказать" ImageUrl="~/App_Themes/CClimate/images/to_order.gif" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
