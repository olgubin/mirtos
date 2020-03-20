<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentLongDescriptionControl.ascx.cs"
    Inherits="UC.UI.Admin.Controls.DepartmentLongDescriptionControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:UpdatePanel ID="updpnlDepartmentLongDescription" runat="server">
    <ContentTemplate>
        <asp:HiddenField ID="hfDepartmentID" runat="server" />
        <FCKeditorV2:FCKeditor ID="txtLongDescription" runat="server" Height="600px" Width="100%" Value=""/>
        <p>
            <asp:Button runat="server" ID="btnUpdateDepartmentLongDescription" CssClass="adminButton"
                Text="Обновить описание" OnClick="btnUpdateDepartmentLongDescription_Click" />
            <asp:Label ID="lblbtnUpdateDepartmentLongDescription" runat="server" EnableViewState="false"
                ForeColor="Red" Font-Size="Small"></asp:Label>
        </p>
    </ContentTemplate>
</asp:UpdatePanel>
