<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="ShoppingCart.aspx.cs" Inherits="UC.UI.ShoppingCart" Culture="auto"
    UICulture="auto" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>    
<%@ Register Src="./Controls/ShoppingCartControl.ascx" TagName="Cart" TagPrefix="mb" %>
<%@ Register Src="~/Controls/Login.ascx" TagName="Log" TagPrefix="mb" %>
<%@ Register Src="Controls/Register.ascx" TagName="Register" TagPrefix="mb" %>
<%@ Register Src="Controls/ShippingAddress.ascx" TagName="ShippingAddress" TagPrefix="mb" %>
<%@ Register Src="Controls/PaymentMethod.ascx" TagName="PaymentMethod" TagPrefix="mb" %>
<%@ Register Src="Controls/PaymentOptions.ascx" TagName="PaymentOptions" TagPrefix="mb" %>
<%@ Register Src="Controls/ConfirmOrder.ascx" TagName="ConfirmOrder" TagPrefix="mb" %>
<%@ Register Src="Controls/AdoptOrder.ascx" TagName="AdoptOrder" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <mb:BreadCrumb ID="BreadCrumb" runat="server"/>
    <div id="content">
        <asp:MultiView ID="mvwSubmitOrder" runat="server">
            <asp:View ID="vwEmptyCart" runat="server">
                <p style="color: #d7c5ab">
                    <b>��������� ����������!</b></p>
                <p>
                    � ��������� ����� ���� ������� �����.</p>
                <p>
                    �� ������ ������� �����, ���������������� ����� <a href="Default.aspx" style="color: #d7c5ab;
                        text-decoration: none;"><b>���������</b></a>.</p>
                <p>
                    ��� ���������� ������� ���������� ������� ����� � <a href="Default.aspx" style="color: #d7c5ab;
                        text-decoration: none;"><b>���������</b></a>, ������� ���������� � ������ ��
                    ������ "������".</p>
            </asp:View>
            <asp:View ID="vwRegister" runat="server">
                <p style="font-weight: bold; color: #d7c5ab">
                    ��� ������������������ �����������</p>
                <table style="width: 100%">
                    <tr>
                        <td style="background-color: #c5b6a8; border: solid 1px white; padding: 7px;">
                            ���� �� ��� ���������������� �� ����� �����, ������� ����� ����������� ����� � ������,
                            ��������� ��� �����������.<br />
                            ���� �� ������ ������, ��������������
                            <asp:HyperLink ID="lnkPasswordRecovery" runat="server" NavigateUrl="~/PasswordRecovery.aspx">������� ����������� �������</asp:HyperLink>.
                        </td>
                        <td style="width: 200px; background-color: #c5b6a8; padding: 7px; border: solid 1px white;">
                            <mb:Log runat="server" ID="Log" ReturnUrl="~/ShoppingCart.aspx" />
                        </td>
                    </tr>
                </table>
                <p style="font-weight: bold; color: #d7c5ab">
                    ��� ����� �����������</p>
                <p>
                    ��������� ���������� ��������������� �����. ��������� e-mail � ������ �����������,
                    � ����������, ��� ����������� � ����� ��������. ����, ���������� <span style="color: Red">
                        *</span>, ����������� ��� ����������.</p>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">
                    <mb:Register runat="server" ID="Reg" BodyFileName="~/RegistrationMail.txt" From="info@�-�LIMATE.RU"
                        FromCaption="�-�LIMATE.RU ������������� ������������" Subject="��������������� ������"
                        ReturnUrl="~/ShoppingCart.aspx" />
                    <br />
                    <asp:ImageButton ID="btnRegister" ValidationGroup="Register" runat="server" OnClick="ProceedOrder" SkinID="ProceedOrder"/></asp:Panel>
            </asp:View>
            <asp:View ID="vwAddress" runat="server">
                <p class="linkmenu">
                    <span>����� ��������</span></p>
                <asp:Panel ID="Panel2" runat="server" DefaultButton="btnAddress">
                    <mb:ShippingAddress runat="server" ID="Address" />
                    <br />
                    <asp:ImageButton ID="btnAddress" ValidationGroup="Address" runat="server" OnClick="ProceedOrder" SkinID="ProceedOrder"/></asp:Panel>
            </asp:View>
            <asp:View ID="vwPayment" runat="server">
                <p class="linkmenu">
                    <asp:LinkButton runat="server" ID="lnkAP" CommandName="StepOrder" CommandArgument="2"
                        OnCommand="onCommand">����� ��������</asp:LinkButton>
                    <span>������ ������</span></p>
                <asp:Panel ID="Panel3" runat="server" DefaultButton="btnPayment">
                    <mb:PaymentMethod runat="server" ID="Payment" />
                    <br />
                    <asp:ImageButton ID="btnPayment" ValidationGroup="Address" runat="server" OnClick="ProceedOrder" SkinID="ProceedOrder"/></asp:Panel>
            </asp:View>
            <asp:View ID="vwPayer" runat="server">
                <p class="linkmenu">
                    <asp:LinkButton runat="server" ID="lnkAPr" CommandName="StepOrder" CommandArgument="2"
                        OnCommand="onCommand">����� ��������</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkPPr" CommandName="StepOrder" CommandArgument="3"
                        OnCommand="onCommand">������ ������</asp:LinkButton>
                    <span>��������� �����������</span></p>
                <asp:Panel ID="Panel4" runat="server" DefaultButton="btnPayer">
                    <mb:PaymentOptions runat="server" ID="Payer" />
                    <br />
                    <asp:ImageButton ID="btnPayer" ValidationGroup="Payer" runat="server" OnClick="ProceedOrder" SkinID="ProceedOrder"/></asp:Panel>
            </asp:View>
            <asp:View ID="vwConfirm" runat="server">
                <p class="linkmenu">
                    <asp:LinkButton runat="server" ID="lnkAC" CommandName="StepOrder" CommandArgument="2"
                        OnCommand="onCommand">����� ��������</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkPC" CommandName="StepOrder" CommandArgument="3"
                        OnCommand="onCommand">������ ������</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lnkPrC" CommandName="StepOrder" CommandArgument="4"
                        OnCommand="onCommand">��������� �����������</asp:LinkButton>
                    <span>������������� ������</span></p>
                <mb:ConfirmOrder runat="server" ID="Confirm" />
            </asp:View>
            <asp:View ID="vwAdopt" runat="server">
                <mb:AdoptOrder runat="server" ID="Adopt" />
            </asp:View>
        </asp:MultiView><mb:Cart runat="server" ID="Cart" OnProceedOrder="ProceedOrder" />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
