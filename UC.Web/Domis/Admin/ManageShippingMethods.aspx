<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManageShippingMethods.aspx.cs" Inherits="UC.UI.Admin.ManageShippingMethods" Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">   
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ManageShippingMethods %>" />
   </div>
   <p></p>
   <asp:GridView ID="gvwShippingMethods" runat="server" AutoGenerateColumns="False" DataSourceID="objAllShippingMethods" Width="100%" DataKeyNames="ID" OnRowDeleted="gvwShippingMethods_RowDeleted" OnRowCreated="gvwShippingMethods_RowCreated" OnSelectedIndexChanged="gvwShippingMethods_SelectedIndexChanged" meta:resourcekey="gvwShippingMethodsResource1">
      <Columns>
         <asp:BoundField HeaderText="Title" DataField="Title" meta:resourcekey="BoundFieldResource1" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:BoundField HeaderText="Price" DataField="Price" DataFormatString="{0:N2}" HtmlEncode="False" meta:resourcekey="BoundFieldResource2" >
             <ItemStyle HorizontalAlign="Right" />
             <HeaderStyle HorizontalAlign="Right" />
         </asp:BoundField>
         <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Edit shipping method" ShowSelectButton="True" meta:resourcekey="CommandFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete shipping method" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource2">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
      </Columns>
      <EmptyDataTemplate><b>
      <asp:Literal runat="server" Text="<%$ resources:Noshippingmethods%>" />
      </b></EmptyDataTemplate>   
   </asp:GridView>
   <asp:ObjectDataSource ID="objAllShippingMethods" runat="server" SelectMethod="GetShippingMethods"
      TypeName="UC.BLL.Store.ShippingMethod" DeleteMethod="DeleteShippingMethod">
   </asp:ObjectDataSource>
   <p></p>
   <asp:DetailsView ID="dvwShippingMethod" runat="server" AutoGenerateRows="False" DataSourceID="objCurrShippingMethod" Height="50px" Width="50%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HeaderText="Shipping Details" OnItemInserted="dvwShippingMethod_ItemInserted" OnItemUpdated="dvwShippingMethod_ItemUpdated" DataKeyNames="ID" DefaultMode="Insert" OnItemCommand="dvwShippingMethod_ItemCommand" meta:resourcekey="dvwShippingMethodResource1">
      <FieldHeaderStyle Width="100px" />
      <Fields>
         <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" meta:resourcekey="BoundFieldResource3" />
         <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False"
            ReadOnly="True" SortExpression="AddedDate" meta:resourcekey="BoundFieldResource4" />
         <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True"
            SortExpression="AddedBy" meta:resourcekey="BoundFieldResource5" />
         <asp:TemplateField HeaderText="Title" SortExpression="Title" meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
               <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>' meta:resourcekey="lblTitleResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' MaxLength="256" Width="100%" meta:resourcekey="txtTitleResource1"></asp:TextBox>
               <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle" SetFocusOnError="True"
                  Text="The Title field is required." ToolTip="The Title field is required." Display="Dynamic" meta:resourcekey="valRequireTitleResource1"></asp:RequiredFieldValidator>
            </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Price" SortExpression="Price" meta:resourcekey="TemplateFieldResource2">
            <ItemTemplate>
               <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price", "{0:N2}") %>' meta:resourcekey="lblPriceResource1"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price", "{0:N2}") %>' Width="100%" meta:resourcekey="txtPriceResource1"></asp:TextBox>
               <asp:RequiredFieldValidator ID="valRequirePrice" runat="server" ControlToValidate="txtPrice" SetFocusOnError="True"
                  Text="The Price field is required." ToolTip="The Price field is required." Display="Dynamic" meta:resourcekey="valRequirePriceResource1"></asp:RequiredFieldValidator>
               <asp:CompareValidator ID="valPriceType" runat="server" Operator="DataTypeCheck" Type="Double"
                  ControlToValidate="txtPrice" Text="The Price must be a double."
                  ToolTip="The Price must be a double." Display="Dynamic" meta:resourcekey="valPriceTypeResource1" />
            </EditItemTemplate>
         </asp:TemplateField>         
      </Fields>
   </asp:DetailsView>
   <asp:ObjectDataSource ID="objCurrShippingMethod" runat="server" InsertMethod="InsertShippingMethod" SelectMethod="GetShippingMethodByID" TypeName="UC.BLL.Store.ShippingMethod" UpdateMethod="UpdateShippingMethod">
      <SelectParameters>
         <asp:ControlParameter ControlID="gvwShippingMethods" Name="shippingMethodID" PropertyName="SelectedValue" Type="Int32" />
      </SelectParameters>
      <UpdateParameters>
         <asp:Parameter Name="id" Type="Int32" />
         <asp:Parameter Name="title" Type="String" />
         <asp:Parameter Name="price" Type="Decimal" />
      </UpdateParameters>
      <InsertParameters>
         <asp:Parameter Name="title" Type="String" />
         <asp:Parameter Name="price" Type="Decimal" />
      </InsertParameters>
   </asp:ObjectDataSource>         
</asp:Content>

