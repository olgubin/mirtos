<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManageOrderStatuses.aspx.cs" Inherits="UC.UI.Admin.ManageOrderStatuses" Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">   
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ManageOrderStatuses %>" />
   </div>
   <p></p>
   <asp:GridView ID="gvwOrderStatuses" runat="server" AutoGenerateColumns="False" DataSourceID="objAllOrderStatuses" Width="100%" DataKeyNames="ID" OnRowDeleted="gvwOrderStatuses_RowDeleted" OnRowCreated="gvwOrderStatuses_RowCreated" OnSelectedIndexChanged="gvwOrderStatuses_SelectedIndexChanged" meta:resourcekey="gvwOrderStatusesResource1">
      <Columns>
         <asp:BoundField HeaderText="Title" DataField="Title" meta:resourcekey="BoundFieldResource1" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Edit order status" ShowSelectButton="True" meta:resourcekey="CommandFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete order status" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource2">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
      </Columns>
      <EmptyDataTemplate><b>
      <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Nostatuses %>" />
      </b></EmptyDataTemplate>   
   </asp:GridView>
   <asp:ObjectDataSource ID="objAllOrderStatuses" runat="server" SelectMethod="GetOrderStatuses"
      TypeName="UC.BLL.Store.OrderStatus" DeleteMethod="DeleteOrderStatus">
   </asp:ObjectDataSource>
   <p></p>
   <asp:DetailsView ID="dvwOrderStatus" runat="server" AutoGenerateRows="False" DataSourceID="objCurrOrderStatus" Height="50px" Width="50%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HeaderText="Status Details" OnItemInserted="dvwOrderStatus_ItemInserted" OnItemUpdated="dvwOrderStatus_ItemUpdated" DataKeyNames="ID" DefaultMode="Insert" OnItemCommand="dvwOrderStatus_ItemCommand" meta:resourcekey="dvwOrderStatusResource1">
      <FieldHeaderStyle Width="100px" />
      <Fields>
         <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" meta:resourcekey="BoundFieldResource2" />
         <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False"
            ReadOnly="True" SortExpression="AddedDate" meta:resourcekey="BoundFieldResource3" />
         <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True"
            SortExpression="AddedBy" meta:resourcekey="BoundFieldResource4" />
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
      </Fields>
   </asp:DetailsView>
   <asp:ObjectDataSource ID="objCurrOrderStatus" runat="server" InsertMethod="InsertOrderStatus" SelectMethod="GetOrderStatusByID" TypeName="UC.BLL.Store.OrderStatus" UpdateMethod="UpdateOrderStatus">
      <SelectParameters>
         <asp:ControlParameter ControlID="gvwOrderStatuses" Name="orderStatusID" PropertyName="SelectedValue"
            Type="Int32" />
      </SelectParameters>
   </asp:ObjectDataSource>         
</asp:Content>

