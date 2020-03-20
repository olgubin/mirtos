<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SimpleTextBox.ascx.cs"
    Inherits="UC.UI.Admin.Controls.SimpleTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvValue" ControlToValidate="txtValue" Font-Name="verdana"
    Font-Size="9pt" runat="server" Display="None"></asp:RequiredFieldValidator>
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />
