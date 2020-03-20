<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductFeaturedBox.ascx.cs"
    Inherits="UC.UI.Controls.ProductFeaturedBox" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper" %>
<%@ Import Namespace="UC.UI" %>
<div style="padding-bottom:7px">
<asp:Repeater runat="server" ID="repProductFeatured">
    <HeaderTemplate>
        <table cellpadding="3">
            <tr>
    </HeaderTemplate>
    <ItemTemplate>
        <td style="width: 25%">
            <div style="position: relative;">
                <div class="advtop_middle">
                    <div class="advtitle">
                        <%# Eval("Description")%>
                    </div>
                </div>
                <div class="advtop_left">
                </div>
                <div class="advtop_right">
                </div>
            </div>
            <div class="advmiddle">
                <div class="advmiddle_middle">
                    <table style="height: 100%">
                        <tr>
                            <td class="advimage">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/ShowProduct.aspx?ID="+Eval("ProductID"))) %>'
                                    ToolTip='<%# Eval("Title") %>'>
                                    <asp:Image ID="Image3" BorderWidth="0px" BorderColor="#9aaab1" runat="Server" ImageUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/pfimage.aspx?ID="+Eval("ProductID"))) %>'
                                        ToolTip='<%# Eval("Title") %>' />
                                </asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="advname">
                                <asp:HyperLink runat="server" ID="HyperLink3" Text='<%# Eval("Title") %>' ToolTip='<%# Eval("Title") %>'
                                    NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/ShowProduct.aspx?ID=" + Eval("ProductID"))) %>' />
                            </td>
                        </tr>
                        <tr>
                            <td class="advprice">
                                <%# Eval("FinalPrice")%>
                                <asp:Panel ID="Panel2" runat="server" Visible='<%# Eval("DiscountVisible") %>'>
                                    <s>
                                        <%# Eval("Price") %></s></asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="advmiddle_left">
                </div>
                <div class="advmiddle_right">
                </div>
            </div>
            <div class="advbottom">
                <div class="advbottom_middle">
                </div>
                <div class="advbottom_left">
                </div>
                <div class="advbottom_right">
                </div>
            </div>
        </td>
    </ItemTemplate>
    <FooterTemplate>
        </tr></table></FooterTemplate>
</asp:Repeater>
</div>
