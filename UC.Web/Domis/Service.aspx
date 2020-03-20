<%@ Page Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true"
    CodeFile="Service.aspx.cs" Inherits="UC.UI.Service" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>    
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox" TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <p />
        <p>
            Сервисная служба осуществляет сервисное обслуживание
            душевых кабин.
        </p>
        <p>
            Мы применяем расходные части и материалы импортного производства высокого качества.
        </p>
        <p>
            Стоимость профилактических и сервисных работ определяется после выезда инженера на объект Заказчика.
        </p>
        <p>
            Выезд инженера сервисной службы для проведения диагностики оборудования, а также
            определения стоимости ремонтных работ осуществляется - платно.
        </p>
        <p>
            Ориентировочную стоимость сервисного обслуживания, можно получить, связавшись с
            инженером технического отдела по телефону – <b>(495)514-86-37</b>.
        </p>
        <p>
            <b>На все выполненные работы мы предоставляем гарантию 1 год.</b>
        </p>
        <p />
    </div>
</asp:Content>
