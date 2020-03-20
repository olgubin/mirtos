<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColorBox.ascx.cs" Inherits="UC.UI.Controls.ColorBox"
    EnableViewState="false" %>
<%@ Import Namespace="UC.SEOHelper" %>
<%@ Import Namespace="UC.UI" %>
<div class="box">
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
            <table cellpadding="0" style="width: 100%">
                <tr>
                    <td class="boxmiddle_left">
                    </td>
                    <td>
                        <div class="boxmiddle_middle">
                            <div class="boxtitle">
                                Цветовые решения фасадов</div>
                            <div class="color">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn1" runat="server" ToolTip="Белый высокоглянцевый" 
                                                ImageUrl="~/Images/Store/color_white.png" CommandArgument="125" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Белый высокоглянцевый" ImageUrl="~/Images/Store/color_white.png" />--%>
                                            <br />
                                            Белый высокоглянцевый
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn2" runat="server" ToolTip="Каппуччино высокоглянцевый" 
                                                ImageUrl="~/Images/Store/color_cappuccino.png" CommandArgument="126" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Каппуччино высокоглянцевый" ImageUrl="~/Images/Store/color_cappuccino.png" />--%>
                                            <br />
                                            Каппуччино высокоглянцевый
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn3" runat="server" ToolTip="Ваниль высокоглянцевый" 
                                                ImageUrl="~/Images/Store/color_vanil.png" CommandArgument="127" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Ваниль высокоглянцевый" ImageUrl="~/Images/Store/color_vanil.png" />--%>
                                            <br />
                                            Ваниль высокоглянцевый
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn4" runat="server" ToolTip="Бриллиантово-красный высокоглянцевый" 
                                                ImageUrl="~/Images/Store/color_briliant.png" CommandArgument="128" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Бриллиантово-глянцевый высокоглянцевый" ImageUrl="~/Images/Store/color_briliant.png" />--%>
                                            <br />
                                            Бриллиантово-красный высокоглянцевый
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn5" runat="server" ToolTip="Антрацит высокоглянцевый" 
                                                ImageUrl="~/Images/Store/color_antracit.png" CommandArgument="129" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Антрацит высокоглянцевый" ImageUrl="~/Images/Store/color_antracit.png" />--%>
                                            <br />
                                            Антрацит высокоглянцевый
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn6" runat="server" ToolTip="Красный" 
                                                ImageUrl="~/Images/Store/color_red.png" CommandArgument="150" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Красный" ImageUrl="~/Images/Store/color_red.png" />--%>
                                            <br />
                                            Красный
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn7" runat="server" ToolTip="Декор зебрано" 
                                                ImageUrl="~/Images/Store/color_zebrano.png" CommandArgument="147" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Декор зебрано" ImageUrl="~/Images/Store/color_zebrano.png" />--%>
                                            <br />
                                            Декор зебрано
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn8" runat="server" ToolTip="Декор оливка" 
                                                ImageUrl="~/Images/Store/color_olivka.png" CommandArgument="148" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Декор оливка" ImageUrl="~/Images/Store/color_olivka.png" />--%>
                                            <br />
                                            Декор оливка
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn9" runat="server" ToolTip="Выбеленный дуб" 
                                                ImageUrl="~/Images/Store/color_dub.png" CommandArgument="149" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Выбеленный дуб" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            Выбеленный дуб
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn10" runat="server" ToolTip="Дуб венге" 
                                                ImageUrl="~/Images/Store/color_dub_venge.png" CommandArgument="190" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Выбеленный дуб" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            Дуб венге                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn11" runat="server" ToolTip="Розовый" 
                                                ImageUrl="~/Images/Store/color_rozoviy.png" CommandArgument="191" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Красный" ImageUrl="~/Images/Store/color_red.png" />--%>
                                            <br />
                                            Розовый
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn12" runat="server" ToolTip="Салатный" 
                                                ImageUrl="~/Images/Store/color_salatniy.png" CommandArgument="192" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Декор зебрано" ImageUrl="~/Images/Store/color_zebrano.png" />--%>
                                            <br />
                                            Салатный
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn13" runat="server" ToolTip="Голубой" 
                                                ImageUrl="~/Images/Store/color_goluboy.png" CommandArgument="193" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Декор оливка" ImageUrl="~/Images/Store/color_olivka.png" />--%>
                                            <br />
                                            Голубой
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn14" runat="server" ToolTip="Бежевый" 
                                                ImageUrl="~/Images/Store/color_bejeviy.png" CommandArgument="194" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Выбеленный дуб" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            Бежевый
                                        </td>
                                        <td>                                    
                                        </td>
                                    </tr>                                    
                                </table>
                            </div>
                            <div class="boxtitle">
                                Цветовые решения стекляных фасадов</div>
                            <div class="color">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn15" runat="server" ToolTip="Стекло бриллиантово-красное" 
                                                ImageUrl="~/Images/Store/glass_briliant.png" CommandArgument="128" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Стекло бриллиантово-красное" ImageUrl="~/Images/Store/glass_briliant.png" />--%>
                                            <br />
                                            Стекло бриллиантово-красное
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn16" runat="server" ToolTip="Стекло каппуччино" 
                                                ImageUrl="~/Images/Store/glass_cappuccino.png" CommandArgument="126" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="Стекло каппуччино" ImageUrl="~/Images/Store/glass_cappuccino.png" />--%>
                                            <br />
                                            Стекло каппуччино
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn17" runat="server" ToolTip="Стекло антрацит" 
                                                ImageUrl="~/Images/Store/glass_antracit.png" CommandArgument="129" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Стекло антрацит" ImageUrl="~/Images/Store/glass_antracit.png" />--%>
                                            <br />
                                            Стекло антрацит
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn18" runat="server" ToolTip="Стекло черное" 
                                                ImageUrl="~/Images/Store/glass_black.png" CommandArgument="146" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="Стекло черное" ImageUrl="~/Images/Store/glass_black.png" />--%>
                                            <br />
                                            Стекло черное
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
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
