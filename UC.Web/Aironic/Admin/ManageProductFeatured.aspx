<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageProductFeatured.aspx.cs" Inherits="UC.UI.Admin.ManageProductFeatured"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="false" %>

<%@ Register Src="../Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox"
    TagPrefix="mb" %>
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
                        Блок рекомендованные товары</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:GridView ID="gvFeaturedProducts" runat="server" AutoGenerateColumns="false"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Product" ItemStyle-Width="40%">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbProductInfo" runat="server" Text='<%# Server.HtmlEncode(Eval("ProductInfo").ToString()) %>'
                                    Checked='<%# Eval("IsMapped") %>' />
                                <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                <asp:HiddenField ID="hfProductFeaturedID" runat="server" Value='<%# Eval("ProductFeaturedID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Открыть" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href='ShowProduct.aspx?ID=<%# Eval("ProductID") %>' target="_blank">Открыть</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Порядок отображения" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtDisplayOrder"
                                    Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="Обязательно для заполнения"
                                    RangeErrorMessage="Значение должно быть в диапазоне от -99999 до 99999" MinimumValue="-99999"
                                    MaximumValue="99999"></mb:NumericTextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Реклама" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40%"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:TextBox runat="server" ID="txProductFeaturedDescription" MaxLength="125" Width="97%"
                                    TextMode="MultiLine" Rows="2" Text='<%# Eval("Description") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <p>
                    <asp:Button ID="btnProductFeatured" runat="server" CssClass="adminButton" Text="Сохранить"
                        OnClick="btnProductFeatured_Click" />&nbsp&nbsp<asp:Label ID="lblFeedBack" runat="server"
                            EnableViewState="false" ForeColor="Red" Font-Size="Small"></asp:Label></p>
                <p>
                    * рекламное описание не должно превышать 125 символов</p>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
