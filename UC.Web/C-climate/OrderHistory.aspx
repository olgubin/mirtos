<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="UC.UI.OrderHistory" Culture="auto" UICulture="auto" %>
<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Import Namespace="UC.BLL.Store" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:OrderHistory %>" />
   </div>
   <p></p>
   <p></p>
   <asp:DataList runat="server" ID="dlstOrders" meta:resourcekey="dlstOrdersResource1">
      <ItemTemplate>
         <div class="sectionsubtitle">
         <asp:Literal ID="Literal4" runat="server" Text="<%$ resources:Order %>" />
          #<%# Eval("ID") %> - <%# Eval("AddedDate", "{0:g}") %></div>
         <br />
         <img src="Images/ArrowR4.gif" border="0" alt="" /> 
         <u><asp:Literal ID="Literal5" runat="server" Text="<%$ resources:Total %>" /></u> = <%# FormatPrice((decimal)Eval("SubTotal") + (decimal)Eval("Shipping")) %><br />
         <img src="Images/ArrowR4.gif" border="0" alt="" /> 
         <u><asp:Literal ID="Literal6" runat="server" Text="<%$ resources:Status %>" /></u> = <%# Eval("StatusTitle") %> 
         &nbsp;&nbsp;&nbsp;
         <asp:HyperLink runat="server" ID="lnkPay" Font-Bold="True" Text="Pay Now"
            NavigateUrl='<%# (Container.DataItem as Order).GetPayPalPaymentUrl() %>'
            Visible = '<%# ((int)Eval("StatusID")) == 1 %>' meta:resourcekey="lnkPayResource1" />
         <p></p>         
         <small>
         <b>
         <asp:Literal ID="Literal3" runat="server" Text="<%$ resources:Details %>" />
         </b><br />
         <asp:Repeater runat="server" ID="repOrderItems" DataSource='<%# Eval("Items") %>'>
            <ItemTemplate>
               <img src="Images/ArrowR3.gif" border="0" alt="" />
               <%# Eval("Title") %> - <%# FormatPrice(Eval("UnitPrice")) %> &nbsp;&nbsp;<small>(
               <asp:Literal ID="Literal3" runat="server" Text="<%$ resources:Quantity %>" /> = <%# Eval("Quantity") %>)</small>
               <br />
            </ItemTemplate>
         </asp:Repeater>
         <br />
         <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Subtotal %>" />
         <%# FormatPrice(Eval("SubTotal")) %><br />
         <asp:Literal ID="Literal2" runat="server" Text="<%$ resources:ShippingMethod %>" />
         <%# Eval("ShippingMethod") %> (<%# FormatPrice(Eval("Shipping")) %>)         
         </small>
      </ItemTemplate>
      <SeparatorTemplate>
         <hr style="width: 99%;" />
      </SeparatorTemplate>
   </asp:DataList>
</asp:Content>

