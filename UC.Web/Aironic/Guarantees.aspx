<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Guarantees.aspx.cs" Inherits="UC.UI.Guarantees"
    MasterPageFile="~/Template.master" %>

<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>--%>
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
                    <h1>
                        ��������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
    <br />
        <div class="wizard">
            <table width="100%">
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        ����������� ����� �� ������������:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>Daikin</li>
                            <li>General Fujitsu</li>
                            <li>Toshiba</li>
                            <li>Sanyo</li>
                            <li>Mitsubishi Electric</li>
                            <li>General Climate</li>
                            <li>Panasonic</li>
                            <li>Hitachi</li>
                            <li>Haier</li>
                            <li>Kentatsu</li>
                            <li>LG</li>
                            <li>Midea</li>
                            <li>Lessar</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        ����������� ����� �� �������������� ������������:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>NED</li>
                            <li>�����-�</li>
                            <li>Lindab</li>
                            <li>Systemair</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>1 ���</li>
                            <li>1 ���</li>
                            <li>1 ���</li>
                            <li>1 ���</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        ����������� ����� �� �������� ������������:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>��������</li>
                            <li>Frico</li>
                            <li>������</li>
                            <li>2VV</li>
                            <li>EuroHeat</li>
                            <li>Olefini/General</li>
                            <li>NED</li>
                            <li>Korf</li>
                            <li>Remak</li>
                            <li>Pyrox</li>
                            <li>Ensto</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                            <li>3 ����</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        ����������� ����� �� ������������ ��� ������ ���������:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>Global</li>
                            <li>Purmo</li>
                            <li>Danfoss</li>
                            <li>Bugatti</li>
                            <li>RBM</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>10 ���</li>
                            <li>10 ���</li>
                            <li>1 ���</li>
                            <li>50 ��� (����/���� 20 000 ������)</li>
                            <li>1 ���</li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            �������� �� ������������ ������������� ��� ������� ��������������� �� ���������
            ������� �������������.
        </p>
        <p>
            �������� �� ������� ���������� - 1 ���.
        </p>
        <p>
            �������� �� ��������� ������ � ������� �����-���������� ����� - 1 ���.
        </p>
        <p>
            ��� ��������� �� �������� ���������� ������ ������������ ����������� ���������,
            ����������� ��������������� �������. (�������, ����������� �����, �������� ��������������
            ������).
        </p>
        <p />
    </div>
</asp:Content>
