<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="UC.UI.Admin.ManageUsers" Culture="auto" UICulture="auto" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td class="s"><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td class="s"><asp:Image ID="Image2" runat="server" SkinID="Separator"/> </td>
                <td><h1>Управление пользователями</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
<br />
   <b>
   <asp:Literal ID="Literal1" runat="server" Text="Всего зарегистрировано пользователей" />
   <asp:Literal runat="server" ID="lblTotUsers"/><br />
   <asp:Literal ID="Literal2" runat="server" Text="Пользователи в онлайне" />
   <asp:Literal runat="server" ID="lblOnlineUsers"/></b>
   <p/>
   <asp:Repeater runat="server" ID="rptAlphabet" OnItemCommand="rptAlphabet_ItemCommand">
      <ItemTemplate><asp:LinkButton runat="server" Text='<%# Container.DataItem %>'
         CommandArgument='<%# Container.DataItem %>' meta:resourcekey="LinkButtonResource1" />&nbsp;&nbsp;
      </ItemTemplate>
   </asp:Repeater>
   <p/>
   <asp:Panel runat="server" DefaultButton="btnSearch">
   <asp:DropDownList runat="server" ID="ddlSearchTypes">
      <asp:ListItem Text="Имя" Selected="True"/>
      <asp:ListItem Text="E-mail"/>
   </asp:DropDownList> 
   <asp:Literal ID="Literal5" runat="server" Text="содержит" />
   <asp:TextBox runat="server" ID="txtSearchText"/> 
   <asp:Button runat="server" ID="btnSearch" Text="Найти" OnClick="btnSearch_Click"/>
   </asp:Panel>
   <p></p>
   <asp:GridView ID="gvwUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName"
      OnRowCreated="gvwUsers_RowCreated" OnRowDeleting="gvwUsers_RowDeleting">
      <Columns>
      <asp:TemplateField HeaderText="Имя">
      <ItemTemplate><%#Eval("Comment")%><br /><small>(<%#Eval("UserName")%>)</small></ItemTemplate>
      </asp:TemplateField>
         <asp:HyperLinkField HeaderText="E-mail" DataTextField="Email" DataNavigateUrlFormatString="mailto:{0}" DataNavigateUrlFields="Email"/>
         <asp:BoundField HeaderText="Создан" DataField="CreationDate" DataFormatString="{0:dd/MM/yy} {0:t}"/>
         <asp:BoundField HeaderText="Последний вход" DataField="LastActivityDate" DataFormatString="{0:dd/MM/yy} {0:t}"/>
         <asp:CheckBoxField HeaderText="Разрешен" DataField="IsApproved">
             <ItemStyle HorizontalAlign="Center" />
             <HeaderStyle HorizontalAlign="Center" />
         </asp:CheckBoxField>
         <asp:HyperLinkField Text="&lt;img src='../images/edit.gif' border='0' /&gt;" DataNavigateUrlFormatString="EditUser.aspx?UserName={0}" DataNavigateUrlFields="UserName" meta:resourcekey="HyperLinkFieldResource2" />
         <asp:ButtonField CommandName="Delete" ButtonType="Image" ImageUrl="~/images/delete.gif" meta:resourcekey="ButtonFieldResource1" />
      </Columns>
      <EmptyDataTemplate><b>
      <asp:Literal ID="Literal5" runat="server" Text="Пользователи ненайдены." />
      </b></EmptyDataTemplate>
   </asp:GridView>
   </div>
</asp:Content>

