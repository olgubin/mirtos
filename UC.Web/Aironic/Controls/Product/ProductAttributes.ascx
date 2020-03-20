<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAttributes.ascx.cs"
    Inherits="UC.UI.Controls.ProductAttributes" %>
<%@ Import Namespace="UC.UI" %>
<asp:Repeater runat="server" ID="repProductAttributeMapping">
    <HeaderTemplate>
        <table width="100%" cellpadding='<%# Padding %>'>
    </HeaderTemplate>
    <ItemTemplate>
        <tr class='<%# CssClass %>'>
            <th>
                <%# Eval("ProductAttribute.Name")%>
            </th>
            <td>
                <%# Eval("AttributeValue")%>
            </td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class='<%# CssClassAlt %>'>
            <th>
                <%# Eval("ProductAttribute.Name")%>
            </th>
            <td>
                <%# Eval("AttributeValue")%>
            </td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
        </table></FooterTemplate>
</asp:Repeater>
