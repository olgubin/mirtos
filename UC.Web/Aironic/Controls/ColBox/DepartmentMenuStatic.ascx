<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentMenuStatic.ascx.cs"
    Inherits="UC.UI.Controls.DepartmentMenuStatic" EnableViewState="false" %>
<div style="padding-bottom:3px">
    <div class="boxtitle">
        <div class="boxtitle_middle">Каталог</div>    
        <div class="boxtitle_left"></div>
        <div class="boxtitle_right"></div>
    </div>
    
    
    <div class="boxtop">
        <div class="boxtop_middle"></div>
        <div class="boxtop_left"></div>
        <div class="boxtop_right"></div>
    </div>    
    
    <div class="boxmiddle">
        <table cellpadding="0">
        <tr>
        <td class="boxmiddle_left"></td>
        <td>
        <div class="boxmiddle_middle">
        
            <div class="menu">
            
        <table style="width: 100%;">
            <tr>
                <th>
                    <b>Видеодиктофоны</b>
                </th>
            </tr>        
            <tr>
                <td>
                <asp:Image SkinID="Menu" runat="server"/>
                     <a href="./BrowseProducts.aspx?DepID=1">AVIDIUS mobile</a>
                </td>
            </tr>
            <tr>
                <th>
                    <b>Диктофоны</b>
                </th>
            </tr>              
            <tr>
                <td>
                <asp:Image SkinID="Menu" runat="server"/>
                <a href="./BrowseProducts.aspx?DepID=2">Гном 2М</a>
                </td>
            </tr>                        
            <tr>
                <td>
                <asp:Image SkinID="Menu" runat="server"/>
                <a href="./BrowseProducts.aspx?DepID=3">Гном Р</a>
                </td>
            </tr>              
            <tr>
                <td>
                <asp:Image SkinID="Menu" runat="server"/>
                <a href="./BrowseProducts.aspx?DepID=4">Гном Нано</a>
                </td>
            </tr>                          
            <tr>
                <th>
                    <b>Аксессуары</b>
                </th>
            </tr>              
            <tr>
                <td>
                <asp:Image SkinID="Menu" runat="server"/>
                <a href="./BrowseProducts.aspx?DepID=5">Дополнительные аксессуары</a>
                </td>
            </tr>            

            </table>            
                    
            </div>        
        
        </div>           
        </td>
        <td class="boxmiddle_right"></td>
        </tr>
        </table>
    </div>    
    
    <div class="boxbottom">
        <div class="boxbottom_middle"></div>
        <div class="boxbottom_left"></div>
        <div class="boxbottom_right"></div>
    </div>        
    
</div>
