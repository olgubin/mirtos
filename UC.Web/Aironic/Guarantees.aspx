<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Guarantees.aspx.cs" Inherits="UC.UI.Guarantees"
    MasterPageFile="~/Template.master" %>

<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<%--<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="Recommend" runat="server" />
</asp:Content>--%>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx" EnableViewState="false">√лавна€</asp:HyperLink>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        √арантии</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
    <br />
        <div class="wizard">
            <table width="100%">
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        √арантийные сроки на кондиционеры:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>Daikin</li>
                            <li>General Fujitsu</li>
                            <li>Toshiba</li>
                            <li>Sanyo</li>
                            <li>Mitsubishi Electric</li>
                            <li>General Climate</li>
                            <li>Panasonic</li>
                            <li>Hitachi</li>
                            <li>Haier</li>
                            <li>Kentatsu</li>
                            <li>LG</li>
                            <li>Midea</li>
                            <li>Lessar</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        √арантийные сроки на вентил€ционное оборудование:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>NED</li>
                            <li>¬ингс-ћ</li>
                            <li>Lindab</li>
                            <li>Systemair</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>1 год</li>
                            <li>1 год</li>
                            <li>1 год</li>
                            <li>1 год</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        √арантийные сроки на тепловое оборудование:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>“епломаш</li>
                            <li>Frico</li>
                            <li>“ропик</li>
                            <li>2VV</li>
                            <li>EuroHeat</li>
                            <li>Olefini/General</li>
                            <li>NED</li>
                            <li>Korf</li>
                            <li>Remak</li>
                            <li>Pyrox</li>
                            <li>Ensto</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                            <li>3 года</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <th colspan="2" style="text-align:left;padding-left:17px">
                        √арантийные сроки на оборудование дл€ систем отоплени€:
                    </th>
                </tr>
                <tr>
                    <td>
                        <ul>
                            <li>Global</li>
                            <li>Purmo</li>
                            <li>Danfoss</li>
                            <li>Bugatti</li>
                            <li>RBM</li>
                        </ul>
                    </td>
                    <td>
                        <ul style="list-style-type:none">
                            <li>10 лет</li>
                            <li>10 лет</li>
                            <li>1 лет</li>
                            <li>50 лет (откр/закр 20 000 циклов)</li>
                            <li>1 год</li>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            √аранти€ на оборудование приобретаемое без монтажа предоставл€етс€ от сервисных
            центров производител€.
        </p>
        <p>
            √аранти€ на системы вентил€ции - 1 год.
        </p>
        <p>
            √аранти€ на монтажные работы с момента пуско-наладочных работ - 1 год.
        </p>
        <p>
            ѕри обращении по гарантии ѕокупатель об€зан предоставить необходимые документы,
            заполненные соответствующим образом. (ƒоговор, гарантийный талон, документ подтверждающий
            оплату).
        </p>
        <p />
    </div>
</asp:Content>
