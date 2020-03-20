<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="ManageNewsletters.aspx.cs" Inherits="UC.UI.Admin.ManageNewsletters"%>

<%@ Register Src="../Controls/NewsletterListing.ascx" TagName="NewsletterListing"
    TagPrefix="mb" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
            <table>
                <tr>
                <td class="h1">
                    <a href="../Default.aspx">�������</a>
                </td>
                <td><asp:Image ID="Image1" runat="server" SkinID="Separator"/> </td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td><asp:Image ID="Image2" runat="server" SkinID="Separator"/> </td>
                <td><h1>���������� ���������</h1></td>
                </tr>
            </table>
    </div>
    <div id="content">
        <asp:Panel runat="server" ID="panSend">
            <ul style="list-style-type: square">
                <li>
                    <asp:HyperLink runat="server" NavigateUrl="AddEditNewsletter.aspx">�������� �������</asp:HyperLink></li>
            </ul>
            <p />
            <mb:NewsletterListing ID="NewsletterListing" runat="server" />
            <p />
            <asp:Button ID="btnSend" runat="server" Text="��������� ������������� �������" ValidationGroup="Newsletter"
                OnClientClick="if (confirm('����������� �������� �������') == false) return false;"
                OnClick="btnSend_Click" Width="250px"/><br />
            <asp:Label ID="FailureText" SkinID="FeedbackKO" runat="server" EnableViewState="False"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="panWait" runat="server" Visible="false">
            <asp:Label runat="server" ID="lblWait" SkinID="FeedbackKO">
      <p>���������� �������� ���������. ���������� ��������� �� ���������� ��������.</p>
      <p>�� ������ ��������� ������� ������ �������� <a href="SendingNewsletter.aspx">�����</a>.</p>
            </asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
