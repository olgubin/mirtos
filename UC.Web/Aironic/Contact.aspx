<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="UC.UI.Contact" %>

<%@ Register Src="Controls/ContactForm.ascx" TagName="ContactForm" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
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
                        ���������� ����������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <div style="padding-top: 10px;">
            <table>
                <tr>
                    <td>
                        <p>
                            <h3>
                                ���� ��������</h3>
                        </p>
                        <p>
                            <b>�����:</b> 115516 �. ������, ��. ������������, ��� 11, ���. 8<br />
                            <b>���:</b> (495) 730-78-18<br />
                            <b>����:</b> (495) 234-05-34<br />
                            <b>E-mail:</b> <a href="mailto:info@aironic.ru">info@aironic.ru</a><br />
                        </p>
                        <p>
                            <h3>
                                ����� �������� �����</h3>
                        </p>
                        <mb:ContactForm ID="ContactForm1" runat="server" Title="������ ������ ������? �������� ���� �����? �������� ������������? ��������� ��� �����. �� ����������� �������� � ����." />
                    </td>
                    <td style="width: 200px; text-align: center">
                        <div style="padding: 17px">
                            <div style="padding: 7px">
                                <a href="#ref0">
                                    <img src="App_Themes/CClimate/images/by_foot.png" /></a>
                            </div>
                            <a href="#ref0">��� ��������� ������</a>
                            <div style="padding: 7px">
                                <a href="#ref1">
                                    <img src="App_Themes/CClimate/images/by_bus.png" /></a>
                            </div>
                            <a href="#ref1">��� ��������� �� ������������ ����������</a>
                            <div style="padding: 7px">
                                <a href="#ref2">
                                    <img src="App_Themes/CClimate/images/by_car.png" /></a>
                            </div>
                            <a href="#ref2">��� ��������� �� ������</a>
                        </div>
                    </td>
                </tr>
            </table>
            <p>
                <h3>
                    ����� �������:</h3>
            </p>
            <p>
                <a name="ref0"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_foot_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                ���� �� ����� ������, ��:</h1>
                        </td>
                    </tr>
                </table>
                �� ������� ����� �������������� � ������ ����� �� ������, ����� �� ���������� ��������
                �����, ����� ������� ������� � �� �������� ����� �� �����. � ����� ������� �����
                ���� ����� ������� �������� � ������ � ������� ����������. ����� ���� �� ����������������
                ������� ����� ����� �� ����� ���������, �� ����������� �� ����������. �����������
                �� ����������� � ��������� ����� ����� ������������. ����� ����� �� ����� ������������
                �� ������ �������� ����� �����, ����� ����� ���������� ���������. � �������� ���������,
                �� ���������� ��������� ����� �� �������� �������. ��� ����� �� ���������� ������
                ������ �������, ��� �� � �������� ����-������.
                <p>
                    <b>����� � ���� � 15 �����.</b></p>
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_foot_map.gif" />
                </div>
            </p>
            <p>
                <a name="ref1"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_bus_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                ���� �� ����� ������������ �����������, ��:</h1>
                        </td>
                    </tr>
                </table>
                �� ������� ����� �������������� � ������ ����� �� ������, ����� �� ���������� ��������
                �����, ����� ������� ������� � �� �������� ����� �� �����. ����� ����� � �������
                ���������� ��������� - ������� � 150, ��������� � 150. ����� �� ��������� ������
                �������������, ��� 8-� ��������� �� �����. ����� ����� �������� ������. � ��������
                ���������, �� ���������� ��������� ����� �� �������� �������. ��� ����� �� ����������
                ������ ������ �������, ��� �� � �������� ����-������.
                <p>
                    <b>����� � ���� � 10-15 �����.</b></p>
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_bus_map.gif" />
                </div>
            </p>
            <p>
                <a name="ref2"></a>
                <table>
                    <tr>
                        <td>
                            <div style="padding: 0px 7px 3px 0px">
                                <img src="App_Themes/CClimate/images/by_car_33.png" />
                            </div>
                        </td>
                        <td style="vertical-align: middle">
                            <h1>
                                ���� �� ����� �� ������, ��:</h1>
                        </td>
                    </tr>
                </table>
                � ���������� ����� ������������� �� ������������ �������� (������� �� ���������
                ��� ��� �������� �� ������, ��� � � ������� ������), ����� �� ����� ��������������
                �� ��������� ������� �������, ����� ����� �� ������� ��������� �� ��������, �������������
                ������ (��.���������). ����� �� ���������� ��������� � ������������� ������� ��
                ����� ������������. ����� ���������� �����, �� ������ �������� ����� �����, �����
                ����� ���������� ���������. � �������� ���������, �� ���������� ��������� �����
                �� �������� �������. ��� ����� �� ���������� ������ ������ �������, ��� �� � ��������
                ����-������.
                <p />
                <div style="text-align: center">
                    <img src="App_Themes/CClimate/images/by_car_map.gif" />
                </div>
            </p>
        </div>
</asp:Content>
