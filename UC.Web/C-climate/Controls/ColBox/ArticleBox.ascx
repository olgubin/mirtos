<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleBox.ascx.cs" Inherits="UC.UI.Controls.ArticleBox" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper"%>
<div class="box">
    <div class="boxtitle">Статьи</div>
    <div class="boxcontent article">
    <div class="transparent"></div>        
        <asp:Repeater runat="server" ID="repArticleItems">
            <ItemTemplate>
                <div id="newsletter">
                    <asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Article.aspx?ID="+Eval("ID"))) %>'
                        ToolTip='<%# Eval("Title") %>'><asp:Image runat="Server" SkinID="Article" /></asp:HyperLink><div>
                            <asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Article.aspx?ID="+Eval("ID"))) %>'
                                ToolTip='<%# Eval("Title") %>'><%# Eval("Title")%></asp:HyperLink></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="all">
            <asp:HyperLink runat="server" ID="hlnkAll" Text="Все статьи "><asp:Image runat="Server" SkinID="All" /></asp:HyperLink></div>
    </div>
</div>
