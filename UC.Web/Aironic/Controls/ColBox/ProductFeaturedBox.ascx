<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductFeaturedBox.ascx.cs"
    Inherits="UC.UI.Controls.ProductFeaturedBox" EnableViewState="false" %>
<%@ Import Namespace="UC.UI" %>
<asp:Panel ID="MainBox" runat="server" CssClass="advertbox">
    <div class="advertcontent">
        <asp:Repeater runat="server" ID="repProductFeatured">
            <HeaderTemplate>
                <table cellpadding="0" cellspacing="0">
                    <tr>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <div class="advertblock iePNG">
                        <table>
                            <tr>
                                <td rowspan="3">
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ShowProduct.aspx?ID="+Eval("Product.ProductID") %>'
                                        ToolTip='<%# Eval("Product.Title") %>'>
                                        <asp:Image ID="Image1" BorderWidth="0px" BorderColor="#d7c5ab" runat="Server" ImageUrl='<%# "~/pfimage.aspx?ID="+Eval("Product.ProductID") %>' />
                                    </asp:HyperLink>
                                </td>
                                <td class="producttitle">
                                    <asp:HyperLink runat="server" ID="lnkProductTitle" Text='<%# Eval("Product.Title") %>'
                                        NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + Eval("Product.ProductID") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="descr"><%# Eval("Description")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; height: 33px">
                                    <div class="productprice">
                                        <%# (this.Page as BasePage).FormatPrice(Eval("Product.FinalUnitPrice"))%>
                                        <asp:Panel ID="Panel7" runat="server" Visible='<%# (int)Eval("Product.DiscountPercentage") > 0 %>'>
                                            <s>
                                                <%# (this.Page as BasePage).FormatPrice(Eval("Product.UnitPrice"))%></s></asp:Panel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr></table></FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="advertfon">
    </div>
    <div class="adverttitle">
    </div>
</asp:Panel>
