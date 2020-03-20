<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleBox.ascx.cs" Inherits="UC.UI.Controls.ArticleBox"
    EnableViewState="false" %>
<div class="box">
    <div class="boxtitle">������</div>
    <div class="boxcontent article">
    <div class="transparent"></div>        
        <asp:Repeater runat="server" ID="repArticleItems">
            <ItemTemplate>
                <div id="newsletter">
                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Article.aspx?ID="+Eval("ID") %>'
                        ToolTip='<%# Eval("Title") %>'><asp:Image runat="Server" SkinID="Article" /></asp:HyperLink><div>
                            <asp:HyperLink runat="server" NavigateUrl='<%# "~/Article.aspx?ID="+Eval("ID") %>'
                                ToolTip='<%# Eval("Title") %>'><%# Eval("Title")%></asp:HyperLink></div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div id="all">
            <asp:HyperLink runat="server" NavigateUrl="~/Articles.aspx" Text="��� ������ "><asp:Image runat="Server" SkinID="All" /></asp:HyperLink></div>
    </div>
</div>
