<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreadCrumb.ascx.cs" Inherits="UC.UI.Controls.BreadCrumb" %>
<%@ Import Namespace="UC.SEOHelper" %>
<div style="position: relative;">
    <div class="boxtop_middle">
    </div>
    <div class="boxtop_left">
    </div>
    <div class="boxtop_right">
    </div>
</div>
<div class="brdmiddle">
    <div class="brdmiddle_middle">
        <div class="breadcrumb">
            <asp:Panel runat="server" ID="pnlBreadCrumb" Width="100%">
                <asp:HyperLink ID="_hlnkMain" runat="server" EnableViewState="false" Text="Главная" /></asp:Panel>
        </div>
    </div>
    <div class="brdmiddle_left">
    </div>
    <div class="brdmiddle_right">
    </div>
</div>
<div class="boxbottom">
    <div class="boxbottom_middle">
    </div>
    <div class="boxbottom_left">
    </div>
    <div class="boxbottom_right">
    </div>
</div>
