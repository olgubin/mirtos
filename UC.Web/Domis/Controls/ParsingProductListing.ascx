<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParsingProductListing.ascx.cs"
    Inherits="UC.UI.Controls.ParsingProductListing" %>
<%@ Register Src="../Controls/ParsingProductView.ascx" TagName="ParsingProductView"
    TagPrefix="mb" %>
<%@ Register Src="../Controls/Product/ProductView.ascx" TagName="ProductView" TagPrefix="mb" %>
<%@ Register Src="../Controls/Paging.ascx" TagName="Paging" TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>

<script type="text/javascript">
/* <![CDATA[ */ 
function checkAll(form, field, value) {
	for (i = 0; i < form.elements.length; i++) {
		if(form.elements[i].type == "checkbox")
			form.elements[i].checked = value;}}
/* ]]> */ 
</script>

<div id="content">
    <asp:Label runat="server" ID="lblTitle" CssClass="labeltitle" />
    <p>
    </p>
    <asp:LinkButton runat="server" ID="btnRefreshCatalog" OnClick="btnRefreshCatalog_Click">Обновить каталог</asp:LinkButton>&nbsp&nbsp|&nbsp&nbsp
Отображать    
    
<asp:DropDownList ID="ddlView" runat="server" AutoPostBack="True" Width="170px" OnSelectedIndexChanged="ddlView_SelectedIndexChanged">
   <asp:ListItem Value="0">Все товары</asp:ListItem>   
   <asp:ListItem Value="1">Измененные товары</asp:ListItem>   
   <asp:ListItem Value="2">Товары с разными ценами</asp:ListItem>   
   <asp:ListItem Value="3">Новые товары</asp:ListItem>   
   <asp:ListItem Value="4">Удаленные товары</asp:ListItem>   
   <asp:ListItem Value="5">Восстановленные товары</asp:ListItem>      
</asp:DropDownList>    
    
    <br />
    <br />
    <a href="javascript:checkAll(document.forms[0], 'chk', 1);">Выделить все товары на странице</a>&nbsp/&nbsp
    <a href="javascript:checkAll(document.forms[0], 'chk', 0);">Снять выделение</a>
<div style="height:30px;padding-top:15px;">
    Обновить:
<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/refprice.gif" ToolTip="Обновить цену" GenerateEmptyAlternateText="true"/>
<asp:CheckBox runat="server" ID="chkPrice" EnableViewState="false"/>
<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/refimg.gif" ToolTip="Обновить картинку" GenerateEmptyAlternateText="true"/>
<asp:CheckBox runat="server" ID="chkImg" EnableViewState="false"/>
<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/refsd.gif" ToolTip="Обновить краткое описание" GenerateEmptyAlternateText="true"/>
<asp:CheckBox runat="server" ID="chkShortDescr" EnableViewState="false"/>
<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/refld.gif" ToolTip="Обновить полное описание" GenerateEmptyAlternateText="true"/>
<asp:CheckBox runat="server" ID="chkLongDescr" EnableViewState="false"/>&nbsp
<asp:ImageButton runat="server" ID="btnSelect" AlternateText="Обновить в выделенных товарах" ImageUrl="~/Images/ref.gif" OnClick="btnSelect_Click"/>    
</div>          
    <asp:Literal runat="server" ID="lblDepartmentPicker" Text="Добавить выделенные товары в раздел: "></asp:Literal>
    <asp:DropDownList ID="ddlDepartments" runat="server" AutoPostBack="False" DataSourceID="objAllDepartments"
        Width="220px" DataTextField="Title" DataValueField="ID" AppendDataBoundItems="True">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="objAllDepartments" runat="server" SelectMethod="GetDepartments"
        TypeName="UC.BLL.Store.Department"></asp:ObjectDataSource>
    <asp:Button runat="server" ID="btnInsertProductInDepartment" Text="Добавить" OnClick="btnInsertProductInDepartment_Click" />
<br /><br />
    <table style="width: 100%;">
        <tr>
            <td style="text-align: left; width: 70%;" class="sorting">
                <span>Сортировать по:</span><br />
                <asp:LinkButton runat="server" ID="lbtnTitle" CommandName="Title" OnCommand="Sorting">
                    названию<asp:Image runat="server" ID="imgTitleAsc" SkinID="SortAsc" /><asp:Image
                        runat="server" ID="imgTitleDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnPrice" CommandName="Price" OnCommand="Sorting">
                    цене<asp:Image runat="server" ID="imgPriceAsc" SkinID="SortAsc" /><asp:Image runat="server"
                        ID="imgPriceDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnRating" CommandName="Rating" OnCommand="Sorting">
                    популярности<asp:Image runat="server" ID="imgRatingAsc" SkinID="SortAsc" /><asp:Image
                        runat="server" ID="imgRatingDesc" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnNew" CommandName="New" OnCommand="Sorting">
                    новизне<asp:Image ID="imgNewAsc" runat="server" SkinID="SortAsc" /><asp:Image ID="imgNewDesc"
                        runat="server" SkinID="SortDesc" /></asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtnDepartment" CommandName="Department" OnCommand="Sorting">
                    разделам<asp:Image ID="imgDepartmentAsc" runat="server" SkinID="SortAsc" /><asp:Image
                        ID="imgDepartmentDesc" runat="server" SkinID="SortDesc" /></asp:LinkButton>
            </td>
            <td style="text-align: right; width: 30%;" class="sorting">
                <span>Показывать по:</span><br />
                <asp:LinkButton runat="server" ID="lbtn10" CommandName="10" OnCommand="PageSize"
                    ForeColor="white" BackColor="#9aaab1">10</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn20" CommandName="20" OnCommand="PageSize">20</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn30" CommandName="30" OnCommand="PageSize">30</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn40" CommandName="40" OnCommand="PageSize">40</asp:LinkButton>
                |
                <asp:LinkButton runat="server" ID="lbtn50" CommandName="50" OnCommand="PageSize">50</asp:LinkButton></td>
        </tr>
    </table>
    <p>
    </p>
    <mb:Paging runat="server" ID="PagingTop"/>
    <asp:DataList ID="dlstProducts" EnableTheming="False" runat="server" DataKeyField="ID"
        Width="100%" RepeatColumns="1" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0"
        OnSelectedIndexChanged="dlstProducts_SelectedIndexChanged" OnItemCreated="dlstProducts_ItemCreated" EnableViewState="true">
        <ItemStyle CssClass="product" />
        <HeaderStyle Height="1px" BackColor="#e4e4e4" />
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td style="text-align: center;">
                        <asp:Literal runat="server" ID="litID" Visible="false" Text='<%# Eval("ID") %>'></asp:Literal>
                        <asp:CheckBox ID="chk" runat="server" />
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/Images/Delete.gif" ToolTip='<%# "Удалить " + Eval("Title") %>' CommandName="Delete"
                            OnCommand="DeleteParsingProduct" CommandArgument='<%#Eval("ID")%>' OnClientClick="if (confirm('Подтвердите удаление товара!') == false) return false;" />
                    </td>
                    <td style="width: 48%;">
                        <mb:ParsingProductView runat="server" ID="ParsingProductView" 
                            Title='<%# Eval("Title") %>'
                            NavigateURL='<%# "~/Admin/ManageParsingProduct.aspx?CatalogID=" + Eval("CatalogID") + "&ID=" + Eval("ID") %>'
                            DepartmentTitle='<%#Eval("DepartmentTitle")%>' 
                            SKU='<%#Eval("SKU")%>' 
                            Error='<%# Eval("Error") %>'
                            IsNew='<%# Eval("IsNew") %>' 
                            IsUpdated='<%# Eval("IsUpdated") %>' 
                            IsRestored='<%# Eval("IsRestored") %>'
                            IsDeleted='<%# Eval("IsDeleted") %>' 
                            ImageURL='<%# String.IsNullOrEmpty(Eval("SmallImageUrl").ToString())?"~/Images/product.gif":Eval("SmallImageUrl") %>'
                            DiscountPercentage='<%#Eval("DiscountPercentage")%>' 
                            UnitPrice='<%#Eval("UnitPrice")%>'
                            ShortDescription='<%#Eval("ShortDescription")%>' />
                    </td>
                    <td>
<table width="50px">
<tr style="height:23px;">
<td style="vertical-align:middle;text-align:right"><asp:Image ID="Image3" runat="server" ImageUrl="~/Images/refprice.gif" ToolTip="Обновить цену" GenerateEmptyAlternateText="true"/></td>
<td style="vertical-align:top;text-align:left"><asp:CheckBox runat="server" ID="chkRefreshPrice"/></td>
</tr>
<tr style="height:23px;">
<td style="vertical-align:middle;text-align:right"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/refimg.gif" ToolTip="Обновить картинку" GenerateEmptyAlternateText="true"/></td>
<td style="vertical-align:top;text-align:left"><asp:CheckBox runat="server" ID="chkRefImg"/></td>
</tr>        
<tr style="height:23px;">
<td style="vertical-align:middle;text-align:right"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/refsd.gif" ToolTip="Обновить краткое описание" GenerateEmptyAlternateText="true"/></td>
<td style="vertical-align:top;text-align:left"><asp:CheckBox runat="server" ID="chkRefShortDescr"/></td>
</tr>                
<tr style="height:23px;">
<td style="vertical-align:middle;text-align:right"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/refld.gif" ToolTip="Обновить полное описание" GenerateEmptyAlternateText="true"/></td>
<td style="vertical-align:top;text-align:left"><asp:CheckBox runat="server" ID="chkRefLongDescr"/></td>
</tr>                        
<tr style="height:30px;">
<td colspan="2" style="vertical-align:middle;text-align:center">
<asp:ImageButton runat="server" ID="btnRefresh" AlternateText="Обновить" ImageUrl="~/Images/ref.gif" CommandName="Select"/>
</td>
</tr>
</table>
<br />
                    </td>
                    <td style="width: 48%;">
                        <mb:ProductView runat="server" ID="ProductView" 
                            Title='<%# Eval("MainProduct.Title") %>'
                            ProductID='<%#  Eval("MainProduct") == null ? 0 : Eval("MainProduct.ID")%>'
                            NavigateURL='<%# "~/ShowProduct.aspx?ID=" + Eval("MainProduct.ID") %>' 
                            DepartmentTitle='<%#Eval("MainProduct.DepartmentTitle")%>' 
                            DepartmentID='<%#  Eval("MainProduct") == null ? 0 : Eval("MainProduct.DepartmentID")%>'
                            ExtendedTitle="true"
                            SKU='<%#Eval("MainProduct.SKU")%>'                             
                            ImageURL='<%# Eval("MainProduct") == null ? "~/Images/product.gif" : String.IsNullOrEmpty(Eval("MainProduct.SmallImageUrl").ToString())?"~/Images/product.gif":Eval("MainProduct.SmallImageUrl") %>'
                            DiscountPercentage='<%# Eval("MainProduct") == null ? 0 : Eval("MainProduct.DiscountPercentage") %>'
                            CurrencyID='<%#  Eval("MainProduct") == null ? 0.0m : Eval("MainProduct.CurrencyID")%>'
                            UnitPrice='<%#  Eval("MainProduct") == null ? 0.0m : Eval("MainProduct.UnitPrice")%>'
                            FinalPrice='<%#  Eval("MainProduct") == null ? 0.0m : Eval("MainProduct.FinalPrice")%>'
                            ShortDescription='<%#Eval("MainProduct.ShortDescription")%>' 
                            Votes='<%# Eval("MainProduct") == null ? 0 : Eval("MainProduct.Votes") %>'
                            AverageRating='<%# Eval("MainProduct") == null ? 0.0 : Eval("MainProduct.AverageRating") %>'
                            VisisbleAddToCart="False" />
                    </td>
                    <td style="text-align: center;">
                        <asp:ImageButton runat="server" ID="btnChangeVisible" 
                            ImageUrl='<%# Eval("MainProduct") != null ? ((bool)Eval("MainProduct.Visible") ? "~/Images/vis.gif" : "~/Images/unvis.gif") : "" %>' 
                            ToolTip='<%# Eval("MainProduct") != null ? ((bool)Eval("MainProduct.Visible") ? "Товар виден в основном каталоге" : "Товар невиден в основном каталоге") : "" %>' CommandName="ChangeVisible"
                            OnCommand="ProductChangeView" CommandArgument='<%#  Eval("MainProduct") == null ? 0 : Eval("MainProduct.ID")%>'/>
                    </td>                    
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList><mb:Paging runat="server" ID="PagingBottom" />
</div>
