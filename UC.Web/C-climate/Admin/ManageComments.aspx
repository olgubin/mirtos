<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="ManageComments.aspx.cs" Inherits="UC.UI.Admin.ManageComments"%>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Климатическое оборудование</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Управление комментариями</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
<br />
   Отображать на странице:
   <asp:DropDownList ID="ddlCommentsPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCommentsPerPage_SelectedIndexChanged">
      <asp:ListItem Value="5">5</asp:ListItem>
      <asp:ListItem Value="10">10</asp:ListItem>
      <asp:ListItem Value="25" Selected="True">25</asp:ListItem>
      <asp:ListItem Value="50">50</asp:ListItem>   
      <asp:ListItem Value="100">100</asp:ListItem>
   </asp:DropDownList>
   <p></p>
   <asp:GridView ID="gvwComments" runat="server"  AllowPaging="True" AutoGenerateColumns="False"
      DataKeyNames="ID" DataSourceID="objComments" PageSize="25" ShowHeader="false"
      EmptyDataText="Нет комментариев" OnRowCreated="gvwComments_RowCreated" OnPageIndexChanged="gvwComments_PageIndexChanged" OnRowDeleted="gvwComments_RowDeleted" OnSelectedIndexChanged="gvwComments_SelectedIndexChanged">
      <Columns>
         <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <div class="comment">
               Комментарий оставлен <asp:HyperLink ID="lnkAddedBy" runat="server" Text='<%# Eval("AddedBy") %>'
                  NavigateUrl='<%# "mailto:" + Eval("AddedByEmail") %>' />
               от <asp:Literal ID="lblAddedDate" runat="server" Text='<%# Eval("AddedDate", "{0:f}") %>' />
               <br />Статья: 
               <asp:HyperLink runat="server" ID="lnkArticle" Text='<%# Eval("ArticleTitle") %>' NavigateUrl='<%# "~/Article.aspx?ID=" + Eval("ArticleID") %>' />
               <br />               
               <asp:Literal ID="lblBody" runat="server" Text='<%# Eval("EncodedBody") %>' />         
               </div>
            </ItemTemplate>
         </asp:TemplateField>
         <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать комментарий" ShowSelectButton="True">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
         <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить комментарий" ShowDeleteButton="True">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
         </asp:CommandField>
      </Columns>
      <EmptyDataTemplate>Нет комментариев</EmptyDataTemplate>   
   </asp:GridView>
   <asp:ObjectDataSource ID="objComments" runat="server" DeleteMethod="DeleteComment"
      SelectMethod="GetComments" SelectCountMethod="GetCommentCount" EnablePaging="true" TypeName="UC.BLL.Articles.Comment">
      <DeleteParameters>
         <asp:Parameter Name="id" Type="Int32" />
      </DeleteParameters>
   </asp:ObjectDataSource>
   <p></p>
   <asp:DetailsView id="dvwComment" runat="server" AutoGenerateEditButton="true" 
      HeaderText="Редактирование комментария" AutoGenerateRows="False" DataSourceID="objCurrComment" DefaultMode="ReadOnly" 
      OnItemCommand="dvwComment_ItemCommand" DataKeyNames="ID" OnItemUpdated="dvwComment_ItemUpdated">
      <FieldHeaderStyle Width="117px"/>      
      <Fields>
         <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />         
         <asp:BoundField DataField="AddedDate" HeaderText="Дата добавления" ReadOnly="True"/>
         <asp:BoundField DataField="AddedByIP" HeaderText="IP" ReadOnly="True" />
         <asp:HyperLinkField DataNavigateUrlFormatString="mailto:{0}" DataNavigateUrlFields="AddedByEmail"
            DataTextField="AddedBy" HeaderText="Добавил" />
         <asp:TemplateField HeaderText="Комментарий">
            <ItemTemplate>
               <asp:Label ID="lblBody" runat="server" Text='<%# Eval("Body") %>' />
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="txtBody" runat="server" Text='<%# Bind("Body") %>' TextMode="MultiLine" Rows="5" Width="99%"></asp:TextBox>
               <asp:RequiredFieldValidator ID="valRequireBody" runat="server" ControlToValidate="txtBody" SetFocusOnError="true" Display="Dynamic">обязательно для заполнения</asp:RequiredFieldValidator>
            </EditItemTemplate>
         </asp:TemplateField>
      </Fields>
   </asp:DetailsView>   
   <asp:ObjectDataSource ID="objCurrComment" runat="server"
      SelectMethod="GetCommentByID" TypeName="UC.BLL.Articles.Comment"
      UpdateMethod="UpdateComment">
      <UpdateParameters>
         <asp:Parameter Name="id" Type="Int32" />
         <asp:Parameter Name="body" Type="String" />
      </UpdateParameters>
      <SelectParameters>
         <asp:ControlParameter ControlID="gvwComments" Name="commentID" PropertyName="SelectedValue" Type="Int32" />
      </SelectParameters>
   </asp:ObjectDataSource>
   </div>
</asp:Content>
