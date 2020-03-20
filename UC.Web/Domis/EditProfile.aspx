<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="EditProfile.aspx.cs" Inherits="UC.UI.EditProfile" Culture="auto"
    UICulture="auto" %>
<%@ Register Src="Controls/UserProfile.ascx" TagName="UserProfile" TagPrefix="mb" %>
<%@ Register Src="Controls/ChangePassword.ascx" TagName="ChangePassword" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">������ ��� ������</asp:HyperLink></td>
                <td><h1><asp:Label runat="server" ID="lblTitle" Text="��� ������" /></h1></td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>������ ������ ������������ ��� ����������� � ����� ��������, � ����� ��� ��������� � ��� �� ��������� �������� � �� ����������� �����. � ���� ������� �� ������ �������� ������ ������ ��������� ��� �����������. ����, ���������� <span style="color:Red">*</span>, ����������� ��� ����������.</p>
        <table width="100%">
            <tr>
                <td style="width: 50%;">
                     <mb:UserProfile ID="UserProfile1" runat="server" From="info@domis.ru" FromCaption="DOMIS.RU ������ ��� ������" BodyFileName="~/ChangeProfileMail.txt" Subject="��������� ��������������� ������"/>
                </td>
                <td style="width: 50%">
                    <table width="100%">
                        <tr style="background-color: #fef7f8">
                            <td class="fieldcaption">
                                ����� ������
                            </td>
                        </tr>
                        <tr>
                            <td>
                            <mb:ChangePassword runat="server" From="info@domis.ru" FromCaption="DOMIS.RU ������ ��� ������" BodyFileName="~/ChangePasswordMail.txt" Subject="��������� ������"/>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>        
    </div>
</asp:Content>
