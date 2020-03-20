<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageFilterCriteriaProduct.aspx.cs" Inherits="UC.UI.Admin.ManageFilterCriteriaProduct" Culture="auto"
    UICulture="auto" %>
<%@ Register Src="~/Admin/Controls/SelectDepartmentControl.ascx" TagName="SelectDepartmentControl" TagPrefix="mb" %>                        
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Главная</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        Определение критериев фильтрации для товаров</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel ID="updpnlManageDepartment" runat="server">
            <ContentTemplate>
                <p>
                Раздел товаров: <mb:SelectDepartmentControl ID="ddlDepartments" runat="server" OnSelectedIndexChange="ddlDepartments_SelectedIndexChanged" AutoPostBack="true"/>
                </p>
                <table width="100%">
                    <tr>
                        <td valign="top" width="40%">
                <asp:GridView ID="gvwFilters" runat="server" AutoGenerateColumns="False" 
                    Width="100%" DataKeyNames="FilterID" OnSelectedIndexChanged="gvwFilters_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать фильтр"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>                    
                        <asp:BoundField DataField="Name" HeaderText="Название фильтра">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        Нет фильтров для отображения</EmptyDataTemplate>
                </asp:GridView>
                        <p/>
                                <asp:GridView ID="gvwFilterCriteria" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="FilterCriteriaID" Width="100%" OnSelectedIndexChanged="gvwFilterCriteria_SelectedIndexChanged">
                                    <Columns><%--DataSourceID="objFilterCriteria"--%>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="Редактировать критерий"
                                            ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="Criterion" HeaderText="Критерий фильтрации">
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Нет критериев фильтрации для отображения</EmptyDataTemplate>
                                </asp:GridView>
                                <p>
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить"
                                        OnClick="btnUpdate_Click" ValidationGroup="gvwFilterCriteria"/><asp:Label ID="lblFeedBack" runat="server" EnableViewState="false"
                                            ForeColor="Red" Font-Size="Small"></asp:Label>
                                </p>
<%--                                <asp:ObjectDataSource ID="objFilterCriteria" runat="server" DeleteMethod="DeleteOption"
                                    SelectMethod="GetFilterCriteriaByFilterID" TypeName="UC.BLL.Store.FilterCriteriaManager">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="gvwFilters" Name="FilterID" PropertyName="SelectedValue"
                                            Type="Int32" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                        </td>
                        <td valign="top" width="60%">
                                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="FilterCriteriaProductID" 
                                Width="100%" OnDataBound="gvProducts_DataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Товар" ItemStyle-Width="20px">
                                            <HeaderTemplate>
                                                    <asp:CheckBox ID="cbSelectAll" runat="server" OnCheckedChanged="cbSelectAll_Click" AutoPostBack="true"/>
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbProductInfo" runat="server" Checked='<%# Eval("IsMapped") %>' />
                                                <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                                <asp:HiddenField ID="hfFilterCriteriaProductID" runat="server" Value='<%# Eval("FilterCriteriaProductID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="70%">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblAllProduct" runat="server"/>
                                            </HeaderTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblAllProduct" runat="server" Text = '<%# Server.HtmlEncode(Eval("ProductInfo").ToString()) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>     
                                        <asp:TemplateField ItemStyle-Width="30%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCriterion" runat="server" Text = '<%# Eval("Criterion") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                                                            
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Не заданы условия для отображения товаров</EmptyDataTemplate>
                                </asp:GridView>                        
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
