<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsInGridWithDescription.ascx.cs" Inherits="UC.UI.Controls.DepartmentsInGridWithDescription" %>
<div id="content">
<h2>
<asp:Literal runat="server" ID="litTitle"/>
</h2>
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server" Width="100%"
        RepeatColumns="2" RepeatDirection="Horizontal" OnItemCreated="dlstDepartments_ItemCreated">
        <ItemTemplate>
            <table cellpadding="5" style="width: 100%;padding-bottom:7px">
                <tr>
                    <td style="width: 120px">
                        <div>
                            <asp:HyperLink runat="server" ID="lnkDepImage" NavigateUrl='<%# "~/BrowseProducts.aspx?DepID=" + Eval("DepartmentID") %>'
                                ToolTip='<%# Eval("Name") %>'>
                            <asp:Image runat="server" ID="imgDepartment" BorderWidth="0px" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>' Height="120px" Width="120px"/>
                            </asp:HyperLink></div>
                    </td>
                    <td style="width: 100%">
                        <div class="departmenttitle" style="padding-top:0px">
                                <asp:HyperLink runat="server" ID="HyperLink2" Text='<%# Eval("Name") %>' NavigateUrl='<%# "~/BrowseProducts.aspx?DepID=" + Eval("DepartmentID") %>' />
                        </div>                    
                        <div class="departmentdescription" style="text-align:justify">
                        <asp:HyperLink runat="server" ID="HyperLink1" NavigateUrl='<%# "~/BrowseProducts.aspx?DepID=" + Eval("DepartmentID") %>' ToolTip='<%# Eval("Name") %>'><%#Eval("Description")%></asp:HyperLink>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <ItemStyle Width="50%" />
    </asp:DataList>
</div>