<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentMenu.ascx.cs"
    Inherits="UC.UI.Controls.DepartmentMenu" EnableViewState="false" %>
    
    
<div class="box">
    <div class="boxtitle">Каталог</div>
    
    <div class="boxcontent departmentmenu">
    <div class="transparent"></div>
        <asp:DataList ID="dlstDepartments" EnableTheming="false" runat="server"
            GridLines="None" Width="100%" RepeatColumns="1">
            <ItemTemplate>
                <div class="menuitem">
                    <asp:HyperLink runat="server" ID="lnkDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# UC.SEOHelper.SeoHelper.GetDepartmentUrl((int)Eval("DepartmentID")) %>' />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    
</div>
