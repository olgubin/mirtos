<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManufacturerLongDescriptionControl.ascx.cs"
    Inherits="UC.UI.Admin.Controls.ManufacturerLongDescriptionControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:UpdatePanel ID="updpnlManufacturerLongDescription" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfManufacturerID" runat="server" />
        <FCKeditorV2:FCKeditor ID="txtLongDescription" runat="server" Height="600px" Width="100%" Value=""/>
        <p>
            <asp:Button runat="server" ID="btnUpdateManufacturerLongDescription" CssClass="adminButton"
                Text="Обновить описание" OnClick="btnUpdateManufacturerLongDescription_Click" />
            <asp:Label ID="lblbtnUpdateManufacturerLongDescription" runat="server" EnableViewState="false"
                ForeColor="Red" Font-Size="Small"></asp:Label>
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
