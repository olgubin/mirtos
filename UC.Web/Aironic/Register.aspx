<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="UC.UI.Register" Culture="auto" UICulture="auto" %>

<%@ Register Src="Controls/Register.ascx" TagName="Register" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">�������</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>�����������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <br />
        <p>
            ��������� ���������� ��������������� �����. ��������� e-mail � ������ �����������,
            � ����������, ��� ����������� � ����� ��������. ����, ���������� <span style="color: Red">
                *</span>, ����������� ��� ����������.</p>
        <asp:Panel runat="server" DefaultButton="btnEnter">
            <mb:Register runat="server" ID="Reg" BodyFileName="~/RegistrationMail.txt" From="info@aironic.ru"
                FromCaption="AIRONIC.RU �������� ������������" Subject="��������������� ������" />
            <br />
            <asp:Button ID="btnEnter" runat="server" ValidationGroup="Register" CssClass="enter"
                Text="������������������" OnClick="btnEnter_Click" Width="177px" /></asp:Panel>
    </div>
</asp:Content>
