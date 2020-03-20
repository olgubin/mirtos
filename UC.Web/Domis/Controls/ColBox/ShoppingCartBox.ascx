<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCartBox.ascx.cs"
    Inherits="UC.UI.Controls.ShoppingCartBox" EnableViewState="false" %>
<%@ Import Namespace="UC.UI" %>
<div class="box">
<div style="position: relative;">
    <div class="boxtop_middle">
    </div>
    <div class="boxtop_left">
    </div>
    <div class="boxtop_right">
    </div>
</div>
<div class="boxmiddle">
    <div class="boxmiddle">
        <table cellpadding="0">
            <tr>
                <td class="boxmiddle_left">
                </td>
                <td>
                    <div class="boxmiddle_middle">
                        <div class="boxtitle">
                            Корзина</div>
                        <div class="shoppingcartbox">
                            <div id="shoppingcartboxtotal">
                                <div>
                                    <asp:HyperLink runat="server" NavigateUrl="~/ShoppingCart.aspx" ToolTip="Перейти в корзину">
                                        <asp:Image ID="Image1" runat="server" SkinID="ShoppingCartBox" /></asp:HyperLink>
                                </div>
                                <asp:Literal runat="server" ID="lblTotalHeader" Text="Товаров: " /><span><asp:Literal
                                    runat="server" ID="lblTotal" /></span><br />
                                <asp:Literal runat="server" ID="lblSubtotalHeader" Text="На сумму: " /><span><asp:Literal
                                    runat="server" ID="lblSubtotal" /></span>
                            </div>
                            <div class="shoppingcartboxcontent">
                                <asp:Repeater runat="server" ID="repOrderItems">
                                    <ItemTemplate>
                                        <div id="article">
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ShowProduct.aspx?ID="+Eval("ID") %>'
                                                ToolTip='<%# Eval("Title") %>'>
                                                <asp:Image ID="Image2" runat="Server" SkinID="ShoppingCartArticle" /></asp:HyperLink><div>
                                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/ShowProduct.aspx?ID="+Eval("ID") %>'
                                                        ToolTip='<%# Eval("Title") %>'><%# Eval("Title") %></asp:HyperLink><br />
                                                    <span class="price">Цена:
                                                        <%# (this.Page as BasePage).FormatPrice(Eval("UnitPrice"))%>&nbsp;&nbsp;Кол:
                                                        <%# Eval("Quantity")%></span></div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Panel runat="server" ID="panLinkShoppingCart" CssClass="toshoppingcart">
                                    <asp:HyperLink runat="server" ID="lnkShoppingCart" NavigateUrl="~/ShoppingCart.aspx"
                                        ToolTip="Оформить заказ"><asp:Image runat="server" SkinID="ToShoppingCart" /></asp:HyperLink><br />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </td>
                <td class="boxmiddle_right">
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="boxbottom">
    <div class="boxbottom_middle">
    </div>
    <div class="boxbottom_left">
    </div>
    <div class="boxbottom_right">
    </div>
</div>
</div>