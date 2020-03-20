<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactForm.ascx.cs" Inherits="UC.UI.Controls.ContactForm" %>
<asp:Panel runat="server" ID="pnlTitle">
    <p>
        <asp:Label runat="server" ID="lblTitle" Text='<%# Title %>'></asp:Label></p>
</asp:Panel>
<div>
    <asp:Table runat="server" CellPadding="2">
        <asp:TableRow ID="rowSubject">
            <asp:TableCell ID="cellSubjectCaption" CssClass="fieldname">
                <asp:Label runat="server" ID="lblSubject" AssociatedControlID="txtSubject" Text="Тема сообщения:" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtSubject" Width="100%" meta:resourcekey="txtSubjectResource1" />
            </asp:TableCell>
            <asp:TableCell>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="valRequireSubject"
                        ValidationGroup="Contact" SetFocusOnError="True" ControlToValidate="txtSubject"
                        ErrorMessage="Пожалуйста укажите тему сообщения.">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ID="cellBodyCaption" CssClass="fieldname">
                <asp:Label runat="server" ID="lblBody" AssociatedControlID="txtBody" Text="Текст сообщения:" />
            </asp:TableCell>
            <asp:TableCell Width="233px">
                <asp:TextBox runat="server" ID="txtBody" Width="100%" TextMode="MultiLine" /></asp:TableCell>
            <asp:TableCell>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="valRequireBody"
                        ValidationGroup="Contact" SetFocusOnError="True" ControlToValidate="txtBody"
                        ErrorMessage="Пожалуйста введите сообщение.">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowName">
            <asp:TableCell ID="cellNameCaption" CssClass="fieldname">
                <asp:Label runat="server" ID="lblName" AssociatedControlID="txtName" Text="Ваше имя:" />
            </asp:TableCell>
            <asp:TableCell Width="233px">
                    <asp:TextBox runat="server" ID="txtName" Width="100%" meta:resourcekey="txtNameResource1" />
            </asp:TableCell>
            <asp:TableCell>
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="Contact" Display="Dynamic"
                            ID="valRequireName" SetFocusOnError="True" ControlToValidate="txtName" ErrorMessage="Пожалуйста укажите Ваше имя">*</asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="rowEmail">
            <asp:TableCell ID="cellEmailCaption" CssClass="fieldname">
                <asp:Label runat="server" ID="lblEmail" AssociatedControlID="txtEmail" Text="Ваш e-mail:" />
            </asp:TableCell>
            <asp:TableCell>
                    <asp:TextBox runat="server" ID="txtEmail" Width="100%" meta:resourcekey="txtEmailResource1" />
            </asp:TableCell>
            <asp:TableCell>
                        <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="valRequireEmail"
                            ValidationGroup="Contact" SetFocusOnError="True" ControlToValidate="txtEmail"
                            ErrorMessage="Пожалуйста укажите Ваш e-mail.">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                runat="server" Display="Dynamic" ID="valEmailPattern" SetFocusOnError="True"
                                ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="E-mail адрес не соответствует формату адреса электронной почты.">*</asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" HorizontalAlign="Right">
                <asp:Label runat="server" ID="lblFeedbackOK" Text="Благодарим Вас. Ваше сообщение успешно доставлено."
                    SkinID="FeedbackOK" Visible="False" /><asp:Label runat="server" ID="lblFeedbackKO"
                        Text="Извините, Ваше сообщение не может быть отправлено." SkinID="FeedbackKO"
                        Visible="False" /><asp:ImageButton runat="server" ID="txtSubmit" OnClick="txtSubmit_Click"
                            SkinID="Send" ValidationGroup="Contact" /><asp:ValidationSummary runat="server" ID="valSummary"
                                ShowSummary="False" ShowMessageBox="True" ValidationGroup="Contact" />
            </asp:TableCell>
       </asp:TableRow>
    </asp:Table>
</div>
