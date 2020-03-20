<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsletterBox.ascx.cs"
    Inherits="UC.UI.Controls.NewsletterBox" EnableViewState="false" %>
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
                                Новости</div>
                            <div class="boxcontent news">
                                <asp:Repeater runat="server" ID="repNewsItems">
                                    <ItemTemplate>
                                        <div id="newsletter">
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Newsletter.aspx?ID="+Eval("ID"))) %>'
                                                ToolTip='<%# Eval("Subject") %>'>
                                                <asp:Image ID="Image1" runat="Server" SkinID="Newsletter" /></asp:HyperLink><div>
                                                    <span class="texthover" style="font-size: 10px">
                                                        <%# Eval("AddedDate", "{0:dd/MM}") %></span>
                                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Newsletter.aspx?ID="+Eval("ID"))) %>'
                                                        ToolTip='<%# Eval("Subject") %>'><%# Eval("Subject")%></asp:HyperLink></div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div id="all">
                                    <asp:HyperLink ID="hlnkAll" runat="server" Text="Все новости ">
                                        <asp:Image ID="Image2" runat="Server" SkinID="All" /></asp:HyperLink></div>
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
