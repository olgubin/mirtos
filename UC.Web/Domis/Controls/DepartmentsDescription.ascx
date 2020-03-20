<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsDescription.ascx.cs" Inherits="UC.UI.Controls.DepartmentsDescription"
    EnableViewState="false" %>
<div id="content">
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server"
        Width="100%" RepeatColumns="2" RepeatDirection="Horizontal">
        <ItemTemplate>
            <table cellpadding="0" style="width: 100%;">
                <tr>
                    <td style="width: 100px;">
                        <div class="departmentimage">
                            <asp:HyperLink runat="server" ID="lnkDepImage" NavigateUrl='<%# "~/Departments.aspx?DepID=" + Eval("DepartmentID") %>'
                                ToolTip='<%# Eval("Name") %>'>
                                <asp:Image runat="server" ID="imgDepartment" BorderWidth="0px" GenerateEmptyAlternateText="true"
                                    ImageUrl='<%# Eval("ImageUrl") %>' /></asp:HyperLink></div>
                    </td>
                    <td>
                        <div class="departmenttitle">
                            <asp:HyperLink runat="server" ID="lnkDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# "~/Departments.aspx?DepID=" + Eval("DepartmentID") %>' /></div>
                        <div class="departmentdescription">
                            <asp:HyperLink runat="server" ID="HyperLink1" Text='<%# Eval("Description") %>' NavigateUrl='<%# "~/Departments.aspx?DepID=" + Eval("DepartmentID") %>' /></div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
