<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleBox.ascx.cs" Inherits="UC.UI.Controls.ArticleBox"
    EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper" %>
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
                                Статьи</div>
                            <div class="boxcontent article">
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
