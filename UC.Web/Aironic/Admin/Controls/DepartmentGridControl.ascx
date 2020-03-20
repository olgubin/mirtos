<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentGridControl.ascx.cs"
    Inherits="UC.UI.Admin.Controls.DepartmentGridControl" %>
<%--<asp:GridView ID="gvwDepartments" runat="server" AutoGenerateColumns="False" DataSourceID="objAllDepartments"
    Width="100%" DataKeyNames="ID" OnRowDeleted="gvwDepartments_RowDeleted" OnRowCreated="gvwDepartments_RowCreated"
    OnRowCommand="gvwDepartments_RowCommand" OnSelectedIndexChanged="gvwDepartments_SelectedIndexChanged"
    ShowHeader="False" meta:resourcekey="gvwDepartmentsResource1" CssClass="contenttable">
    <Columns>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
                <div class="departmentimage">
                    <asp:Image runat="server" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>'
                        ImageAlign="AbsMiddle" />
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
                <div class="sectionsubtitle">
                    <span>
                        <%# Eval("Title") %>&nbsp&nbsp(Порядок: <%# Eval("Importance")%>)
                    </span>
                </div>
                <br />
                <span>
                    <%# Eval("Description") %>
                </span>
                <br />
                <br />
                <span style="color: #AAAAAA;">
                    <%# Eval("Keywords") %>
                </span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField ButtonType="Image" CommandName="Visible">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:ButtonField>
        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Edit department"
            ShowSelectButton="True" meta:resourcekey="CommandFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:CommandField>
        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Delete department"
            ShowDeleteButton="True" meta:resourcekey="CommandFieldResource2">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:CommandField>
        <asp:HyperLinkField Text="&lt;img border='0' src='../Images/ArrowR.gif' alt='View products' /&gt;"
            DataNavigateUrlFormatString="ManageProducts.aspx?DepID={0}" DataNavigateUrlFields="ID"
            meta:resourcekey="HyperLinkFieldResource1">
            <ItemStyle HorizontalAlign="Center" Width="20px" />
        </asp:HyperLinkField>
    </Columns>
    <EmptyDataTemplate>
        <b>
            <asp:Literal runat="server" Text="<%$ resources:Nodepartmentstoshow %>" />
        </b>
    </EmptyDataTemplate>
</asp:GridView>
<asp:ObjectDataSource ID="objAllDepartments" runat="server" SelectMethod="GetDepartmentsAll"
    TypeName="UC.BLL.Store.Department" DeleteMethod="DeleteDepartment">
</asp:ObjectDataSource>--%>