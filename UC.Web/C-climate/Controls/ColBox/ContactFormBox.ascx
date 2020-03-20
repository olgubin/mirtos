<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactFormBox.ascx.cs"
    Inherits="UC.UI.Controls.ContactFormBox" EnableViewState="false" %>
<%@ Register Src="~/Controls/ContactForm.ascx" TagName="ContactForm" TagPrefix="mb" %>
<div class="pollbox" style="padding-top: 7px;">
    <div class="sectiontitle">
        <span>���� ������</span></div>
    <div class="contactformboxcontent">
        <div style="padding: 0px 3px 0px 3px;">
            ��� ������� ��� ���, ������� ����� ����������, ���� �� �������� ��� ���� ���������,
            ����������� � ��������� � ������ ������ ��������.</div>
        <div>
            <asp:Table runat="server" CellPadding="2">
                <asp:TableRow>
                    <asp:TableCell Width="400px">
                        <asp:TextBox runat="server" ID="boxBody" Width="99%" TextMode="MultiLine" Rows="5" /></asp:TableCell></asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                        <asp:ImageButton runat="server" ID="boxSubmit" OnClick="boxSubmit_Click" SkinID="Send"
                            CausesValidation="false" /></asp:TableCell></asp:TableRow>
                <asp:TableRow ID="rowFeedBack" Visible="false">
                    <asp:TableCell ColumnSpan="3" HorizontalAlign="Center">
                        <asp:Label runat="server" ID="lblFeedbackOK" Text="���������� ���. ���� ��������� ������� ����������."
                            SkinID="FeedbackOK" Visible="False" /><asp:Label runat="server" ID="lblFeedbackKO"
                                Text="��������, ���� ��������� �� ����� ���� ����������." SkinID="FeedbackKO"
                                Visible="False" /><asp:Label runat="server" ID="lblValidate" Text="���������� �������� ���������."
                                    SkinID="FeedbackKO" Visible="False" /></asp:TableCell></asp:TableRow>
            </asp:Table>
        </div>
    </div>
</div>
