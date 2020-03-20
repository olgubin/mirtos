<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Newsletter.aspx.cs" Inherits="UC.UI.ShowNewsletter" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/404.ascx" TagName="Control404" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <mb:Control404 runat="server" ID="ctrl404" />
        <asp:Panel runat="server" ID="pnlContent">
            <br />
            <asp:Panel runat="server" ID="panEditNews" Width="100%" HorizontalAlign="Right">
                <asp:HyperLink runat="server" ID="lnkEditNews" ImageUrl="~/Images/Edit.gif" ToolTip="Редактировать новость"
                    NavigateUrl="~/Admin/AddEditNewsletter.aspx?ID={0}" />&nbsp;<asp:ImageButton runat="server"
                        ID="btnDelete" CausesValidation="false" AlternateText="Удалить новость" ImageUrl="~/Images/Delete.gif"
                        OnClientClick="if (confirm('Подтвердите удаление новости') == false) return false;"
                        OnClick="btnDelete_Click" /></asp:Panel>
            <asp:Label runat="server" ID="lblAddedDate" ForeColor="#9aaab1" Font-Size="Smaller" />
            <h2 style="font-size: small">
                <asp:Literal runat="server" ID="lblSubject" /></h2>
            <div style="padding: 0px 7px 17px 7px; text-align: justify">
                <%--<asp:Label runat="server" ID="lblAbstract" ForeColor="#777777" /><br />
            <br />--%>
                <asp:Literal runat="server" ID="lblHtmlBody" /></div>
        </asp:Panel>
    </div>
</asp:Content>
