<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManagePolls.aspx.cs" Inherits="UC.UI.Admin.ManagePolls" Culture="auto" UICulture="auto" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">   
   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ManagePolls %>" />
   </div>
   <p></p>
   <ul style="list-style-type: square">
      <li><asp:HyperLink runat="server" ID="lnkArchive" NavigateUrl="~/ArchivedPolls.aspx" meta:resourcekey="lnkArchiveResource1">Manage Archived Polls</asp:HyperLink></li>
   </ul>
   <p></p>
   <asp:GridView ID="gvwPolls" runat="server" AutoGenerateColumns="False" DataSourceID="objPolls" Width="100%" DataKeyNames="ID" OnRowCreated="gvwPolls_RowCreated" OnRowDeleted="gvwPolls_RowDeleted" OnSelectedIndexChanged="gvwPolls_SelectedIndexChanged" OnRowCommand="gvwPolls_RowCommand" meta:resourcekey="gvwPollsResource1">
      <Columns>
         <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" meta:resourcekey="BoundFieldResource1" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:BoundField DataField="QuestionText" HeaderText="Poll" meta:resourcekey="BoundFieldResource2" >
             <HeaderStyle HorizontalAlign="Left" />
         </asp:BoundField>
         <asp:BoundField DataField="Votes" ReadOnly="True" HeaderText="Votes" meta:resourcekey="BoundFieldResource3" >
             <ItemStyle HorizontalAlign="Center" />
         </asp:BoundField>
         <asp:TemplateField HeaderText="Is Current" meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
               <asp:Image runat="server" ID="imgIsCurrent" ImageUrl="~/Images/Checkmark.gif" Visible='<%# Eval("IsCurrent") %>' meta:resourcekey="imgIsCurrentResource1" />
            </ItemTemplate>
             <ItemStyle HorizontalAlign="Center" />
         </asp:TemplateField>
         <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Edit poll" ShowSelectButton="True" meta:resourcekey="CommandFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
         <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Folder.gif" CommandName="Archive" meta:resourcekey="ButtonFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:ButtonField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete poll" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource2">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
      </Columns>
      <EmptyDataTemplate><b>
      <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Nopolls %>" />
      </b></EmptyDataTemplate>   
   </asp:GridView>
   <asp:ObjectDataSource ID="objPolls" runat="server" SelectMethod="GetPolls"
      TypeName="UC.BLL.Polls.Poll" DeleteMethod="DeletePoll">
      <DeleteParameters>
         <asp:Parameter Name="id" Type="Int32" />
      </DeleteParameters>
      <SelectParameters>
         <asp:Parameter DefaultValue="true" Name="includeActive" Type="Boolean" />
         <asp:Parameter DefaultValue="false" Name="includeArchived" Type="Boolean" />
      </SelectParameters>
   </asp:ObjectDataSource>
   <p></p>
   <table width="100%">
      <tr>
         <td valign="top" width="50%">
         <asp:DetailsView ID="dvwPoll" runat="server" AutoGenerateRows="False" DataSourceID="objCurrPoll" Width="100%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HeaderText="Poll Details" DataKeyNames="ID" DefaultMode="Insert" OnItemCommand="dvwPoll_ItemCommand" OnItemInserted="dvwPoll_ItemInserted" OnItemUpdated="dvwPoll_ItemUpdated" OnItemCreated="dvwPoll_ItemCreated" meta:resourcekey="dvwPollResource1">
            <FieldHeaderStyle Width="100px" />
            <Fields>
               <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" meta:resourcekey="BoundFieldResource4" />
               <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource5" />
               <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource6" />
               <asp:BoundField DataField="Votes" HeaderText="Votes" ReadOnly="True" InsertVisible="False" meta:resourcekey="BoundFieldResource7" />
               <asp:TemplateField HeaderText="Question" meta:resourcekey="TemplateFieldResource2">
                  <ItemTemplate>
                     <asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("QuestionText") %>' meta:resourcekey="lblQuestionResource1"></asp:Label>
                  </ItemTemplate>
                  <EditItemTemplate>
                     <asp:TextBox ID="txtQuestion" runat="server" Text='<%# Bind("QuestionText") %>' MaxLength="256" Width="100%" meta:resourcekey="txtQuestionResource1"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="valRequireQuestion" runat="server" ControlToValidate="txtQuestion" SetFocusOnError="True"
                        Text="The Question field is required." ToolTip="The Question field is required." Display="Dynamic" ValidationGroup="Poll" meta:resourcekey="valRequireQuestionResource1"></asp:RequiredFieldValidator>
                  </EditItemTemplate>
               </asp:TemplateField>
               <asp:CheckBoxField DataField="IsCurrent" HeaderText="Is Current" meta:resourcekey="CheckBoxFieldResource1" />
            </Fields>
         </asp:DetailsView>
         <asp:ObjectDataSource ID="objCurrPoll" runat="server" InsertMethod="InsertPoll" SelectMethod="GetPollByID" TypeName="UC.BLL.Polls.Poll" UpdateMethod="UpdatePoll">
            <SelectParameters>
               <asp:ControlParameter ControlID="gvwPolls" Name="pollID" PropertyName="SelectedValue"
                  Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
               <asp:Parameter Name="id" Type="Int32" />
               <asp:Parameter Name="questionText" Type="String" />
               <asp:Parameter Name="isCurrent" Type="Boolean" />
            </UpdateParameters>
            <InsertParameters>
               <asp:Parameter Name="questionText" Type="String" />
               <asp:Parameter Name="isCurrent" Type="Boolean" />
            </InsertParameters>
         </asp:ObjectDataSource>
         </td>
         <td valign="top" width="50%">
            <asp:Panel runat="server" ID="panOptions" Visible="False" Width="100%" meta:resourcekey="panOptionsResource1">
            <asp:GridView ID="gvwOptions" runat="server" AutoGenerateColumns="False" DataSourceID="objOptions" DataKeyNames="ID"
               Width="100%" OnRowCreated="gvwOptions_RowCreated" OnRowDeleted="gvwOptions_RowDeleted" OnSelectedIndexChanged="gvwOptions_SelectedIndexChanged" meta:resourcekey="gvwOptionsResource1">
               <Columns>
                  <asp:BoundField DataField="OptionText" HeaderText="Option" meta:resourcekey="BoundFieldResource8">
                     <HeaderStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Votes" HeaderText="Votes" ReadOnly="True" meta:resourcekey="BoundFieldResource9">
                     <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Percentage" DataFormatString="{0:N1}" HtmlEncode="False" HeaderText="%" ReadOnly="True" meta:resourcekey="BoundFieldResource10">
                     <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Edit option" ShowSelectButton="True" meta:resourcekey="CommandFieldResource3">
                     <ItemStyle HorizontalAlign="Center" Width="20px" />
                  </asp:CommandField>
                  <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete option" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource4">
                     <ItemStyle HorizontalAlign="Center" Width="20px" />
                  </asp:CommandField>
               </Columns>
               <EmptyDataTemplate><b>
               <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Nooptions %>" />
               </b></EmptyDataTemplate> 
            </asp:GridView>
            <asp:ObjectDataSource ID="objOptions" runat="server" DeleteMethod="DeleteOption"
               SelectMethod="GetOptions" TypeName="UC.BLL.Polls.Option">
               <DeleteParameters>
                  <asp:Parameter Name="id" Type="Int32" />
               </DeleteParameters>
               <SelectParameters>
                  <asp:ControlParameter ControlID="gvwPolls" Name="pollID" PropertyName="SelectedValue"
                     Type="Int32" />
               </SelectParameters>
            </asp:ObjectDataSource>
            <p></p>
            <asp:DetailsView ID="dvwOption" runat="server" AutoGenerateRows="False" DataSourceID="objCurrOption" Width="100%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HeaderText="Option Details" DataKeyNames="ID" DefaultMode="Insert" OnItemCommand="dvwOption_ItemCommand" OnItemInserted="dvwOption_ItemInserted" OnItemUpdated="dvwOption_ItemUpdated" OnItemCreated="dvwOption_ItemCreated" meta:resourcekey="dvwOptionResource1">
               <FieldHeaderStyle Width="100px" />
               <Fields>
                  <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" meta:resourcekey="BoundFieldResource11" />
                  <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False"
                     ReadOnly="True" meta:resourcekey="BoundFieldResource12" />
                  <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True" meta:resourcekey="BoundFieldResource13" />
                  <asp:BoundField DataField="Votes" HeaderText="Votes" ReadOnly="True" InsertVisible="False" meta:resourcekey="BoundFieldResource14" />
                  <asp:BoundField DataField="Percentage" DataFormatString="{0:N1}" HtmlEncode="False" HeaderText="Percentage" ReadOnly="True" InsertVisible="False" meta:resourcekey="BoundFieldResource15" />
                  <asp:TemplateField HeaderText="Option" meta:resourcekey="TemplateFieldResource3">
                     <ItemTemplate>
                        <asp:Label ID="lblOption" runat="server" Text='<%# Eval("OptionText") %>' meta:resourcekey="lblOptionResource1"></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="txtOption" runat="server" Text='<%# Bind("OptionText") %>' MaxLength="256" Width="100%" meta:resourcekey="txtOptionResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireOption" runat="server" ControlToValidate="txtOption" SetFocusOnError="True"
                           Text="The Option field is required." ToolTip="The Option field is required." Display="Dynamic" ValidationGroup="Option" meta:resourcekey="valRequireOptionResource1"></asp:RequiredFieldValidator>
                     </EditItemTemplate>
                  </asp:TemplateField>
               </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objCurrOption" runat="server" InsertMethod="InsertOption" SelectMethod="GetOptionByID" TypeName="UC.BLL.Polls.Option" UpdateMethod="UpdateOption">
               <SelectParameters>
                  <asp:ControlParameter ControlID="gvwOptions" Name="optionID" PropertyName="SelectedValue"
                     Type="Int32" />
               </SelectParameters>
               <UpdateParameters>
                  <asp:Parameter Name="id" Type="Int32" />
                  <asp:Parameter Name="optionText" Type="String" />
               </UpdateParameters>
               <InsertParameters>
                  <asp:ControlParameter ControlID="gvwPolls" Name="pollID" PropertyName="SelectedValue"
                     Type="Int32" />
                  <asp:Parameter Name="optionText" Type="String" />
               </InsertParameters>
            </asp:ObjectDataSource>
            </asp:Panel>
         </td>
      </tr>
   </table>
</asp:Content>

