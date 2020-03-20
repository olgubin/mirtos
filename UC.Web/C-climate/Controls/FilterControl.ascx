<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FilterControl.ascx.cs" Inherits="UC.UI.Controls.FilterControl"%>
<asp:Panel ID="pnlFilter" runat="server" CssClass="filter">
<asp:Label ID="lblName" runat="server" CssClass="filtertitle"/>
    <asp:GridView ID="gvFilterCriteria" runat="server" AutoGenerateColumns="False" DataKeyNames="FilterCriteriaID" SkinID="Filters">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cbCriterion" runat="server" Text ='<%# Eval("Criterion") %>' Checked='<%# Eval("IsMarked") %>'/>
                    <asp:HiddenField ID="hfFilterCriteriaID" runat="server" Value='<%# Eval("FilterCriteriaID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate></EmptyDataTemplate>
    </asp:GridView> 
</asp:Panel>


