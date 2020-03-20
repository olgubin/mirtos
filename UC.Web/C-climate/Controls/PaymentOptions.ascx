<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentOptions.ascx.cs"
    Inherits="UC.UI.Controls.PaymentOptions" %>
<div id="Juridical" class="displayDIV" style="clear: both; width: 100%; float: right;
    padding-bottom: 17px;">
    <table width="100%">
        <tr>
            <td class="fieldcaption" style="width: 25%;">
                <b style="color: Red;">*</b> Название организации:
            </td>
            <td class="fieldtext" style="width: 25%">
                <asp:TextBox runat="server" ID="txtOrganization" Width="99%" TabIndex="1"/>
                <asp:RequiredFieldValidator ID="valRequireOrgName" runat="server" ControlToValidate="txtOrganization"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
            <td style="width: 25%">
            </td>
            <td style="width: 25%;">
            </td>
        </tr>
        <tr style="background-color: #F4EECC">
            <td class="fieldcaption">
                <b style="color: Red;">*</b> Юридический адрес:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtJurAddress" Width="99%" TextMode="MultiLine" Rows="4" TabIndex="2"/>
                <asp:RequiredFieldValidator ID="valRequireJurAddress" runat="server" ControlToValidate="txtJurAddress"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
            <td class="fieldcaption">
                Почтовый адрес:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtPostAddress" Width="99%" TextMode="MultiLine" Rows="4" TabIndex="7"/>
            </td>
        </tr>
        <tr>
            <td class="fieldcaption">
                <b style="color: Red;">*</b> ИНН:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtINN" Width="99%" TabIndex="3"/>
                <asp:RequiredFieldValidator ID="valRequireINN" runat="server" ControlToValidate="txtINN"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
            <td class="fieldcaption">
                <b style="color: Red;">*</b> Расчетный счет:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtAccount" Width="99%" TabIndex="8"/>
                <asp:RequiredFieldValidator ID="valRequireAccount" runat="server" ControlToValidate="txtAccount"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="background-color: #F4EECC">
            <td class="fieldcaption">
                <b style="color: Red;">*</b> КПП:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtKPP" Width="99%" TabIndex="4"/>
                <asp:RequiredFieldValidator ID="valRequireKPP" runat="server" ControlToValidate="txtKPP"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
            <td class="fieldcaption">
                Корреспондентский счет:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtCorrAccount" Width="99%" TabIndex="9"/>
            </td>
        </tr>
        <tr>
            <td class="fieldcaption">
                Код ОКПО:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtOKPO" Width="99%" TabIndex="5"/>
            </td>
            <td class="fieldcaption">
                <b style="color: Red;">*</b> Банк:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtBank" Width="99%" TabIndex="10"/>
                <asp:RequiredFieldValidator ID="valRequireBank" runat="server" ControlToValidate="txtBank"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="background-color: #F4EECC">
            <td class="fieldcaption">
                Код ОКОНХ:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtOKONH" Width="99%" TabIndex="6"/>
            </td>
            <td class="fieldcaption">
                <b style="color: Red;">*</b> БИК:
            </td>
            <td class="fieldtext">
                <asp:TextBox runat="server" ID="txtBIK" Width="99%" TabIndex="11"/>
                <asp:RequiredFieldValidator ID="valRequireBIK" runat="server" ControlToValidate="txtBIK"
                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Payer">обязательно для заполнения</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</div>
