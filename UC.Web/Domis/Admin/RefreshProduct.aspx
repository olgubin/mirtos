<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="RefreshProduct.aspx.cs" Inherits="UC.UI.RefreshProduct"
    Culture="auto" UICulture="auto" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="s">
                    |</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td class="s">
                    |</td>
                <td class="h1">
                    <a href="ManageParsingCatalogs.aspx">Управление каталогами</a>
                </td>
                <td class="s">
                    |</td>                
                <td class="h1">
                    <asp:HyperLink runat="server" ID="lnkCatalogTitle"></asp:HyperLink>
                </td>                
                <td class="s">
                    |</td>                
                <td class="h1">
                    <asp:HyperLink runat="server" ID="lnkRefreshCatalogTitle"></asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <table style="width: 100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblTitle" CssClass="labeltitle" />
                </td>
                <td style="text-align: right;">
<%--                    <asp:Panel runat="server" ID="panEditProduct">
                        <asp:HyperLink runat="server" ID="lnkEditProduct" ImageUrl="~/Images/Edit.gif" ToolTip="Edit product"
                            NavigateUrl="~/Admin/AddEditProduct.aspx?ID={0}" meta:resourcekey="lnkEditProductResource1" />
                        &nbsp;
                        <asp:ImageButton runat="server" ID="btnDelete" CausesValidation="false" AlternateText="Delete product"
                            ImageUrl="~/Images/Delete.gif" OnClientClick="if (confirm('Are you sure you want to delete this product?') == false) return false;"
                            OnClick="btnDelete_Click" meta:resourcekey="btnDeleteResource1" />
                    </asp:Panel>--%>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <table style="width: 237px;">
                        <tr>
                            <td style="width: 237px; height: 237px;">
                                <div class="productimage">
                                    <asp:Image runat="Server" ID="imgProduct" Width="233px" Height="233px" ImageUrl="~/Images/article.gif"
                                        GenerateEmptyAlternateText="true" /><br />
                                    <%--<div class="productrating" style="bottom: 3px; left: 3px;">
                                        <mb:RatingDisplay runat="server" ID="mbRating" />
                                    </div>--%>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <asp:HyperLink runat="server" ID="lnkFullImage" Font-Size="XX-Small" Target="_blank">Увеличить</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td class="productprice" style="padding: 7px; font-size: larger;">
                                <asp:Panel ID="pnlDiscountedPrice" runat="server">
                                    <asp:Literal runat="server" ID="lblDiscountedPrice"><s>{0}</s></asp:Literal><br />
                                </asp:Panel>
                                <asp:Literal runat="server" ID="lblPrice" />
                            </td>
                        </tr>
                        <tr>
                            <td class="productbuy">
<%--                                <asp:TextBox runat="server" ID="txtQuantity" Text="1" MaxLength="6" Width="30px"
                                    Font-Size="11px"></asp:TextBox>
                                <asp:ImageButton runat="server" ID="btnAddToCart" CausesValidation="false" AlternateText="В корзину"
                                    ImageUrl="~/Images/buy.gif" OnClick="btnAddToCart_Click" ImageAlign="AbsMiddle" />--%>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <b>
                                    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:Availability %>" /></b><mb:AvailabilityDisplay
                                        runat="server" ID="availDisplay" />
                            </td>
                        </tr>--%>
                    </table>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <b><asp:Literal runat="server" ID="lblDepartmentTitle" /><br /><br />
                                <asp:Literal runat="server" ID="lblSKU" /><br /><br /></b>
                                <b>Ссылка на сайте каталога: </b><asp:HyperLink runat="server" ID="lnkURL" Target="_new"/><br />
                                <p><b style="color: #9aaab1;">Краткое описание:</b></p>
                                <asp:Literal runat="server" ID="lblShortDescription" />                                
                                <p><b style="color: #9aaab1;">Полное описание:</b></p>
                                <asp:Literal runat="server" ID="lblLongDescription" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
