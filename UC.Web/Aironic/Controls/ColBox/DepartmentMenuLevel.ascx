<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentMenuLevel.ascx.cs" Inherits="UC.UI.Controls.DepartmentMenuLevel"
    EnableViewState="false" %>
    
<div class="box">
    <div class="boxtitle">Каталог</div>
    <div class="boxcontent news">
    <div class="transparent"></div>    
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server" Width="100%"
        RepeatColumns="1" RepeatDirection="Vertical" OnItemCreated="dlstDepartments_ItemCreated">
        <ItemTemplate>
            <table cellpadding="0" style="width: 100%;padding-bottom:7px">
                <tr>
                    <td>
                        <div class="departmenttitle">
                                <asp:HyperLink runat="server" ID="lnkDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# "~/"+MainReferencePage+"?DepID=" + Eval("DepartmentID") %>' />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <div class="departmentdescription">
                            <asp:Repeater ID="rptrSubDepartments" runat="server">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlCategory" runat="server" NavigateUrl='<%# "~/"+ReferencePage+"?DepID=" + Eval("DepartmentID") %>'
                                        Text='<%# Eval("Name") %>'></asp:HyperLink><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <ItemStyle Width="100%" />
    </asp:DataList>
    </div>
</div>