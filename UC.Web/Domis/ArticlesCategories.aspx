<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ArticlesCategories.aspx.cs" Inherits="UC.UI.ArticlesCategories" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="~/Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        Статьи</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <br />
        <asp:DataList ID="dlstCategories" runat="server" DataSourceID="objAllCategories"
            DataKeyField="ID" GridLines="None" Width="100%" RepeatColumns="1" OnItemDataBound="dlstCategories_ItemDataBound"
            BorderWidth="0px">
            <ItemTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td rowspan="3" style="width: 87px">
                            <div class="departmentimage">
                                <asp:HyperLink runat="server" ID="lnkCatImage" NavigateUrl='<%# "Articles.aspx?CatID=" + Eval("ID") %>'>
                                    <asp:Image runat="server" ID="imgCategory" BorderWidth="0px" AlternateText='<%# Eval("Title") %>'
                                        ImageUrl='<%# Eval("ImageUrl") %>' /></asp:HyperLink></div>
                        </td>
                        <td style="padding: 0px;">
                            <div class="departmenttitle">
                                <asp:HyperLink runat="server" ID="lnkCatTitle" Text='<%# Eval("Title") %>' NavigateUrl='<%# "Articles.aspx?CatID=" + Eval("ID") %>' /><%--ForeColor="#9aaab1"--%><%--<asp:HyperLink runat="server" ID="lnkCatRss" NavigateUrl='<%# "GetArticlesRss.aspx?CatID=" + Eval("ID") %>'>&nbsp<img style="border-width: 0px;" src="Images/rss.gif" alt="RSS лента этой категории" /></asp:HyperLink>--%></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px;">
                            <asp:GridView ID="gvwArticlesbyCategory" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="ID" ShowHeader="False" EmptyDataText="В этой категории статей нет"
                                SkinID="Articles" BorderWidth="0px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Список статей (в том числе неопубликованные)">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td rowspan="2" style="width: 25px; padding: 0px">
                                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "~/Article.aspx?ID="+Eval("ID") %>'
                                                            ToolTip='<%# Eval("Title") %>'>
                                                            <asp:Image ID="Image2" runat="Server" SkinID="Article" /></asp:HyperLink>
                                                    </td>
                                                    <td style="padding: 0px;">
                                                        <div id="articletitle">
                                                            <asp:HyperLink runat="server" ID="lnkTitle" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/Article.aspx?ID=" + Eval("ID") %>' />&nbsp<mb:RatingDisplay
                                                                runat="server" ID="ratDisplay" Value='<%# Eval("AverageRating") %>' />
                                                            &nbsp<asp:Image runat="server" ID="imgKey" ImageUrl="~/Images/key.gif" AlternateText="Только для зарегистрированных пользователей"
                                                                Visible='<%# (bool)Eval("OnlyForMembers") && !Page.User.Identity.IsAuthenticated %>' />&nbsp<asp:Label
                                                                    runat="server" ID="lblNotApproved" Text="Не утверждена" SkinID="NotApproved"
                                                                    Visible='<%# !(bool)Eval("Approved") %>' /></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 0px;">
                                                        <div class="departmentdescription">
                                                            <asp:HyperLink runat="server" Text='<%# Eval("Abstract") %>' NavigateUrl='<%# "~/Article.aspx?ID=" + Eval("ID") %>' /></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    В этой категории статей нет</EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <div id="all">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Articles.aspx?CatID=" + Eval("ID") %>'>
                                    <%# "Все статьи раздела (" + GetArticlesCount(Convert.ToInt32(Eval("ID"))) + ") "%>
                                    <asp:Image ID="Image3" runat="Server" SkinID="All" /></asp:HyperLink></div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList><asp:ObjectDataSource ID="objAllCategories" runat="server" SelectMethod="GetCategories"
            TypeName="UC.BLL.Articles.Category"></asp:ObjectDataSource>
    </div>
</asp:Content>
