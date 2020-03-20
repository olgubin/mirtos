<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="EditOrder.aspx.cs" Inherits="UC.UI.Admin.EditOrder" Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ManageOrder %>"/>
   </div>
   <p></p>
   <asp:DetailsView ID="dvwOrder" runat="server" AutoGenerateEditButton="True"
      AutoGenerateRows="False" DataKeyNames="ID" DataSourceID="objCurrOrder"
      DefaultMode="Edit" HeaderText="Order Details" OnDataBound="dvwOrder_DataBound" meta:resourcekey="dvwOrderResource1">
      <FieldHeaderStyle Width="100px" />
      <Fields>
         <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" meta:resourcekey="BoundFieldResource1" />
         <asp:BoundField DataField="AddedDate" HeaderText="Added Date" ReadOnly="True" HtmlEncode="False" DataFormatString="{0:f}" meta:resourcekey="BoundFieldResource2" />
         <asp:TemplateField HeaderText="Customer" meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
               <asp:HyperLink runat="server" ID="lnkCustomer" Text='<%# Eval("AddedBy") %>'
                  NavigateUrl='<%# "mailto:" + Eval("CustomerEmail") %>' meta:resourcekey="lnkCustomerResource1" />
                  <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Phone %>"/>
               <%# Eval("CustomerPhone") %>
               <asp:Literal ID="Literal2" runat="server" Text="<%$ resources:Fax %>"/>
               <%# Eval("CustomerFax") %>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Address" meta:resourcekey="TemplateFieldResource2">
            <ItemTemplate>
               <%# Eval("ShippingFirstName") %> <%# Eval("ShippingLastName") %><br />
               <%# Eval("ShippingStreet") %><br />
               <%# Eval("ShippingCity") %>, <%# Eval("ShippingState") %> <%# Eval("ShippingPostalCode") %><br />
               <%# Eval("ShippingCountry") %>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Items" meta:resourcekey="TemplateFieldResource3">
            <ItemTemplate>
               <asp:Repeater runat="server" ID="repOrderItems" DataSource='<%# Eval("Items") %>'>                  
                  <ItemTemplate>
                     <img src="../Images/ArrowR3.gif" border="0" alt="" />                      
                      <asp:HyperLink runat="server" ID="lnkProduct" Text='<%# Eval("Title") %>'
                        NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + Eval("ProductID") %>' meta:resourcekey="lnkProductResource1" />
                     <small>(SKU = <%# Eval("SKU") %>) <asp:Literal ID="Literal2" runat="server" Text="<%$ resources:Quantity %>"/><%# Eval("Quantity") %></small>
                     <br />
                  </ItemTemplate>
               </asp:Repeater>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:BoundField DataField="SubTotal" HeaderText="Subtotal" ReadOnly="True" HtmlEncode="False" DataFormatString="{0:N2}" meta:resourcekey="BoundFieldResource3" />         
         <asp:TemplateField HeaderText="Shipping" meta:resourcekey="TemplateFieldResource4">
            <ItemTemplate>
               <%# Eval("ShippingMethod") %> (<%# Eval("Shipping", "{0:N2}") %>)
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Total" meta:resourcekey="TemplateFieldResource5">
            <ItemTemplate>
                <%# ((decimal)Eval("SubTotal") + (decimal)Eval("Shipping")).ToString("N2") %>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Status" meta:resourcekey="TemplateFieldResource6">
            <ItemTemplate>
               <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusTitle") %>' meta:resourcekey="lblStatusResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:DropDownList ID="ddlOrderStatuses" runat="server" DataSourceID="objAllStatuses"
                  DataTextField="Title" DataValueField="ID" SelectedValue='<%# Bind("StatusID") %>' Width="100%" meta:resourcekey="ddlOrderStatusesResource1" />
               <asp:ObjectDataSource ID="objAllStatuses" runat="server" SelectMethod="GetOrderStatuses"
                  TypeName="UC.BLL.Store.OrderStatus"></asp:ObjectDataSource>   
            </EditItemTemplate>
         </asp:TemplateField>         
         <asp:TemplateField HeaderText="Shipped Date" meta:resourcekey="TemplateFieldResource7">
            <ItemTemplate>
               <asp:Label ID="lblShippedDate" runat="server" Text='<%# Eval("ShippedDate") %>' meta:resourcekey="lblShippedDateResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtShippedDate" runat="server" Text='<%# Bind("ShippedDate", "{0:d}") %>' Width="100%" MaxLength="256" meta:resourcekey="txtShippedDateResource1"></asp:TextBox>
               <asp:CompareValidator ID="valShippedDateType" runat="server" Operator="DataTypeCheck" Type="Date"
                  ControlToValidate="txtShippedDate" Text="The format of the Shipped Date field is not valid."
                  ToolTip="The format of the Shipped Date field is not valid." Display="Dynamic" meta:resourcekey="valShippedDateTypeResource1" />
            </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Tracking ID" meta:resourcekey="TemplateFieldResource8">
            <ItemTemplate>
               <asp:Label ID="lblTrackingID" runat="server" Text='<%# Eval("lblTrackingID") %>' meta:resourcekey="lblTrackingIDResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtTrackingID" runat="server" Text='<%# Bind("TrackingID") %>' Width="100%" MaxLength="256" meta:resourcekey="txtTrackingIDResource1"></asp:TextBox>
            </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Transaction ID" meta:resourcekey="TemplateFieldResource9">
            <ItemTemplate>
               <asp:Label ID="lblTransactionID" runat="server" Text='<%# Eval("lblTransactionID") %>' meta:resourcekey="lblTransactionIDResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtTransactionID" runat="server" Text='<%# Bind("TransactionID") %>' Width="100%" MaxLength="256" meta:resourcekey="txtTransactionIDResource1"></asp:TextBox>
            </EditItemTemplate>
         </asp:TemplateField>
      </Fields>
   </asp:DetailsView>
   <asp:ObjectDataSource ID="objCurrOrder" runat="server" UpdateMethod="UpdateOrder"
      SelectMethod="GetOrderByID" TypeName="UC.BLL.Store.Order">
      <UpdateParameters>
         <asp:Parameter Name="id" Type="Int32" />
         <asp:Parameter Name="statusID" Type="Int32" />
         <asp:Parameter Name="shippedDate" Type="DateTime" />
         <asp:Parameter Name="transactionID" Type="String" ConvertEmptyStringToNull="False" />
         <asp:Parameter Name="trackingID" Type="String" ConvertEmptyStringToNull="False" />
      </UpdateParameters>
      <SelectParameters>
         <asp:QueryStringParameter Name="orderID" QueryStringField="ID" Type="Int32" />
      </SelectParameters>
   </asp:ObjectDataSource>     
</asp:Content>

