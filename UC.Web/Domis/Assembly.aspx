<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Assembly.aspx.cs" Inherits="UC.UI.Assembly" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <p>
            Компания осуществляет монтаж и сборку мебели для ванной и душевых кабин. Стоимость
            монтажа и сборки не входит в стоимость товара и расчитывается при оформлении заказа.
        </p>
    </div>
</asp:Content>
