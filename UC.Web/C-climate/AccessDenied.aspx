<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="UC.UI.AccessDenied" MasterPageFile="~/Template.master" Culture="auto" UICulture="auto" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="Default.aspx">������������� ������������</a>
                </td>
                <td><h1>�����������</h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
    <p>
    <asp:Label runat="server" ID="lblLoginRequired">
    ��� ��������� ������� � ���� �������� ����� ������������������. ���� �� ��� ����������������, ��������������
    <a href="Login.aspx">������� �����������</a> ������ ��������. ���� �� ����������������, �������������� <a href="Register.aspx">������� �����������</a>.
    </asp:Label>
    <asp:Label runat="server" ID="lblInsufficientPermissions">
    ��������, � ��� ��� ���� ������� � ���� ��������.
    </asp:Label>
    <asp:Label runat="server" ID="lblInvalidCredentials">
    ��������� ���� ������ ���������������. ��������� �� � ���������� �����. 
    ���� �� ������ ������, <a href="PasswordRecovery.aspx">������� �����</a>.
    </asp:Label>
    </p>
</div>
</asp:Content>

