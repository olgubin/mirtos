<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BannerHelp.ascx.cs" Inherits="UC.UI.Controls.BannerHelp" %>
<%@ Import Namespace="UC.SEOHelper"%>
<div style="text-align:center;padding-top:7px;padding-bottom:17px;">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td style="width:33%"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Design.aspx"))%>'><img src="Images/Banners/baner1.png" alt="Проектирование" title="Профессиональная разработка проектной документации" height="84px" width="287px"/></asp:HyperLink></td>
<td style="width:33%"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Assembly.aspx"))%>'><img src="Images/Banners/baner2.png" alt="Монтаж" title="Профессиональный и качественный монтаж с гарантией" height="84px" width="287px"/></asp:HyperLink></td>
<td style="width:33%"><asp:HyperLink runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Service.aspx"))%>'><img src="Images/Banners/baner3.png" alt="Сервис" title="Все виды сервисного обслуживания оборудования и установок" height="84px" width="287px"/></asp:HyperLink>
</td>
</tr>
</table>
</div>
