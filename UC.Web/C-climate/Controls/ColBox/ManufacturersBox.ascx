<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManufacturersBox.ascx.cs"
    Inherits="UC.UI.Controls.ManufacturersBox" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper"%>
<%@ Import Namespace="UC.UI" %>
<div class="box">
    <div class="boxtitle">Каталог брендов</div>

    <div class="boxcontent" style="font-size:1.0em">
        <div class="transparent"></div>
        <asp:Repeater runat="server" ID="repManufacturers">
            <HeaderTemplate>
                <table width="100%">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <div>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?ManID="+Eval("ManufacturerID"))) %>'
                                ToolTip='<%# Eval("Title") %>'><%# Eval("Title") %></asp:HyperLink><br />
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>
    </div>
</div>
<%--        <div id="all">
            <asp:HyperLink ID="lnkAll" runat="server" NavigateUrl="~/ProductSales.aspx" Text="Каталог производителей ">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/arr.gif" ImageAlign="AbsMiddle"
                    GenerateEmptyAlternateText="true" /></asp:HyperLink></div>    
    <div class="shoppingcartboxcontent">                    
        <asp:Repeater runat="server" ID="repManufacturers1">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                       <div id="article">                    
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Departments.aspx?ManID="+Eval("ID") %>' ToolTip='<%# Eval("Title") %>'>
                                <asp:Image ID="Image2" runat="Server" ImageUrl='<%# "~/manimage.aspx?ManID="+Eval("ID") %>' />
                            </asp:HyperLink>
                            <div style="padding-top:12px">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Departments.aspx?ManID="+Eval("ID") %>' Font-Underline="false"
                                    ToolTip='<%# Eval("Title") %>'><%# Eval("Title") %></asp:HyperLink><br />
                            </div>
                       </div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table></FooterTemplate>
        </asp:Repeater>                    
    </div>--%>
