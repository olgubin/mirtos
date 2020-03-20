<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilterBoxControl.ascx.cs"
    Inherits="UC.UI.Controls.FilterBoxControl" %>
<%@ Register Src="~/Controls/FilterControl.ascx" TagName="FilterControl" TagPrefix="mb" %>
<asp:Panel ID="pnlFilterBox" runat="server">
    <div class="filterBox">
        <asp:Table ID="tblFilter" runat="server">
            <asp:TableRow ID="rowFilter" runat="server">
            </asp:TableRow>
        </asp:Table>
        <asp:ImageButton ID="btnSelect" runat="server" SkinID="ToSelect" OnClick="btnSelect_Click" CssClass="fi"/>
        <asp:LinkButton ID="btnClear" runat="server" Text="Снять фильтры" OnClick="btnClear_Click" CssClass="afi"/>
    </div>
</asp:Panel>
