<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsInGrid2.ascx.cs" Inherits="UC.UI.Controls.DepartmentsInGrid2" %>
<%@ Import Namespace="UC.SEOHelper"%>
<div id="content">
<h2>
<asp:Literal runat="server" ID="litTitle"/>
</h2>
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server" Width="100%"
        RepeatColumns="2" RepeatDirection="Horizontal" OnItemCreated="dlstDepartments_ItemCreated">
        <ItemTemplate>
            <table cellpadding="0" style="width: 100%;padding-bottom:7px">
                <tr>
                    <td colspan="2">
                        <div class="departmenttitle">
                                <asp:HyperLink runat="server" ID="lnkDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("NavigateUrl") %>' />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <div class="departmentimage">
                            <asp:HyperLink runat="server" ID="lnkDepImage" NavigateUrl='<%# Eval("NavigateUrl") %>'
                                ToolTip='<%# Eval("Name") %>'>
                            <asp:Image runat="server" ID="imgDepartment" BorderWidth="0px" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>' Height="100px" Width="100px"/>
                            </asp:HyperLink></div>
                    </td>
                    <td style="width: 100%">
                        <div class="departmentdescription">
                            <asp:Repeater ID="rptrSubDepartments" runat="server">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlCategory" runat="server" NavigateUrl='<%# SeoHelper.GetAbsoluteUrl(this.ResolveUrl("~/Departments.aspx?DepID=" + Eval("DepartmentID"))) %>'
                                        Text='<%# Eval("Name") %>'></asp:HyperLink><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <ItemStyle Width="33%" />
    </asp:DataList>
    <asp:Literal runat="server" ID="_litLongDescription" Visible="false"/>
</div>