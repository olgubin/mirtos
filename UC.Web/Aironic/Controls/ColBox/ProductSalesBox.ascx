<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductSalesBox.ascx.cs" Inherits="UC.UI.Controls.ProductSalesBox" EnableViewState="false" %><%@ Import Namespace="UC.UI" %><div class="shoppingcartbox"><div class="sectiontitle"><asp:Label runat="server" ID="lblHeader">�������������� �� �������</asp:Label></div><div class="shoppingcartboxcontent"><asp:Repeater runat="server" ID="repOrderItems"><HeaderTemplate><table></HeaderTemplate><ItemTemplate><tr><td><div id="article"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/ShowProduct.aspx?ID="+Eval("ID") %>' ToolTip='<%# Eval("Title") %>'><asp:Image ID="Image2" runat="Server" ImageUrl='<%# "~/psimage.aspx?ID="+Eval("ID") %>' /></asp:HyperLink><div><asp:HyperLink runat="server" NavigateUrl='<%# "~/ShowProduct.aspx?ID="+Eval("ID") %>' ToolTip='<%# Eval("Title") %>'><%# Eval("Title") %></asp:HyperLink><br /><span class="price"><s><%# (this.Page as BasePage).FormatPrice(Eval("UnitPrice"))%></s></span><br /><span class="price" style="font-weight:bold"><%# (this.Page as BasePage).FormatPrice(Eval("FinalUnitPrice")) %></span></div></div></td></tr></ItemTemplate><FooterTemplate></table></FooterTemplate></asp:Repeater><div id="all"><asp:HyperLink ID="lnkAll" runat="server" NavigateUrl="~/ProductSales.aspx" Text="��� ������ "><asp:Image ID="Image3" runat="server" ImageUrl="~/Images/arr.gif" ImageAlign="AbsMiddle" GenerateEmptyAlternateText="true" /></asp:HyperLink></div></div></div>
