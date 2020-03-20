<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ArchivedPolls.aspx.cs" Inherits="UC.UI.ArchivedPolls" Culture="auto" UICulture="auto" %>
<%@ Reference Control="Controls/ColBox/PollBox.ascx" %>
<%@ Register Src="Controls/ColBox/PollBox.ascx" TagName="PollBox" TagPrefix="mb" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">   
   <script type="text/javascript">
      function toggleDivState(divName)
      {
         var ctl = window.document.getElementById(divName);
         if (ctl.style.display == "none")
            ctl.style.display = "";
         else
            ctl.style.display = "none";
      }
   </script>

   <div class="sectiontitle">
   <asp:Literal runat="server" Text="<%$ resources:ArchivedPolls %>" />
   </div>
   <p>
   <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Comment %>" />
   </p>
   <asp:GridView ID="gvwPolls" runat="server" AutoGenerateColumns="False" DataSourceID="objPolls" Width="100%" DataKeyNames="ID" OnRowCreated="gvwPolls_RowCreated" ShowHeader="False" meta:resourcekey="gvwPollsResource1">
      <Columns>
         <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
               <img src="images/arrowr2.gif" alt="" style="vertical-align: middle; border-width: 0px;" />
               <a href="javascript:toggleDivState('poll<%# Eval("ID") %>');">               
               <%# Eval("QuestionText") %></a>
               <small>(<asp:Literal ID="Literal1" runat="server" Text="<%$ resources:archivedon %>" /> <%# Eval("ArchivedDate", "{0:d}") %>)</small>
               <div style="display: none;" id="poll<%# Eval("ID") %>">
               <mb:PollBox id="PollBox1" runat="server"
                  ShowHeader="False" ShowQuestion="False" ShowArchiveLink="False" />
               </div>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete poll" ShowDeleteButton="True" meta:resourcekey="CommandFieldResource1">
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
         <asp:Parameter DefaultValue="false" Name="includeActive" Type="Boolean" />
         <asp:Parameter DefaultValue="true" Name="includeArchived" Type="Boolean" />
      </SelectParameters>
   </asp:ObjectDataSource>
</asp:Content>

