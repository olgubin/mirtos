<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsInLine.ascx.cs"
    Inherits="UC.UI.Controls.ProductsInLine" %>
<%@ Register Src="~/Controls/FilterBoxControl.ascx" TagName="FilterBoxControl" TagPrefix="mb" %>
<%@ Register Src="~/Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="~/Controls/AvailabilityDisplay.ascx" TagName="AvailabilityDisplay"
    TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>
<div id="content">
    <mb:FilterBoxControl runat="server" ID="ucFilter" OnFiltered="ucFilter_Filtered" />
    <h2><asp:Literal runat="server" ID="lblTitle"/></h2>
    <asp:DataList ID="dlstDepartments" EnableTheming="False" runat="server" Width="100%"
        OnItemCreated="dlstDepartments_ItemCreated">
        <ItemTemplate>
            <div class="description">
                <h3>
                    <%# Eval("Name") %></h3>
                <%# Eval("LongDescription") %>
            </div>
            <div class="grid" style="padding-bottom: 15px; clear:left">
                <asp:GridView runat="server" ID="gvwProducts" AutoGenerateColumns="false" Width="100%" BorderWidth="0"
                 OnRowCommand="gvwProducts_RowCommand" RowStyle-HorizontalAlign="Center" RowStyle-CssClass="rowaltcolor" AlternatingRowStyle-CssClass="rowcolor" OnRowDeleting="gvwProducts_RowDeleting"
                 OnRowCreated="gvwProducts_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Арт.">
                            <ItemTemplate>
                                <%# Eval("SKU") %>
                            </ItemTemplate>
                            <ItemStyle Width="43px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Модель">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                <b><%# Eval("Title") %></b><br />
                                <mb:RatingDisplay runat="server" ID="RatingDisplay1" Value='<%# Eval("AverageRating") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="110px"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 1" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr1") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 2" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr2")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 3" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr3")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 4" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr4") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 5" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr5")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 6" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr6")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 7" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr7")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 8" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr8")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Характеристика 9" Visible="false">
                            <ItemTemplate>
                                <%# Eval("Attr9")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Цена">
                            <ItemTemplate>
                                <asp:Panel runat="server" Visible='<%# (decimal)Eval("UnitPrice") > 0 & (int)Eval("UnitsInStock") > 0 %>'>
                                    <%# (this.Page as BasePage).FormatPrice(Eval("FinalPrice")) %>
                                    <asp:Panel ID="Panel1" runat="server" Visible='<%# (int)Eval("DiscountPercentage") > 0  %>' Font-Size="7" Font-Bold="false">
                                        <s>
                                            <%# (this.Page as BasePage).FormatPrice(Eval("UnitPrice")) %></s>
                                    </asp:Panel>
                                </asp:Panel>
                                <asp:Panel runat="server" Visible='<%# (decimal)Eval("UnitPrice") <= 0 || (int)Eval("UnitsInStock") <= 0 %>'>
                                    Под заказ
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" ForeColor="Red" Font-Bold="true" Width="90px"/>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Кол.">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txtQuantity" Text="1" MaxLength="6" Width="30px"
                                    Font-Size="11px"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Panel runat="server" ID="pnlAddToCart" Visible='<%# (decimal)Eval("UnitPrice") > 0 & (int)Eval("UnitsInStock") > 0 %>'>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" CommandName="Select"
                                        CommandArgument='<%# Eval("ProductID") %>' AlternateText="В корзину" ImageUrl="~/App_Themes/CClimate/images/sbuy.gif" />
                                </asp:Panel>
                                <asp:Panel runat="server" ID="pnlToOrder" Visible='<%# (decimal)Eval("UnitPrice") <= 0 || (int)Eval("UnitsInStock") <= 0 %>'>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" CommandName="Select"
                                        CommandArgument='<%# Eval("ProductID") %>' AlternateText="Заказать" ImageUrl="~/App_Themes/CClimate/images/sbuy.gif" />
                                </asp:Panel>
                                <asp:Panel runat="server" ID="panEditProduct">
                                    <asp:ImageButton runat="server" ID="btnProductCopy" CausesValidation="false" AlternateText="Копировать товар"
                                        ImageUrl="~/Images/copy.gif" CommandName="Copy" CommandArgument='<%# Eval("ProductID") %>' />&nbsp;
                                    <asp:HyperLink runat="server" ID="lnkEditProduct" ImageUrl="~/Images/Edit.gif" ToolTip="Редактировать товар"
                                        NavigateUrl='<%# "~/Admin/AddEditProduct.aspx?ID=" + Eval("ProductID") %>' />&nbsp;
                                    <asp:ImageButton runat="server" ID="btnDelete" CausesValidation="false" AlternateText="Удалить товар"
                                        ImageUrl="~/Images/Delete.gif" OnClientClick="if (confirm('Подтвердите удаление товара?') == false) return false;"
                                        CommandName="Delete" CommandArgument='<%# Eval("ProductID") %>' />
                                </asp:Panel>
                            </ItemTemplate>
                            <ItemStyle Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
