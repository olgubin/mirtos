<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductFeaturedBox.ascx.cs"
    Inherits="UC.UI.Controls.ProductFeaturedBox" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper"%>
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/ShowProduct.aspx?ID="+Eval("ProductID"))) %>'
                                        ToolTip='<%# Eval("Title") %>'>
                                        <asp:Image ID="Image1" BorderWidth="0px" BorderColor="#9aaab1" runat="Server" ImageUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/pfimage.aspx?ID="+Eval("ProductID"))) %>' />
                                    </asp:HyperLink>
                                </td>
                                <td class="producttitle">
                                    <asp:HyperLink runat="server" ID="lnkProductTitle" Text='<%# Eval("Title") %>'
                                        NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/ShowProduct.aspx?ID=" + Eval("ProductID"))) %>' />
                                </td>
                            </tr>
                            <tr>
                                <td class="descr"><%# Eval("Description")%>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; height: 33px">
                                    <div class="productprice">
                                        <%# Eval("FinalPrice")%>
                                        <asp:Panel ID="Panel7" runat="server" Visible='<%# Eval("DiscountVisible") %>'>
                                            <s>
                                                <%# Eval("Price") %></s></asp:Panel>
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
