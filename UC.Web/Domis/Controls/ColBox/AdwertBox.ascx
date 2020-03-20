<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdwertBox.ascx.cs" Inherits="UC.UI.Controls.AdwertBox"
    EnableViewState="false" %>
<asp:Panel runat="server" ID="pnlAdwert" CssClass="box" Visible="false">
    <div class="boxtitle">
        Реклама</div>
    <div class="boxcontent awards">
        <div class="transparent">
        </div>
        <div style="padding-right:3px">
        <object id="turizm" style="width: 100%;" codebase="Images/Banners/turizm.swf" code="Images/Banners/turizm.swf"
            viewastext>
            <param name="movie" value="Images/Banners/turizm.swf">
            <embed src="Images/Banners/turizm.swf" width="100%"></embed>
        </object>
        </div>
    </div>
</asp:Panel>
