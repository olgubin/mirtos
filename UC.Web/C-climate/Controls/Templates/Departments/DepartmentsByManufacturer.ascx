<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentsByManufacturer.ascx.cs"
    Inherits="UC.UI.Controls.DepartmentsByManufacturer" %>
<div id="content">
    <div class="description">
        <h2>
            <asp:Literal runat="server" ID="litTitle"></asp:Literal></h2>
        <p>
            <asp:Image runat="server" ID="imgManufacturer" BorderWidth="0px" GenerateEmptyAlternateText="true"
                Width="200px" Height="110px" />
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
        </p>
<%--        <div style="width: 100%">
        </div>
        <h3>
            ¬ нашем магазине представлены следующие товары
            <asp:Literal runat="server" ID="litBrands"></asp:Literal>
        </h3>--%>
    </div>
        <div style="width: 100%;clear:both">
        </div>    
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server" Width="100%"
        RepeatColumns="1" RepeatDirection="Horizontal" OnItemCreated="dlstDepartments_ItemCreated">
        <ItemTemplate>
            <table cellpadding="0" style="width: 100%; padding-bottom: 7px">
                <tr>
                    <td>
                        <div class="departmenttitle">
                            <asp:HyperLink runat="server" ID="lnkDepTitle" Text='<%# Eval("Name") %>' NavigateUrl='<%# Eval("NavigateUrl") %>' />
                            <%--<asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Name") %>' />--%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--                    <td style="width: 100px">
                        <div class="departmentimage">
                            <asp:HyperLink runat="server" ID="lnkDepImage" NavigateUrl='<%# Eval("NavigateUrl") %>'
                                ToolTip='<%# Eval("Name") %>'>
                            <asp:Image runat="server" ID="imgDepartment" BorderWidth="0px" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>' Height="83px" Width="100px"/>
                            </asp:HyperLink></div>
                    </td>
                    <td style="width: 100%">--%>
                        <div class="departmentdescription">
<%--                            <asp:Repeater ID="rptrSubDepartments" runat="server">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlCategory" runat="server" NavigateUrl='<%# Eval("NavigateUrl") %>'
                                        Text='<%# Eval("Name") %>'></asp:HyperLink><br />
                                </ItemTemplate>
                            </asp:Repeater>--%>
                            
                            <asp:DataList ID="rptrSubDepartments" runat="server" Width="100%" EnableTheming="False" RepeatColumns="3" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlCategory" runat="server" NavigateUrl='<%# Eval("NavigateUrl") %>'
                                        Text='<%# Eval("Name") %>'></asp:HyperLink>
                                        <div style="padding:5px 0px 7px 0px">
                                    <asp:HyperLink runat="server" ID="lnkDepImage" NavigateUrl='<%# Eval("NavigateUrl") %>' ToolTip='<%# Eval("Name") %>'>
                                    <asp:Image runat="server" ID="imgDepartment" BorderWidth="0px" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>' Height="83px" Width="100px"/>    
                                    </asp:HyperLink></div>
                                </ItemTemplate>
                                <ItemStyle Width="33%" />
                            </asp:DataList>
                            
                        </div>
                        <%--                    </td>--%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
        <ItemStyle Width="33%" />
    </asp:DataList>
    <div class="description">
        <asp:Label runat="server" ID="lblLongDescription"></asp:Label>
    </div>
</div>
