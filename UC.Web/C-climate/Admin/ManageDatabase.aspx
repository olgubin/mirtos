<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="ManageDatabase.aspx.cs"
    Inherits="UC.UI.Admin.ManageDatabase" Culture="auto" UICulture="auto" %>

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
                        ����������������� ��</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
            <p>
                ���������� ��������� �������������: <asp:Label runat="server" ID="lblAnonymousUsersCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteAnonymousUsers" CommandName="DeleteAnonymousUsers" OnCommand="ManageDatabase_Command">������� ��������� �������������</asp:LinkButton>
            </p>
            <p>
                ���������� �������� ��������� �������������: <asp:Label runat="server" ID="lblInnactiveProfileCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteInnactiveProfiles" CommandName="DeleteInnactiveProfiles" OnCommand="ManageDatabase_Command">������� ������� ��������� �������������</asp:LinkButton>
            </p>            
            <p>
                ���������� �������: <asp:Label runat="server" ID="lblWebEventsCount" Font-Bold="true"/>&nbsp&nbsp&nbsp
                <asp:LinkButton runat="server" ID="lbtnDeleteWebEvents" CommandName="DeleteWebEvents" OnCommand="ManageDatabase_Command">������� �������</asp:LinkButton>
            </p>              
    </div>
</asp:Content>
