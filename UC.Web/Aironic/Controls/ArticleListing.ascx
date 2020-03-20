<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleListing.ascx.cs" Inherits="UC.UI.Controls.ArticleListing" %><%@ Register Src="../Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %><%@ Register Src="../Controls/Paging.ascx" TagName="Paging" TagPrefix="mb" %><asp:Literal runat="server" ID="lblCategoryPicker">���������� ���������:</asp:Literal><asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" DataSourceID="objAllCategories" DataTextField="Title" DataValueField="ID" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlCategories_SelectedIndexChanged"><asp:ListItem Value="0">��� ���������</asp:ListItem></asp:DropDownList><asp:ObjectDataSource ID="objAllCategories" runat="server" SelectMethod="GetCategories" TypeName="UC.BLL.Articles.Category"></asp:ObjectDataSource><p /><mb:Paging runat="server" ID="PagingTop" TitleCount="����� ������" /><asp:GridView SkinID="Articles" ID="gvwArticles" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" ShowHeader="False" EmptyDataText="� ���� ��������� ������ ���" OnRowCommand="gvwArticles_RowCommand" OnRowDeleting="gvwArticles_RowDeleting"><Columns><asp:TemplateField HeaderText="������ ������ (� ��� ����� �� ������������)"><HeaderStyle HorizontalAlign="Left" /><ItemTemplate><table cellpadding="0" cellspacing="0" style="width: 100%;"><tr><td rowspan="2" style="width: 25px; padding: 0px"><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/Article.aspx?ID="+Eval("ID") %>' ToolTip='<%# Eval("Title") %>'><asp:Image runat="Server" SkinID="Article" /></asp:HyperLink></td><td style="padding: 0px"><asp:Label runat="server" ID="lblCategoryTitle" Text='<%# Eval("CategoryTitle") %>' Visible='<%# ShowCategoryTitle %>' ForeColor="#d7c5ab"/><div id="articletitle"><asp:HyperLink runat="server" ID="HyperLink1" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/Article.aspx?ID=" + Eval("ID") %>' />&nbsp<mb:RatingDisplay runat="server" ID="RatingDisplay1" Value='<%# Eval("AverageRating") %>' />&nbsp<asp:Image runat="server" ID="Image1" ImageUrl="~/Images/key.gif" AlternateText="������ ��� ������������������ �������������" Visible='<%# (bool)Eval("OnlyForMembers") && !Page.User.Identity.IsAuthenticated %>' />&nbsp<asp:Label runat="server" ID="Label1" Text="�� ����������" SkinID="NotApproved" Visible='<%# !(bool)Eval("Approved") %>' /></div></td><td rowspan="2" style="text-align: right; padding: 0px"><asp:Panel runat="server" ID="panEditArticle" Visible='<%# UserCanEdit %>'><asp:ImageButton runat="server" ID="btnApprove" ImageUrl="~/Images/Ok.gif" CommandName="Approve" CommandArgument='<%# Eval("ID") %>' AlternateText="��������� ������" Visible='<%# !(bool)Eval("Approved") %>' OnClientClick="if (confirm('����������� ����������� ������') == false) return false;" /><asp:HyperLink runat="server" ID="lnkEdit" ToolTip="������������� ������" NavigateUrl='<%# "~/Admin/AddEditArticle.aspx?ID=" + Eval("ID") %>' ImageUrl="~/Images/Edit.gif" /><asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/Delete.gif" CommandName="Delete" AlternateText="������� ������" OnClientClick="if (confirm('����������� �������� ������') == false) return false;" /></asp:Panel></td></tr><tr><td style="padding: 0px"><div class="departmentdescription" style="text-align: justify"><asp:HyperLink ID="HyperLink2" runat="server" Text='<%# Eval("Abstract") %>' NavigateUrl='<%# "~/Article.aspx?ID=" + Eval("ID") %>' /></div></td></tr></table></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate>��� ������ ��� �����������</EmptyDataTemplate></asp:GridView><mb:Paging runat="server" ID="PagingBottom" TitleCount="����� ������" />
