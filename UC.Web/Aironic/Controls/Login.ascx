<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="UC.UI.Controls.Login" %><asp:Panel runat="server" DefaultButton="btnEnter"><table width="100%"><tr><td style="width:63px"><asp:Label runat="server" ID="lblUserName" AssociatedControlID="UserName" Text="E-mail:" Font-Bold="true"/></td><td style="width:137px"><asp:TextBox ID="UserName" runat="server" Width="98%"/><asp:RequiredFieldValidator ID="valRequireUserName" runat="server" SetFocusOnError="True" ControlToValidate="UserName" ValidationGroup="Login" Display="Dynamic">����������� ��� ����������</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label runat="server" ID="lblPassword" AssociatedControlID="Password" Text="������:" Font-Bold="true"/></td><td><asp:TextBox ID="Password" runat="server" TextMode="Password" Width="98%"/><asp:RequiredFieldValidator ID="valRequirePassword" runat="server" SetFocusOnError="True" ControlToValidate="Password" ValidationGroup="Login" Display="Dynamic">����������� ��� ����������</asp:RequiredFieldValidator></td></tr><tr><td colspan="2" style="text-align:right;"><asp:Button ID="btnEnter" runat="server" CommandName="Login" ValidationGroup="Login" CssClass="enter" Text="����" OnClick="btnEnter_Click" /><br /><asp:Label ID="FailureText" SkinID="FeedbackKO" runat="server" EnableViewState="False"></asp:Label></td></tr></table></asp:Panel>
