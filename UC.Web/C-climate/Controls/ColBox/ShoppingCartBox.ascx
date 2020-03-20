<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCartBox.ascx.cs"
    Inherits="UC.UI.Controls.ShoppingCartBox" EnableViewState="false" %>
<%@ Import Namespace="UC.UI" %>
<div class="box">
    <div class="boxtitle">Корзина</div>
    
    <div class="boxcontent">
        <div class="transparent"></div>
    
        <div class="shoppingcartbox">
            <div id="shoppingcartboxtotal">
                <div>
                    <asp:HyperLink runat="server" NavigateUrl="~/ShoppingCart.aspx" ToolTip="Перейти в корзину">
                        <asp:Image ID="Image1" runat="server" SkinID="ShoppingCartBox" /></asp:HyperLink>
                </div>
                <br />
                <asp:Literal runat="server" ID="lblTotalHeader" Text="Товаров: " /><span><asp:Literal
                    runat="server" ID="lblTotal" /></span><br />
                <asp:Literal runat="server" ID="lblSubtotalHeader" Text="На сумму: " /><span><asp:Literal
                    runat="server" ID="lblSubtotal" /></span></div>
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
                <asp:Panel runat="server" ID="panLinkShoppingCart" CssClass="ToShoppingCart">
                    <asp:HyperLink runat="server" ID="lnkShoppingCart" NavigateUrl="~/ShoppingCart.aspx"
                        ToolTip="Оформить заказ"><asp:Image runat="server" SkinID="ToShoppingCart" /></asp:HyperLink><br />
                </asp:Panel>
            </div>
        </div>

    </div>           
</div>
