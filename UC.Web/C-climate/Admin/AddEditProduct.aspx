<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="Admin.master" AutoEventWireup="true"
    CodeFile="AddEditProduct.aspx.cs" Inherits="UC.UI.Admin.AddEditProduct" Culture="auto"
    UICulture="auto" %>

<%@ Register Src="~/Admin/Controls/ImageUploader.ascx" TagName="ImageUploader" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ProductDepartmentsControl.ascx" TagName="ProductDepartments" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ProductRelatedControl.ascx" TagName="ProductRelated" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ProductAttributesControl.ascx" TagName="ProductAttributes" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ProductDescriptionControl.ascx" TagName="ProductDescription" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ProductFilterCriteriaControl.ascx" TagName="ProductFilterCriteria" TagPrefix="mb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                    <asp:Image ID="Image3" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="ManageProducts.aspx">Управление товарами</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        <asp:Label runat="server" ID="lblTitle"></asp:Label></h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">

        <asp:Panel ID="pnlCopyProduct" runat="server">
        <asp:LinkButton ID="lbtnProductCopy" runat="server" onclick="lbtnProductCopy_Click">Добавить копию товара</asp:LinkButton>
        <asp:Label ID="lblProductCopy" runat="server" ForeColor="Red" Font-Size="10px"/>
        </asp:Panel>
        <h2><asp:Literal runat="server" ID="lblProduct" /></h2>
        <div>
            <ajaxToolkit:TabContainer runat="server" ID="ProductTabs" ActiveTabIndex="0">
                <ajaxToolkit:TabPanel runat="server" ID="pnlProductdescription" HeaderText="Описание товара">
                    <ContentTemplate>
                        <mb:ProductDescription runat="server" ID="ucProductDescription"/>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="pnlDepartmentMappings" HeaderText="Разделы">
                    <ContentTemplate>
                        <mb:ProductDepartments runat="server" ID="ucProductDepartments"/>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>                
                <ajaxToolkit:TabPanel runat="server" ID="pnlProductSpecification" HeaderText="Характеристики товара">
                    <ContentTemplate>
                        <mb:ProductAttributes runat="server" ID="ucProductAttributes"/>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="pnlRelatedProducts" HeaderText="Связанные товары">
                    <ContentTemplate>
                         <mb:ProductRelated runat="server" ID="ucProductRelated"/>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel runat="server" ID="TabPanel1" HeaderText="Критерии фильтрации">
                    <ContentTemplate>
                         <mb:ProductFilterCriteria runat="server" ID="ucProductFilterCriteria"/>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>                
            </ajaxToolkit:TabContainer>
            
            <mb:ImageUploader runat="server" ID="imageUploader" AbsoluteUrl="Images\\Store\\"
                Url="Images/Store/" />
        </div>
    </div>
</asp:Content>
