<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParsingProductView.ascx.cs"
    Inherits="UC.UI.Controls.ParsingProductView" %>
<%@ Register Src="../Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="../Controls/AvailabilityDisplay.ascx" TagName="AvailabilityDisplay"
    TagPrefix="mb" %>
<%@ Import Namespace="UC.UI" %>

<table style="width: 100%;">
    <tr>
        <td colspan="2" class="producttitle">
            <asp:HyperLink runat="server" ID="HyperLink6" Text='<%# Title %>' NavigateUrl='<%# NavigateURL %>' />
            <br />
            <span style="font-weight: normal;">
                <%# DepartmentTitle %>
            </span>
            <br />
            <span style="font-weight: normal;">Артикул:
                <%# SKU %>
            </span>
            <asp:Panel ID="Panel8" runat="server" Visible='<%# String.IsNullOrEmpty(Error) ? false : true %>'
                Font-Bold="false">
                <asp:Label ID="Label2" runat="server" Text='<%# Error %>' ForeColor="red"></asp:Label>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 110px;">
            <table style="width: 107px;">
                <tr>
                    <td style="text-align: center;">
                        <asp:Panel ID="Panel1" runat="server" Visible='<%# String.IsNullOrEmpty(Error) ? false : true %>'>
                            <img src="../Images/IsError.gif" alt="" />
                        </asp:Panel>
                        <asp:Panel ID="Panel2" runat="server" Visible='<%# IsNew %>'>
                            <img src="../Images/IsNew.gif" alt="" />
                        </asp:Panel>
                        <asp:Panel ID="Panel3" runat="server" Visible='<%# IsUpdated %>'>
                            <img src="../Images/IsUpdated.gif" alt="" />
                        </asp:Panel>
                        <asp:Panel ID="Panel4" runat="server" Visible='<%# IsRestored %>'>
                            <img src="../Images/IsRestored.gif" alt="" />
                        </asp:Panel>
                        <asp:Panel ID="Panel5" runat="server" Visible='<%# IsDeleted %>'>
                            <img src="../Images/IsDeleted.gif" alt="" />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="height: 110px;">
                        <div class="productimage">
                            <asp:HyperLink runat="server" ID="HyperLink7" NavigateUrl='<%# NavigateURL %>'
                                ToolTip='<%# Title %>'>
                                <asp:Image runat="server" ID="Image3" BorderWidth="0px" GenerateEmptyAlternateText="true"
                                    ImageUrl='<%# ImageURL %>'
                                    Width="100px" Height="100px" /></asp:HyperLink>
                            <div class="productrating">
                                <mb:RatingDisplay runat="server" ID="ParsingRatingDisplay" Value='<%# TotalRating %>' Visible='<%# TotalRating > 0 %>' />
                            </div>
                            <asp:Panel ID="pnlParsingDiscount" runat="server" Visible='<%# DiscountPercentage > 0 %>'
                                CssClass="productdiscount">
                                <span><%# DiscountPercentage %>%</span></asp:Panel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="productprice">
                        <%# (this.Page as BasePage).FormatPrice(UnitPrice) %>
                    </td>
                </tr>
            </table>
        </td>
        <td>
            <div class="productdescription"><asp:HyperLink runat="server" ID="HyperLink8" Text='<%# ShortDescription %>' NavigateUrl='<%# NavigateURL %>' /></div>
        </td>
    </tr>
    <tr>
    </tr>
</table>
