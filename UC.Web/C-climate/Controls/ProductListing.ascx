<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductListing.ascx.cs"
    Inherits="UC.UI.Controls.ProductListing" %>
<%@ Register Src="../Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="../Controls/AvailabilityDisplay.ascx" TagName="AvailabilityDisplay"
    TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox"
    TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/DecimalTextBox.ascx" TagName="DecimalTextBox"
    TagPrefix="mb" %>
<%@ Register Src="../Admin/Controls/SelectDepartmentControl.ascx" TagName="SelectDepartmentControl"
    TagPrefix="mb" %>
<%@ Register Src="../Admin/Controls/SelectCurrencyControl.ascx" TagName="SelectCurrencyControl"
    TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>
<asp:UpdateProgress ID="progress" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <div style="width: 100%; background-color: Red; color: White; padding: 3px; margin-bottom: 7px">
            Выполнение запроса...</div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="updpnlManageProducts" runat="server">
    <ContentTemplate>
        <asp:HyperLink runat="server" ID="lnkAddNewProduct" NavigateUrl="~/Admin/AddEditProduct.aspx"
            Target="_blank">Добавить новый товар</asp:HyperLink>
        <br />
        <br />
        <asp:LinkButton runat="server" ID="lnkManufacturerAssign" Text="Назначить выделенным товарам производителя:"
            OnClick="lnkManufacturerAssign_Click" />
        <asp:DropDownList ID="ddlManufacturer" runat="server" AutoPostBack="false" DataSourceID="objManufacturers"
            Width="220px" DataTextField="Title" DataValueField="ManufacturerID">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="objManufacturers" runat="server" SelectMethod="GetManufacturers"
            TypeName="UC.BLL.Store.ManufacturerManager"></asp:ObjectDataSource>
        <br />
        <br />
        <asp:LinkButton runat="server" ID="lnkCurrencyAssign" Text="Назначить выделенным товарам валюту:"
            OnClick="lnkCurrencyAssign_Click" />
        <mb:SelectCurrencyControl ID="ddlCurrency" runat="server"></mb:SelectCurrencyControl>
        <br />
        <br />
        <asp:Literal runat="server" ID="Literal2" Text="Товар:"></asp:Literal>
        <asp:TextBox runat="server" ID="txtTitleFilter" Width="200px" MaxLength="256" />
        <asp:Literal ID="Literal3" runat="server" Text="&nbsp;&nbsp;&nbsp;" />
        <asp:Literal runat="server" ID="lblDepartmentPicker" Text="Раздел:"></asp:Literal>
        <mb:SelectDepartmentControl ID="ddlDepartments" runat="server"></mb:SelectDepartmentControl>
        <asp:Literal runat="server" Text="&nbsp;&nbsp;&nbsp;" />
        <asp:CheckBox runat="server" ID="chkImageVisible" Text="Отображать картинки" TextAlign="Left"
            Checked="false" />
        <asp:Literal ID="Literal4" runat="server" Text="&nbsp;&nbsp;&nbsp;" />
        <asp:Literal runat="server" ID="lblPageSizePicker" Text="Товаров на странице:"></asp:Literal>
        <asp:DropDownList ID="ddlProductsPerPage" runat="server">
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="25">25</asp:ListItem>
            <asp:ListItem Value="50" Selected="True">50</asp:ListItem>
            <asp:ListItem Value="100">100</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button runat="server" ID="btnProduxtsView" Text="Отобразить" CssClass="enter"
            OnClick="btnProduxtsView_Click" />
        <p>
        </p>
        <asp:GridView ID="gvwProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="ProductID" OnPageIndexChanging="gvwProducts_PageIndexChanging"
            EmptyDataText="Нет товаров для отображения" OnRowCommand="gvwProducts_RowCommand"
            OnRowCreated="gvwProducts_RowCreated" OnRowDataBound="gvwProducts_RowDataBound"
            OnRowDeleting="gvwProducts_RowDeleting">
            <%--AllowSorting="True"--%>
            <Columns>
                <asp:TemplateField ItemStyle-Width="20px">
                    <HeaderTemplate>
                        <asp:CheckBox runat="server" ID="chkGvwProductsHeader" AutoPostBack="true" OnCheckedChanged="chkGvwProductsHeader_CheckedChanged"
                            Checked="false" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField runat="server" Value='<%# Eval("ProductID") %>' ID="hfID" />
                        <asp:CheckBox runat="server" ID="chkGvwProducts" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ImageField DataImageUrlField="SmallImageUrl" Visible="false">
                    <ItemStyle Width="110px" />
                </asp:ImageField>
                <asp:HyperLinkField HeaderText="Product" SortExpression="Title" DataTextField="Title"
                    DataNavigateUrlFormatString="~/ShowProduct.aspx?ID={0}" DataNavigateUrlFields="ProductID"
                    meta:resourcekey="HyperLinkFieldResource1">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:HyperLinkField>
                <asp:TemplateField HeaderText="Производитель" SortExpression="ManufacturerTitle"
                    ItemStyle-Width="50px">
                    <ItemTemplate>
                        <%# Eval("Manufacturer.Title") %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <%--      <asp:TemplateField HeaderText="Rating" meta:resourcekey="TemplateFieldResource1">
         <ItemTemplate>
            <div style="text-align: center">            
            <mb:RatingDisplay runat="server" ID="ratDisplay" Value='<%# Eval("AverageRating") %>'  />
            </div>
         </ItemTemplate>         
      </asp:TemplateField>--%>
                <%--      <asp:TemplateField HeaderText="Available" SortExpression="UnitsInStock" meta:resourcekey="TemplateFieldResource2">
         <ItemTemplate>
            <div style="text-align: center">
               <mb:AvailabilityDisplay runat="server" ID="availDisplay" Value='<%# Eval("UnitsInStock") %>' />
            </div>
         </ItemTemplate>         
          <ItemStyle HorizontalAlign="Center" />
      </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Валюта" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <%# Eval("Currency.CurrencyCode") %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Цена" SortExpression="UnitPrice" ItemStyle-Width="70px">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="adminInput" Text='<%# Bind("UnitPrice") %>'
                            Width="70px" />
                        <%--                    <mb:DecimalTextBox runat="server" ID="txtUnitPrice" Value='<%# Bind("UnitPrice") %>' CssClass="adminInput" RequiredErrorMessage="Обязательно для заполнения"
                        MinimumValue="0" MaximumValue="999999" RangeErrorMessage="Значение должно быть в диапазоне от -0 до 99999" Width="70px"> 
                    </mb:DecimalTextBox>  --%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Скидка" SortExpression="MarginPercentage" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMarginPercentage" runat="server" CssClass="adminInput" Text='<%# Bind("MarginPercentage") %>'
                            Width="50px" />
                        <%--                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtMarginPercentage"
                            Value='<%# Bind("MarginPercentage") %>' RequiredErrorMessage="Обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox>  --%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Цена дня" SortExpression="DiscountPercentage" ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDiscountPercentage" runat="server" CssClass="adminInput" Text='<%# Bind("DiscountPercentage") %>'
                            Width="50px" />
                        <%--                        <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtDiscountPercentage"
                            Value='<%# Bind("DiscountPercentage") %>' RequiredErrorMessage="Обязательно для заполнения"
                            RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999"
                            MinimumValue="-99999" MaximumValue="99999"></mb:NumericTextBox> --%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Итоговая цена" SortExpression="UnitPrice" ItemStyle-Width="100px">
                    <ItemTemplate>
                        <div style="text-align: right">
                            <%--<%# (this.Page as BasePage).FormatPrice(Eval("FinalPrice")) %>--%>
                            <%# (this.Page as BasePage).FormatPrice(UC.BLL.Store.CurrencyManager.ConvertCurrency((decimal)Eval("FinalPrice"), (UC.BLL.Store.Currency)Eval("Currency"), UC.BLL.Store.CurrencyManager.WorkingCurrency))%>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btnChangeVisible" CausesValidation="false" AlternateText="Изменить видимость"
                            ImageUrl="~/Images/vis.gif" CommandName="ChangeVisible" CommandArgument='<%# Eval("ProductID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" />
                </asp:TemplateField>
                <%--      <asp:TemplateField>
         <ItemTemplate>
         <asp:ImageButton runat="server" ID="btnAddToCart"
            CausesValidation="false" AlternateText="В корзину" ImageUrl="~/Images/cart.gif" 
            CommandName="AddToCart" CommandArgument='<%# Eval("ID") %>'/>
         </ItemTemplate>         
         <ItemStyle HorizontalAlign="Center" Width="40px" VerticalAlign="Middle" />         
      </asp:TemplateField>--%>
                <%--<asp:ButtonField ButtonType="Image" ImageUrl="~/Images/cart.gif" CommandName="AddToCart"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" />      --%>
                <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="lnkEdit" ToolTip="Редактировать товар" NavigateUrl='<%# "~/Admin/AddEditProduct.aspx?ID=" + Eval("ProductID") %>'
                            ImageUrl="~/Images/Edit.gif" Target="_blank" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="17px" />
                </asp:TemplateField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="Удалить"
                    ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="17px" />
                </asp:CommandField>
            </Columns>
            <EmptyDataTemplate>
                <b>
                    <asp:Literal ID="Literal1" runat="server" Text="<%$ resources:NoProducts %>" />
                </b>
            </EmptyDataTemplate>
        </asp:GridView>
        <p>
            <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="Обновить"
                OnClick="btnUpdate_Click" /><asp:Label ID="lblAttribute" runat="server" EnableViewState="false"
                    ForeColor="Red" Font-Size="Small"></asp:Label>
        </p>
        <%--<asp:ObjectDataSource ID="objProducts" runat="server" DeleteMethod="DeleteProduct" SortParameterName="sortExpression"
   SelectMethod="GetProducts" SelectCountMethod="GetProductCount" EnablePaging="True" TypeName="UC.BLL.Store.ProductManager">
   <DeleteParameters>
      <asp:Parameter Name="ProductID" Type="Int32" />
   </DeleteParameters>
   <SelectParameters>      
      <asp:ControlParameter ControlID="ddlDepartments" Name="departmentID" PropertyName="SelectedDepartmentId" Type="Int32" />
      <asp:Parameter Name="onlyVisible" Type="Boolean" DefaultValue="false" />
      <asp:Parameter Name="manufacturerID" Type="int32" DefaultValue="0" />
      <asp:ControlParameter ControlID="txtTitleFilter" Name="titleFilter" PropertyName="Text" Type="String" DefaultValue="" />
   </SelectParameters>
</asp:ObjectDataSource>--%>
    </ContentTemplate>
</asp:UpdatePanel>
