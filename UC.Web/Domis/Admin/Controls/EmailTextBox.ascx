<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmailTextBox.ascx.cs"
    Inherits="UC.UI.Admin.Controls.EmailTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:TextBox ID="txtValue" runat="server" ></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvValue" runat="server" ControlToValidate="txtValue"
    ErrorMessage="Поле обязательно для заполнения" Display="None" />
<asp:RegularExpressionValidator ID="revValue" runat="server" ControlToValidate="txtValue"
    ValidationExpression=".+@.+\..+" ErrorMessage="Неверны формат email" Display="None" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="rfvValueE" TargetControlID="rfvValue"
    HighlightCssClass="validatorCalloutHighlight" />
<ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="revValueE" TargetControlID="revValue"
    HighlightCssClass="validatorCalloutHighlight" />
