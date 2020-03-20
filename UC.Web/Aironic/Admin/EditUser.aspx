<%@ Page Language="C#" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="EditUser.aspx.cs" Inherits="UC.UI.Admin.EditUser" Culture="auto" UICulture="auto" %>
<%@ Register Src="../Controls/UserProfile.ascx" TagName="UserProfile" TagPrefix="mb" %>




<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">������������� ������������</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="ManageUsers.aspx">���������� ��������������</a>
                </td>
                <td><h1>���������� � ������������</h1></td>                
            </tr>
        </table>
    </div>
    <div id="content">
    

   <p></p>
   <table width="100%">
      <tr>
         <td style="width: 140px;" class="fieldcaption">
             ��� ��� �����������:
         </td>
         <td class="fieldcaption">
             <asp:Literal runat="server" ID="lblUserName"/>
         </td>
      </tr>
      <tr>
         <td class="fieldcaption">
             ������� ���:
         </td>
         <td class="fieldcaption">
             <asp:Literal runat="server" ID="lblCurrentUserName"/>
         </td>
      </tr>      
      <tr>
         <td class="fieldcaption">
             E-mail:
         </td>
         <td class="fieldcaption"><asp:HyperLink runat="server" ID="lnkEmail"/></td>
      </tr>
      <tr>
         <td class="fieldcaption">
         ���������������:
         </td>
         <td class="fieldcaption"><asp:Literal runat="server" ID="lblRegistered"/></td>
      </tr>
      <tr>
         <td class="fieldcaption">
         ��������� ����:
         </td>
         <td class="fieldcaption"><asp:Literal runat="server" ID="lblLastLogin"/></td>
      </tr>
      <tr>
         <td class="fieldcaption">
         ��������� ����������:
         </td>
         <td class="fieldcaption"><asp:Literal runat="server" ID="lblLastActivity"/></td>
      </tr>
      <tr>
         <td class="fieldcaption"><asp:Label runat="server" ID="lblOnlineNow" AssociatedControlID="chkOnlineNow" Text="������ � �������:"/></td>
         <td class="fieldcaption"><asp:CheckBox runat="server" ID="chkOnlineNow" Enabled="False"/></td>
      </tr>
      <tr>
         <td class="fieldcaption"><asp:Label runat="server" ID="lblApproved" AssociatedControlID="chkApproved" Text="���������:"/></td>
         <td class="fieldcaption"><asp:CheckBox runat="server" ID="chkApproved" AutoPostBack="True" OnCheckedChanged="chkApproved_CheckedChanged"/></td>
      </tr>
      <tr>
         <td class="fieldcaption"><asp:Label runat="server" ID="lblLockedOut" AssociatedControlID="chkLockedOut" Text="������������:"/></td>
         <td class="fieldcaption"><asp:CheckBox runat="server" ID="chkLockedOut" AutoPostBack="True" OnCheckedChanged="chkLockedOut_CheckedChanged"/></td>
      </tr>
   </table>      
   <p></p>
   <div class="sectiontitle">
   <asp:Literal ID="Literal6" runat="server" Text="���� ������������" />
   </div>
   <p></p>
   <asp:CheckBoxList runat="server" ID="chklRoles" RepeatColumns="5" CellSpacing="4"/>
   <table>
      <tr><td>
         <asp:Button runat="server" ID="btnUpdateRoles" Text="���������" OnClick="btnUpdateRoles_Click"/>
      </td></tr>
      <tr>
      <td style="text-align: left;">
         <asp:Label runat="server" ID="lblRolesFeedbackOK" SkinID="FeedbackOK" Text="��������� ���������" Visible="False"/>
      </td>
      </tr>
<%--      <tr><td>
         <asp:Literal ID="Literal7" runat="server" Text="������� ����� ����" />
         <asp:TextBox runat="server" ID="txtNewRole"/>
         <asp:RequiredFieldValidator ID="valRequireNewRole" runat="server" ControlToValidate="txtNewRole" SetFocusOnError="True" ValidationGroup="CreateRole">����������� ��� ����������</asp:RequiredFieldValidator>
         <asp:Button runat="server" ID="btnCreateRole" Text="�������" ValidationGroup="CreateRole" OnClick="btnCreateRole_Click"/>
      </td></tr>--%>
   </table>
   </div>
</asp:Content>

