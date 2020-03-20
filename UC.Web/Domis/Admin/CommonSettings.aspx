<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="CommonSettings.aspx.cs" Inherits="UC.UI.Admin.CommonSettings" Culture="auto"
    UICulture="auto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="mb" TagName="SimpleTextBox" Src="~/Admin/Controls/SimpleTextBox.ascx" %>
<%@ Register TagPrefix="mb" TagName="NumericTextBox" Src="~/Admin/Controls/NumericTextBox.ascx" %>
<%@ Register TagPrefix="mb" TagName="EmailTextBox" Src="~/Admin/Controls/EmailTextBox.ascx" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">�������</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        ����� ���������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <div class="description">
            <h2>
                ����� ���������</h2>
        </div>
        <table style="width: 100%" cellpadding="2px">
            <tr>
                <td style="width: 20%">
                    �������� ��������:
                </td>
                <td style="width: 80%">
                    <mb:SimpleTextBox runat="server" ID="txtStoreName" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    URL ��������:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="txtStoreURL" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ����� ��������:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="txtDomen" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ����������� ����:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="txtCompany" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    �������:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="txtPhone" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ������ ������ ��������:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="txtWorkPeriod" CssClass="adminInput" ErrorMessage="����������� ��� ����������"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ����� ��� ��������:
                </td>
                <td>
                    <mb:EmailTextBox runat="server" CssClass="adminInput" ID="txtMailTo" Width="99%">
                    </mb:EmailTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    ����� ��� �������:
                </td>
                <td>
                    <mb:EmailTextBox runat="server" CssClass="adminInput" ID="txtZakazTo" Width="99%">
                    </mb:EmailTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Header Title:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="headerTitle" CssClass="adminInput" Width="99%">
                    </mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Header Description:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="headerDescription" CssClass="adminInput" Width="99%">
                    </mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Header Keywords:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="headerKeywords" CssClass="adminInput" Width="99%">
                    </mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Header Yandex Verification:
                </td>
                <td>
                    <mb:SimpleTextBox runat="server" ID="headerYandexVerification" CssClass="adminInput"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
            <tr>
                <td class="adminTitle">
                    Header Google Verification:
                </td>
                <td class="adminData">
                    <mb:SimpleTextBox runat="server" ID="headerGoogleVerification" CssClass="adminInput"
                        Width="99%"></mb:SimpleTextBox>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button runat="server" Text="���������" CssClass="adminButton" ID="btnSave" OnClick="btnSave_Click" />
        </p>
    </div>
</asp:Content>
