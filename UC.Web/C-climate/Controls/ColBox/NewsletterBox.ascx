<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsletterBox.ascx.cs" Inherits="UC.UI.Controls.NewsletterBox" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper"%>
<div class="box">
    <div class="boxtitle">Новости</div>
    <div class="boxcontent news">
    <div class="transparent"></div>    
        <asp:Repeater runat="server" ID="repNewsItems">
            <ItemTemplate>
                <div id="newsletter">
                    <asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Newsletter.aspx?ID="+Eval("ID"))) %>'
                        ToolTip='<%# Eval("Subject") %>'><asp:Image runat="Server" SkinID="Newsletter" /></asp:HyperLink><div>
                            <span class="price" style="font-size: 10px">
                                <%# Eval("AddedDate", "{0:dd/MM}") %></span>
                            <asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Newsletter.aspx?ID="+Eval("ID"))) %>'
                                ToolTip='<%# Eval("Subject") %>'><%# Eval("Subject")%></asp:HyperLink></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="all">
            <asp:HyperLink runat="server" ID="hlnkAll" Text="Все новости "><asp:Image runat="Server" SkinID="All"/></asp:HyperLink></div>
    </div>
</div>
