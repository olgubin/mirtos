<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdwertBox.ascx.cs" Inherits="UC.UI.Controls.AdwertBox"
    EnableViewState="false" %>
<asp:Panel runat="server" ID="pnlAdwert" CssClass="box" Visible="true">
    <div class="boxtitle">
        Реклама</div>
    <div class="boxcontent awards">
        <div class="transparent">
        </div>
        <div style="padding-right:3px">
<%--        <object id="turizm" style="width: 100%;" codebase="Images/Banners/turizm.swf" code="Images/Banners/turizm.swf"
            viewastext>
            <param name="movie" value="Images/Banners/turizm.swf">
            <embed src="Images/Banners/turizm.swf" width="100%"></embed>
        </object>--%>
        <center>
        <noindex>
        <a href="../Adwert.aspx?ID=1" title="Мебель для ванной, душевые кабины">
        <img src="../images/banners/domis.gif" alt="DOMIS.RU - Мебель для ванной, душевые кабины" title="Мебель для ванной, душевые кабины"/>
        </a></noindex>
        </center>
        </div>
    </div>
</asp:Panel>
