<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="StatisticsHosts.aspx.cs" Inherits="UC.UI.Admin.StatisticsHosts"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td><h1>Хосты</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>Показывает уникальные IP адреса (хосты) с которых приходили посетители и количество запросов сделанных с них. Может использоваться для выявления и 
    блокировки нежелательных для учета в статистике адресов.</p>
        <table width="100%">
        <tr>
        <td style="width:50%;padding:7px;">
Всего хостов: 
            <b><asp:Literal runat="server" ID="HostCount"/></b>. Отображать записей на странице:
                <asp:DropDownList ID="ddlHostPerPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRequestsPerPage_SelectedIndexChanged">
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
                    <asp:ListItem Value="100">100</asp:ListItem>
                    <asp:ListItem Value="150">150</asp:ListItem>
                    <asp:ListItem Value="200">200</asp:ListItem>
                </asp:DropDownList>        
        </td>
        <td style="width:50%;padding:7px;vertical-align:middle;">
<b>Адреса не учитываемые в статистике</b>
        </td>
        </tr>
        <tr>
        <td>
            <asp:GridView ID="gvwHosts" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                DataKeyNames="IP" DataSourceID="objHosts" AllowSorting="true" EmptyDataText="<b>Нет данных</b>" OnRowDataBound="gvwHosts_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="IP адрес" DataField="IP" SortExpression="ip"/>
                    <asp:BoundField HeaderText="Первое посещение" DataField="FirstDate" DataFormatString="{0:dd/MM/yy}" ItemStyle-HorizontalAlign="Center" SortExpression="firstdate"/>
                    <asp:BoundField HeaderText="Последняя активность" DataField="LastDate" DataFormatString="{0:dd/MM/yy}" ItemStyle-HorizontalAlign="Center" SortExpression="lastdate"/>
                    <asp:BoundField HeaderText="Посещений" DataField="SessionCount" ItemStyle-HorizontalAlign="Center" SortExpression="sessioncount"/>
                    <asp:BoundField HeaderText="Просмотров" DataField="RequestCount" ItemStyle-HorizontalAlign="Center" SortExpression="requestcount"/>
                </Columns>
                <EmptyDataTemplate>
                    <b>
                        <asp:Literal ID="Literal1" runat="server" Text="Нет данных" />
                    </b>
                </EmptyDataTemplate>
            </asp:GridView>
            <asp:ObjectDataSource ID="objHosts" runat="server" SelectMethod="GetHosts" SelectCountMethod="GetHostCount" EnablePaging="true" 
                 SortParameterName="SortExpression" TypeName="UC.BLL.Statistics.Host"></asp:ObjectDataSource>         
        </td>
        <td style="padding-left:7px">
            <asp:DetailsView ID="dvwIgnoreHosts" runat="server" AutoGenerateRows="False" DataSourceID="objCurrHost" Width="100%" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HeaderText="Игнорировать хост" DataKeyNames="IP" 
            DefaultMode="Insert" OnItemCommand="dvwIgnoreHosts_ItemCommand" OnItemInserted="dvwIgnoreHosts_ItemInserted" OnItemUpdated="dvwIgnoreHosts_ItemUpdated" OnItemCreated="dvwIgnoreHosts_ItemCreated">
               <FieldHeaderStyle Width="120px" />
               <Fields>
                  <asp:TemplateField HeaderText="IP">
                     <ItemTemplate>
                        <asp:Label ID="lblIP" runat="server" Text='<%# Eval("IP") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="IP" runat="server" Text='<%# Bind("IP") %>' MaxLength="15" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireIP" runat="server" ControlToValidate="IP" SetFocusOnError="True"
                           Display="Dynamic" ValidationGroup="Option">обязательно для заполнения</asp:RequiredFieldValidator>
                     </EditItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Comment">
                     <ItemTemplate>
                        <asp:Label ID="lblComment" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                     </ItemTemplate>
                     <EditItemTemplate>
                        <asp:TextBox ID="Comment" runat="server" Text='<%# Bind("Comment") %>' MaxLength="256" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireComment" runat="server" ControlToValidate="Comment" SetFocusOnError="True"
                           Display="Dynamic" ValidationGroup="Option">обязательно для заполнения</asp:RequiredFieldValidator>
                     </EditItemTemplate>
                  </asp:TemplateField>                  
               </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objCurrHost" runat="server" InsertMethod="InsertIgnoreHost" SelectMethod="GetIgnoreHostByIP" TypeName="UC.BLL.Statistics.Host" UpdateMethod="UpdateIgnoreHost">
               <SelectParameters>
                  <asp:ControlParameter ControlID="gvwIgnoreHosts" Name="IP" PropertyName="SelectedValue" Type="String" />
               </SelectParameters>
               <UpdateParameters>
                  <asp:Parameter Name="IP" Type="String" />
                  <asp:Parameter Name="Comment" Type="String" />
               </UpdateParameters>
               <InsertParameters>
                  <asp:ControlParameter ControlID="gvwIgnoreHosts" Name="IP" PropertyName="SelectedValue"
                     Type="String" />
                  <asp:Parameter Name="Comment" Type="String" />
               </InsertParameters>
            </asp:ObjectDataSource>
            <p></p>        
            <asp:GridView ID="gvwIgnoreHosts" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="40" DataSourceID="objIgnoreHosts" DataKeyNames="IP"
               Width="100%" OnRowDeleted="gvwIgnoreHosts_RowDeleted" OnSelectedIndexChanged="gvwIgnoreHosts_SelectedIndexChanged">
               <Columns>
                  <asp:BoundField DataField="IP" HeaderText="IP адрес"></asp:BoundField>
                  <asp:BoundField DataField="Comment" HeaderText="Комментарий">
                     <ItemStyle HorizontalAlign="Justify" />
                  </asp:BoundField>
                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать" ShowSelectButton="True">
                     <ItemStyle HorizontalAlign="Center" Width="20px" />
                  </asp:CommandField>
                  <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить из списка" ShowDeleteButton="True">
                     <ItemStyle HorizontalAlign="Center" Width="20px" />
                  </asp:CommandField>
               </Columns>
               <EmptyDataTemplate><b>
               <asp:Literal ID="Literal1" runat="server" Text="Нет данных"/>
               </b></EmptyDataTemplate> 
            </asp:GridView>
            <asp:ObjectDataSource ID="objIgnoreHosts" runat="server" DeleteMethod="DeleteIgnoreHost"
               SelectMethod="GetIgnoreHosts" TypeName="UC.BLL.Statistics.Host">
               <DeleteParameters>
                  <asp:Parameter Name="IP" Type="String"/>
               </DeleteParameters>
            </asp:ObjectDataSource>
        </td>
        
        
        </tr>
        </table>
    </div>
</asp:Content>
