<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CurrencyControl.ascx.cs"
    Inherits="UC.UI.Controls.CurrencyControl" %>
<asp:Panel runat="server" ID="pnlCaption" CssClass="adwert_caption">Валюта:</asp:Panel>
<div style="float:left; padding:3px"><asp:ImageButton runat="server" ID="imgbtnRUR" OnCommand="CurrencyChange" CommandName="RUR" ToolTip="Цена в рублях"/></div>
<div style="float:left; padding:3px"><asp:ImageButton runat="server" ID="imgbtnUSD" OnCommand="CurrencyChange" CommandName="USD" ToolTip="Цена в долларах"/></div>
<div style="float:left; padding:3px"><asp:ImageButton runat="server" ID="imgbtnEUR" OnCommand=  "CurrencyChange" CommandName="EUR" ToolTip="Цена в евро"/></div>
