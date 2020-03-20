<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentMenu.ascx.cs"
    Inherits="UC.UI.Controls.DepartmentMenu" EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper" %>
<div class="box">
    <div style="position: relative;">
        <div class="boxtop_middle">
        </div>
        <div class="boxtop_left">
        </div>
        <div class="boxtop_right">
        </div>
    </div>
    <div class="boxmiddle">
        <div class="boxmiddle">
            <table cellpadding="0">
                <tr>
                    <td class="boxmiddle_left">
                    </td>
                    <td>
                        <div class="boxmiddle_middle">
                            <div class="departmentmenu">
                                <asp:Repeater runat="server" ID="repDepartments" OnItemCreated="repDepartments_ItemCreated">
                                    <HeaderTemplate>
                                        <div class="menu">
                                            <table style="width: 100%;">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <th>
                                                <b>
                                                    <asp:HyperLink runat="server" ID="lnkDepTitleRep" Text='<%# Eval("Name") %>' NavigateUrl='<%# SeoHelper.GetDepartmentUrl((int)Eval("DepartmentID")) %>' /></b>
                                            </th>
                                        </tr>
                                        <asp:Repeater runat="server" ID="repSubDepartments">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="Image3" SkinID="Menu" runat="server" />
                                                        <asp:HyperLink runat="server" ID="lnkSubDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# SeoHelper.GetDepartmentUrl((int)Eval("DepartmentID")) %>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table> </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </td>
                    <td class="boxmiddle_right">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="boxbottom">
        <div class="boxbottom_middle">
        </div>
        <div class="boxbottom_left">
        </div>
        <div class="boxbottom_right">
        </div>
    </div>
</div>
