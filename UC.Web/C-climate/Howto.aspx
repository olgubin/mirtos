<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Howto.aspx.cs" Inherits="UC.UI.Howto" MasterPageFile="~/Template.master" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">������������� ������������</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        ���������� ������</h1>
                </td>
            </tr>
        </table>
    </div>    
    <div id="content">
        <br/>
        <b>����� �������</b>
        <br/>
        <br/>
        �� ������ ������� ����� � ������������ � ����������� ��������, � ��� �� ����������������
        ��������� ��������, ������ � ������� ������ �� ����� ������������ ��� ������.
        <br/>
        <br/>
<p align="justify">        
        <b>���������� ������</b>
                <br/>
                <br/>        
            ��� ��������� ���������� ������ ��� ���������� ��������� "�������". ��� �����, ��� ��������� ������� �������, ��� �������� ������, ����������
            ������� ���������� ������ � ������ �� ����������� �������� � �������� "������", ����� � ����� ������.
            ��������� ���� ������ ����� ������������ � ������� "�������", ������ � ������ ������� ��������.
                <br/>
                <br/>
                ����� ������� ����� ���������, � �� �������� �������� �����, ������� �� ������ "�������� �����" � ������� "�������",
                ��� ���� ����������� ������ �������� ������� � ����� �������, ��� �� ������ ������� ��� �������� ���������� �������.
                ��� ����������� ���������� ������ ������� ������ "�������� �����". 
                <br/>
                <br/>
                ��� ���������� ������ ��� ����� ����� �������������� � ����� ��������. 
                ��� ����� ��������� ������������ ��������������� ����� ���, ���� �� ��� ���������������� � ���, ������� ����� ����������� ����� � ������, ��������� ��� �����������.
                <b>��������� ����� ����������� ����� � ������, ��������� ��� �����������, ��� ����������� � �������� � ����������.</b> 
                ����� ���������� ��������������� �����, ������� �� ������ "���������� ����������". 
                <br/>
                <br/>                
                ����� ��������������� ��� ����� ���������� ������� ���������� 
                ������ � ����� ��������, ������� ������ ������, ������� ��������� ����������� (��� ������ ����������� ����� ������) � ����������� �����.
                ����� ������������� ������, ��, ��������� ���� ��� �����������, ����� ����������� ����� ����� ���������� ������, � ��������� ������. 
                ����� ��������� �����, � ���� �������� ��� �������� ��� ������������ ���� � ��������� ��������. ����� �� ���������� � ������������ ������ ������. 
                ����� ������������ ������, � ���� �������� ��� ��������, � ������� ����� �������� ������� ��� ���. ����� ����� ������������ �� ���������� ������. 
                <br/>
                <br/>
                �� ����� ������ ������� ����� ����� <a href="mailto:zakaz@MIRTOS.RU"><u>����� �������� �������</u></a>. ������� ���� ����������� � ������ � ���� ����������. ���� ��������� �������� � ����.
                <br/>
                <br/>
                ������ ������� ������� � ����� ��������!
                <br/>
                <br/>                
</p>                
                <p align="justify">
                    <b>������.</b>
                    <br />
                    <br />
                    ��� �������� ����������� �������, ������� ���, ������ ��������� �������.
                    <br/>
                    <br/>
                    ��� ������������ ��������, ������� ���, 100% ���������� ���������� ��������� ��
                    ������������ ���������.
                    <br/>
                    <br/>
                    ��� ����������� ��� 100% ���������� ���������� ��������� �� ������������� �����.
                    <br/>
                    <br/>
                    ����� ��������� ���������� � �������� ������ �� ������ ���������� <a href="http://www.MIRTOS.RU/Payments.aspx">
                        <u>�����</u></a>.
                    <br />
                    </p>
                    <p align="justify">
                        <b>��������.</b>
                        <br />
                        <br />
                        ����� ��������� ���������� � �������� �������� � ������� �� ������ ���������� <a
                            href="http://www.MIRTOS.RU/Shipping.aspx"><u>�����</u></a>.
                        <br />
                        <br />
                        <li>������� ������ �� ������ ������������ �� �������� <a href="http://www.MIRTOS.RU/PasswordRecovery.aspx">
                            <u>�������������� ������</u></a>. ���������� ������ � ���� e-mail ��� ����� �����������
                            ����� ������� �� ������������ ��� ����������� ��� ��� ������ ������ � ��� �����
                            ������� ��������� � �������.</li>
                            <li>� ������ ����������� ��� ������ � ������ �� ������ ���������� � <a href="mailto:info@MIRTOS.RU">
                                <u>�������������� �����</u></a>
                                </li>
                                </p>
                                <br/>
                                <br/>
                                <br/>
    </div>
</asp:Content>
