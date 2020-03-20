<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentMethod.ascx.cs"
    Inherits="UC.UI.Controls.PaymentMethod" %>
<table>
    <tr style="background-color: #fef7f8">
        <td>
            <asp:RadioButton runat="server" ID="rbtnCash" GroupName="Payment" Checked="true" />
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="rbtnCash">
                            <strong>������ ���������</strong>
                            <br/>
                            �� ����������� ����� ��������� ��� ��������. ������ ������������ ������ � ������.
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:RadioButton runat="server" ID="rbtnTranslation" GroupName="Payment"/>
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rbtnTranslation">
<strong>���������� �������</strong>
<br/>
��� �� e-mail ��� ���� (�� �������) ���������� ���� � ����������� ��� ������. � ���� "���������� �������" ������� ������� ����� ������������� �����, ��� ���� � ���. ��������, "�� ����� �� ����� �8734 �� 01.01.2009. ��� ���.". �������� ������ �������������� � ������� 1 ���.
            </asp:Label>
        </td>
    </tr>
    <tr style="background-color: #fef7f8">
        <td>
            <asp:RadioButton runat="server" ID="rbtnWire" GroupName="Payment" />
        </td>
        <td class="fieldcaption">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="rbtnWire">
<strong>����������� ������</strong>
(������ ��� ����������� ���)
<br/>
��� ������ ������ �� ������������ ������� ����������� ����� ����� ����������� ������ ���������� ����.
            </asp:Label>
        </td>
    </tr>
</table>
