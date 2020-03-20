<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UC.UI._Default"
    MasterPageFile="~/Template.master" %>

<%@ MasterType VirtualPath="~/Template.master" %>
<%@ Register Src="Controls/Departments.ascx" TagName="Departments" TagPrefix="mb" %>
<%@ Register Src="Controls/WelcomeBox.ascx" TagName="Welcome" TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ProductFeaturedBox.ascx" TagName="ProductFeaturedBox"
    TagPrefix="mb" %>
<%@ Register Src="Controls/ColBox/ColorBox.ascx" TagName="ColorBox" TagPrefix="mb" %>
<%@ Register Src="~/Controls/FilterBoxControl.ascx" TagName="FilterBoxControlMebel"
    TagPrefix="mb" %>
<%@ Register Src="~/Controls/FilterBoxControl.ascx" TagName="FilterBoxControlDush"
    TagPrefix="mb" %>
<asp:Content ID="AdvertBox" ContentPlaceHolderID="AdvertBox" runat="Server">
    <mb:ProductFeaturedBox ID="ProductFeatured" runat="server" />
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:Departments ID="Departments" runat="server" RepeatColumns="2" MainReferencePage="Departments.aspx" ReferencePage="Departments.aspx"/>
    <mb:ColorBox ID="ColorBox" runat="server" />
    <div style="position: relative;">
        <div class="boxtop_middle">
        </div>
        <div class="boxtop_left">
        </div>
        <div class="boxtop_right">
        </div>
    </div>
    <div class="boxmiddle">
        <div class="boxmiddle">
            <table cellpadding="0">
                <tr>
                    <td class="boxmiddle_left">
                    </td>
                    <td>
                        <div class="boxmiddle_middle">
                            <div class="boxtitle">
                                Выбор мебели для ванной</div>
                            <mb:FilterBoxControlMebel runat="server" ID="ucFilterMebel" OnFiltered="ucFilter_FilteredMebel"
                                DepartmentID="316" />
                        </div>
                    </td>
                    <td class="boxmiddle_right">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="boxbottom">
        <div class="boxbottom_middle">
        </div>
        <div class="boxbottom_left">
        </div>
        <div class="boxbottom_right">
        </div>
    </div>
    <div style="padding-top: 10px">
        <div style="position: relative">
            <div class="boxtop_middle">
            </div>
            <div class="boxtop_left">
            </div>
            <div class="boxtop_right">
            </div>
        </div>
        <div class="boxmiddle">
            <div class="boxmiddle">
                <table cellpadding="0">
                    <tr>
                        <td class="boxmiddle_left">
                        </td>
                        <td>
                            <div class="boxmiddle_middle">
                                <div class="boxtitle">
                                    Выбор душевой кабины</div>
                                <mb:FilterBoxControlDush runat="server" ID="ucFilterDush" OnFiltered="ucFilter_FilteredDush"
                                    DepartmentID="317" />
                            </div>
                        </td>
                        <td class="boxmiddle_right">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="boxbottom">
            <div class="boxbottom_middle">
            </div>
            <div class="boxbottom_left">
            </div>
            <div class="boxbottom_right">
            </div>
        </div>
    </div>
    <mb:Welcome ID="Welcome" runat="server" />
</asp:Content>
