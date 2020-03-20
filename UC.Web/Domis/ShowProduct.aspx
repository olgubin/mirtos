<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="ShowProduct.aspx.cs" Inherits="UC.UI.ShowProduct"
    Culture="auto" UICulture="auto" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="./Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="./Controls/AvailabilityDisplay.ascx" TagName="AvailabilityDisplay" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Product/ProductAttributes.ascx" TagName="ProductAttributes" TagPrefix="mb" %>
<%@ Register Src="Controls/CurrencyControl.ascx" TagName="CurrencyControl" TagPrefix="mb" %>
<%@ Register Src="Controls/404.ascx" TagName="Control404" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <mb:Control404 runat="server" ID="ctrl404" />
        <asp:Panel runat="server" ID="pnlContent">
            <h2>
                <asp:Literal runat="server" ID="lblTitle" /></h2>
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="text-align: right;">
                        <asp:Panel runat="server" ID="panEditProduct">
                            <asp:ImageButton runat="server" ID="btnProductCopy" CausesValidation="false" AlternateText="Копировать товар"
                                ImageUrl="~/Images/copy.gif" OnClick="btnProductCopy_Click" />&nbsp;
                            <asp:HyperLink runat="server" ID="lnkEditProduct" ImageUrl="~/Images/Edit.gif" ToolTip="Редактировать товар"
                                NavigateUrl="~/Admin/AddEditProduct.aspx?ID={0}" meta:resourcekey="lnkEditProductResource1" />&nbsp;
                            <asp:ImageButton runat="server" ID="btnDelete" CausesValidation="false" AlternateText="Удалить товар"
                                ImageUrl="~/Images/Delete.gif" OnClientClick="if (confirm('Подтвердите удаление товара?') == false) return false;"
                                OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1" />
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table style="width: 100%">
                <tr>
                    <td style="width: 287px">
                        <asp:Image runat="Server" ID="imgProduct" ImageUrl="~/Images/prod_back.gif" SkinID="FullProductImage" />
                        <p>
                            <asp:Literal ID="litVoiteQuetion" runat="server" Text="Ваша оценка товара?" />
                            <asp:DropDownList runat="server" ID="ddlRatings">
                                <asp:ListItem Value="1" Text="1" />
                                <asp:ListItem Value="2" Text="2" />
                                <asp:ListItem Value="3" Text="3" />
                                <asp:ListItem Value="4" Text="4" />
                                <asp:ListItem Value="5" Text="5" Selected="true" />
                            </asp:DropDownList>
                            <asp:Button runat="server" ID="btnRate" Text="Голосовать" OnClick="btnRate_Click"
                                CausesValidation="false" />
                            <asp:Literal runat="server" ID="lblUserRating" Visible="False" Text="Ваша оценка товара {0}" />
                        </p>
                    </td>
                    <td>
                        <mb:RatingDisplay runat="server" ID="mbRating" />
                        <p>
                            <asp:Literal runat="server" ID="lblSKU" /></p>
                        <p>
                            <asp:Panel ID="panManufacturer" runat="server">
                                Производитель:
                                <asp:HyperLink runat="server" ID="lnkManTitle" /></asp:Panel>
                        </p>
                        <div class="prodattr">
                            <mb:ProductAttributes runat="server" ID="tblProductAttributes" ProductID='<%# ProductID %>'
                                IsShortDescription="false" CssClass="rowaltcolor" Padding="1px" />
                        </div>
                        <div style="padding-top: 17px;">
                            <asp:Panel runat="server" ID="pnlToCart">
                                <asp:Panel ID="pnDiscount" runat="server" CssClass="discount">
                                    <%--<asp:Label runat="server" ID="lblDiscount" />--%></asp:Panel>
                                <table>
                                    <tr>
                                        <td class="productprice" style="padding-right: 7px; font-size: larger;">
                                            <asp:Literal runat="server" ID="lblPrice" />
                                            <asp:Panel ID="pnlDiscountedPrice" runat="server">
                                                <asp:Literal runat="server" ID="lblDiscountedPrice"><s>{0}</s></asp:Literal><br />
                                            </asp:Panel>
                                        </td>
                                        <td class="productbuy">
                                            <asp:TextBox runat="server" ID="txtQuantity" Text="1" MaxLength="6" Width="30px"
                                                Font-Size="11px"></asp:TextBox>&nbsp
                                            <asp:ImageButton runat="server" ID="btnAddToCart" SkinID="Buy" CausesValidation="false"
                                                OnClick="btnAddToCart_Click" AlternateText="В корзину" ImageAlign="AbsMiddle" />
                                        </td>
                                        <td style="padding-left: 7px; vertical-align: middle">
                                            <mb:CurrencyControl ID="Currency" runat="server" Caption_Visible="false" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel runat="server" ID="pnlToOrder">
                                <table>
                                    <tr>
                                        <td class="productprice" style="padding-right: 7px; font-size: larger;">
                                            Товар под заказ
                                        </td>
                                        <td class="productbuy">
                                            <asp:TextBox runat="server" ID="txtQuantityOrder" Text="1" MaxLength="6" Width="30px"
                                                Font-Size="11px"></asp:TextBox>&nbsp
                                            <asp:ImageButton ID="btnToOrder" runat="server" CausesValidation="false" OnClick="btnAddToCart_Click"
                                                AlternateText="Заказать" ImageUrl="~/App_Themes/CClimate/images/to_order.gif" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Literal runat="server" ID="lblDescription" />
            </asp:Panel>
    </div>
</asp:Content>
