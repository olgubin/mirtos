<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManageOrders.aspx.cs" Inherits="UC.UI.Admin.ManageOrders" Title="The Beer House - Manage Orders" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">   
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ManageOrders %>" />
   </div>
   <p></p>
   <div class="sectionsubtitle">
   <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:OrdersStatus %>" />
   </div>
   <asp:Literal ID="Literal2" runat="server" Text="<%$ resources:Status%>" />
   <asp:DropDownList ID="ddlOrderStatuses" runat="server" DataSourceID="objAllStatuses" DataTextField="Title" DataValueField="ID" meta:resourcekey="ddlOrderStatusesResource1" />
   <asp:ObjectDataSource ID="objAllStatuses" runat="server" SelectMethod="GetOrderStatuses"
      TypeName="UC.BLL.Store.OrderStatus"></asp:ObjectDataSource>
   <asp:Literal ID="Literal3" runat="server" Text="<%$ resources:from%>" />   
   <asp:TextBox ID="txtFromDate" runat="server" Width="80px" meta:resourcekey="txtFromDateResource1" />
   <asp:Literal ID="Literal4" runat="server" Text="<%$ resources:to%>" />
   <asp:TextBox ID="txtToDate" runat="server" Width="80px" meta:resourcekey="txtToDateResource1" /> 
   <asp:Button ID="btnListByStatus" runat="server" Text="Load" OnClick="btnListByStatus_Click" ValidationGroup="ListByStatus" meta:resourcekey="btnListByStatusResource1" />
   <asp:RequiredFieldValidator ID="valRequireFromDate" runat="server" ControlToValidate="txtFromDate" SetFocusOnError="True" ValidationGroup="ListByStatus"
      Text="<br />The From Date field is required." ToolTip="The From Date field is required." Display="Dynamic" meta:resourcekey="valRequireFromDateResource1"></asp:RequiredFieldValidator>
   <asp:CompareValidator runat="server" ID="valFromDateType" ControlToValidate="txtFromDate" SetFocusOnError="True" ValidationGroup="ListByStatus"      
      Text="<br />The format of the From Date is not valid." ToolTip="The format of the From Date is not valid." 
      Display="Dynamic" Operator="DataTypeCheck" Type="Date" meta:resourcekey="valFromDateTypeResource1" />
   <asp:RequiredFieldValidator ID="valRequireToDate" runat="server" ControlToValidate="txtToDate" SetFocusOnError="True" ValidationGroup="ListByStatus"
      Text="<br />The To Date field is required." ToolTip="The To Date field is required." Display="Dynamic" meta:resourcekey="valRequireToDateResource1"></asp:RequiredFieldValidator>
   <asp:CompareValidator runat="server" ID="valToDateType" ControlToValidate="txtToDate" SetFocusOnError="True" ValidationGroup="ListByStatus"      
      Text="<br />The format of the To Date is not valid." ToolTip="The format of the To Date is not valid." 
      Display="Dynamic" Operator="DataTypeCheck" Type="Date" meta:resourcekey="valToDateTypeResource1" />
   <p></p>   
   <div class="sectionsubtitle">
   <asp:Literal ID="Literal5" runat="server" Text="<%$ resources:OrdersCustomer%>" />
   </div>
   <asp:Literal ID="Literal6" runat="server" Text="<%$ resources:Name%>" />
   <asp:TextBox ID="txtCustomerName" runat="server" meta:resourcekey="txtCustomerNameResource1" />
   <asp:Button ID="btnListByCustomer" runat="server" Text="Load" OnClick="btnListByCustomer_Click" ValidationGroup="ListByCustomer" meta:resourcekey="btnListByCustomerResource1" />
   <asp:RequiredFieldValidator ID="valRequireCustomerName" runat="server" ControlToValidate="txtCustomerName" SetFocusOnError="True" ValidationGroup="ListByCustomer"
      Text="<br />The Customer Name field is required." ToolTip="The Customer Name field is required." Display="Dynamic" meta:resourcekey="valRequireCustomerNameResource1"></asp:RequiredFieldValidator>
   <p></p>
   <div class="sectionsubtitle">
   <asp:Literal ID="Literal7" runat="server" Text="<%$ resources:OrderLookup%>" />
   </div>
   ID: <asp:TextBox ID="txtOrderID" runat="server" meta:resourcekey="txtOrderIDResource1" /> 
   <asp:Button ID="btnOrderLookup" runat="server" Text="Find" OnClick="btnOrderLookup_Click" ValidationGroup="OrderLookup" meta:resourcekey="btnOrderLookupResource1" />
   <asp:Label runat="server" ID="lblOrderNotFound" SkinID="FeedbackKO" Text="Order not found!" Visible="False" meta:resourcekey="lblOrderNotFoundResource1" />
   <asp:RequiredFieldValidator ID="valRequireOrderID" runat="server" ControlToValidate="txtOrderID" SetFocusOnError="True" ValidationGroup="OrderLookup"
      Text="<br />The Order ID field is required." ToolTip="The Order ID field is required." Display="Dynamic" meta:resourcekey="valRequireOrderIDResource1"></asp:RequiredFieldValidator>
   <p></p>   
   <asp:GridView ID="gvwOrders" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ID" OnRowDeleting="gvwOrders_RowDeleting" OnRowCreated="gvwOrders_RowCreated" meta:resourcekey="gvwOrdersResource1">
      <Columns>
         <asp:BoundField HeaderText="Date" DataField="AddedDate" DataFormatString="{0:d}&lt;br /&gt;{0:t}" HtmlEncode="False" meta:resourcekey="BoundFieldResource1" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:BoundField HeaderText="Customer" DataField="AddedBy" meta:resourcekey="BoundFieldResource2" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:TemplateField HeaderText="Items" meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
               <small>
               <asp:Repeater runat="server" ID="repOrderItems" DataSource='<%# Eval("Items") %>'>                  
                  <ItemTemplate>
                     <img src="../Images/ArrowR3.gif" border="0" alt="" />
                      [<%# Eval("SKU") %>] 
                      <asp:HyperLink runat="server" ID="lnkProduct" Text='<%# Eval("Title") %>'
                        NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + Eval("ProductID") %>' meta:resourcekey="lnkProductResource1" />
                     - (<%# Eval("Quantity") %>)
                     <br />
                  </ItemTemplate>
               </asp:Repeater>
               </small>
            </ItemTemplate>
             <HeaderStyle HorizontalAlign="Left" />
         </asp:TemplateField>
         <asp:BoundField HeaderText="Subtotal" DataField="SubTotal" DataFormatString="{0:N2}" HtmlEncode="False" meta:resourcekey="BoundFieldResource3" >
             <ItemStyle HorizontalAlign="Right" />
             <HeaderStyle HorizontalAlign="Right" />
         </asp:BoundField>
         <asp:BoundField HeaderText="Shipping" DataField="Shipping" DataFormatString="{0:N2}" HtmlEncode="False" meta:resourcekey="BoundFieldResource4" >
             <ItemStyle HorizontalAlign="Right" />
             <HeaderStyle HorizontalAlign="Right" />
         </asp:BoundField>         
         <asp:HyperLinkField Text="&lt;img border='0' src='../Images/ArrowR.gif' alt='View / Edit order' /&gt;"
            DataNavigateUrlFormatString="EditOrder.aspx?ID={0}" DataNavigateUrlFields="ID" meta:resourcekey="HyperLinkFieldResource1" >
             <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:HyperLinkField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete order" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource1" >
             <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
      </Columns>
      <EmptyDataTemplate><b>
      <asp:Literal ID="Literal7" runat="server" Text="<%$ resources:Noorders%>" />
      </b></EmptyDataTemplate>   
   </asp:GridView>
</asp:Content>

