<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUploader.ascx.cs" Inherits="UC.UI.Controls.FileUploader" %>
<asp:Literal runat="server" Text="<%$ resources:Uploadfile %>" />
<asp:FileUpload ID="filUpload" runat="server" Width="500px"/>&nbsp;
<asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" CausesValidation="False" meta:resourcekey="btnUploadResource1" /><br />
<asp:Label ID="lblFeedbackOK" SkinID="FeedbackOK" runat="server" ></asp:Label>
<asp:Label ID="lblFeedbackKO" SkinID="FeedbackKO" runat="server" ></asp:Label>
