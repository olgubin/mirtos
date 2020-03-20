<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCartLightControl.ascx.cs" Inherits="UC.UI.Controls.ShoppingCartLightControl" %>
<%@ Import Namespace="UC.UI" %>
<div class="wizard">
    <asp:GridView ID="gvwOrderItems" runat="server" AutoGenerateColumns="False" DataSourceID="objShoppingCart"
        Width="100%" DataKeyNames="ID" OnRowDeleted="gvwOrderItems_RowDeleted" OnRowCreated="gvwOrderItems_RowCreated"
        BorderWidth="0">
        <Columns>
            <asp:BoundField HeaderText="Артикул" DataField="SKU" ItemStyle-HorizontalAlign="Center"
                ItemStyle-Width="57px" />
<%--            <asp:HyperLinkField DataTextField="Title" DataNavigateUrlFormatString="~/ShowProduct.aspx?ID={0}"
                DataNavigateUrlFields="ID" HeaderText="Наименование" ItemStyle-HorizontalAlign="Left">
            </asp:HyperLinkField>--%>
        <asp:TemplateField HeaderText="Наименование" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="lnkTitle" Text='<%# Eval("Title") %>' NavigateUrl='<%# "~/ShowProduct.aspx?ID=" + Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>            
            <asp:TemplateField HeaderText="Количество">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtQuantity" Text='<%# Bind("Quantity") %>' MaxLength="6"
                        Width="37px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valRequireQuantity" runat="server" ControlToValidate="txtQuantity"
                        SetFocusOnError="True" ValidationGroup="ShippingAddress" Text="Укажите количество товара."
                        ToolTip="The Quantity field is required." Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="valQuantityType" runat="server" Operator="DataTypeCheck"
                        Type="Integer" ControlToValidate="txtQuantity" Text="Количество должно быть целым числом."
                        ToolTip="Количество должно быть целым числом." Display="Dynamic" />
                </ItemTemplate>
                <ItemStyle Width="60px" HorizontalAlign="Center" />
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Количество" DataField="Quantity" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Цена">
                <ItemTemplate>
                    <div style="text-align: right">
                        <%# (this.Page as BasePage).FormatPrice(Eval("UnitPrice")) %>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Сумма">
                <ItemTemplate>
                    <div style="text-align: right">
                        <%# (this.Page as BasePage).FormatPrice(Double.Parse(Eval("UnitPrice").ToString()) * Int32.Parse(Eval("Quantity").ToString()))%>
                    </div>
                </ItemTemplate>
                <ItemStyle Width="110px" />
            </asp:TemplateField>
            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/cart_del.gif" DeleteText="Delete product"
                ShowDeleteButton="True" meta:resourcekey="CommandFieldResource1">
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:objectdatasource id="objShoppingCart" runat="server" selectmethod="GetItems"
        typename="UC.BLL.Store.CurrentUserShoppingCart" deletemethod="DeleteProduct">
    </asp:objectdatasource>
    <asp:Panel runat="server" ID="panDiscountCard" Visible="false">
        <asp:Table runat="server" Width="100%" Height="60px">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    Товаров на сумму:
                </asp:TableCell>
                <asp:TableCell Width="116px" HorizontalAlign="Right">
                    <asp:Literal runat="server" ID="lblTotal" />
                </asp:TableCell>
                <asp:TableCell Width="58px" runat="server">
                </asp:TableCell>
            </asp:TableRow>        
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                    <asp:Literal runat="server" ID="litDiscountCard" />
                </asp:TableCell>
                <asp:TableCell Width="116px" HorizontalAlign="Right">
                    <asp:Literal runat="server" ID="litDiscount" />
                </asp:TableCell>
                <asp:TableCell Width="58px" runat="server">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel runat="server" ID="panTotals">
        <asp:Table runat="server" Width="100%" Height="30px">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Right">
                        <b>Стоимость заказа:</b>
                </asp:TableCell>
                <asp:TableCell Width="116px" HorizontalAlign="Right">
                    <b>
                        <asp:Literal runat="server" ID="lblSubtotal" /></b>
                </asp:TableCell>
                <asp:TableCell Width="58px" runat="server" ID="tdFalse">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <div style="width: 100%; text-align: right; padding: 7px 0px 7px 0px;">
            <asp:Label runat="server" ID="lblMsg" EnableViewState="false">Если Вы изменили количество товара, пожалуйста нажмите <b>пересчитать</b> *</asp:Label>
        </div>
        <div style="text-align: right">
            <div style="float: left;">
<%--                <asp:ImageButton ID="btnReserve" runat="server" OnClick="btnProceedOrder_Click" SkinID="Reserve"
                    EnableViewState="false" />
                <asp:ImageButton ID="btnProceedOrder" runat="server" OnClick="btnProceedOrder_Click"
                    SkinID="ProceedOrder" EnableViewState="false" />
                <asp:ImageButton ID="btnConfirmOrder" runat="server" OnClick="btnProceedOrder_Click"
                    SkinID="ConfirmOrder" EnableViewState="false" />
                &nbsp&nbsp--%>
               <asp:ImageButton ID="btnContinueShopping" runat="server" OnClick="btnContinueShopping_Click"
                    SkinID="ContinueShopping" EnableViewState="false" />
            </div>
            <asp:ImageButton ID="btnUpdateTotals" runat="server" OnClick="btnUpdateTotals_Click"
                SkinID="UpdateTotals" EnableViewState="false" />
        </div>
    </asp:Panel>
</div>
