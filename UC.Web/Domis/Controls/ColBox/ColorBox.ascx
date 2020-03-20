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
                                �������� ������� �������</div>
                            <div class="color">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn1" runat="server" ToolTip="����� ���������������" 
                                                ImageUrl="~/Images/Store/color_white.png" CommandArgument="125" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="����� ���������������" ImageUrl="~/Images/Store/color_white.png" />--%>
                                            <br />
                                            ����� ���������������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn2" runat="server" ToolTip="���������� ���������������" 
                                                ImageUrl="~/Images/Store/color_cappuccino.png" CommandArgument="126" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="���������� ���������������" ImageUrl="~/Images/Store/color_cappuccino.png" />--%>
                                            <br />
                                            ���������� ���������������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn3" runat="server" ToolTip="������ ���������������" 
                                                ImageUrl="~/Images/Store/color_vanil.png" CommandArgument="127" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="������ ���������������" ImageUrl="~/Images/Store/color_vanil.png" />--%>
                                            <br />
                                            ������ ���������������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn4" runat="server" ToolTip="������������-������� ���������������" 
                                                ImageUrl="~/Images/Store/color_briliant.png" CommandArgument="128" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="������������-��������� ���������������" ImageUrl="~/Images/Store/color_briliant.png" />--%>
                                            <br />
                                            ������������-������� ���������������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn5" runat="server" ToolTip="�������� ���������������" 
                                                ImageUrl="~/Images/Store/color_antracit.png" CommandArgument="129" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="�������� ���������������" ImageUrl="~/Images/Store/color_antracit.png" />--%>
                                            <br />
                                            �������� ���������������
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn6" runat="server" ToolTip="�������" 
                                                ImageUrl="~/Images/Store/color_red.png" CommandArgument="150" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="�������" ImageUrl="~/Images/Store/color_red.png" />--%>
                                            <br />
                                            �������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn7" runat="server" ToolTip="����� �������" 
                                                ImageUrl="~/Images/Store/color_zebrano.png" CommandArgument="147" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="����� �������" ImageUrl="~/Images/Store/color_zebrano.png" />--%>
                                            <br />
                                            ����� �������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn8" runat="server" ToolTip="����� ������" 
                                                ImageUrl="~/Images/Store/color_olivka.png" CommandArgument="148" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="����� ������" ImageUrl="~/Images/Store/color_olivka.png" />--%>
                                            <br />
                                            ����� ������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn9" runat="server" ToolTip="���������� ���" 
                                                ImageUrl="~/Images/Store/color_dub.png" CommandArgument="149" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="���������� ���" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            ���������� ���
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn10" runat="server" ToolTip="��� �����" 
                                                ImageUrl="~/Images/Store/color_dub_venge.png" CommandArgument="190" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="���������� ���" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            ��� �����                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn11" runat="server" ToolTip="�������" 
                                                ImageUrl="~/Images/Store/color_rozoviy.png" CommandArgument="191" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="�������" ImageUrl="~/Images/Store/color_red.png" />--%>
                                            <br />
                                            �������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn12" runat="server" ToolTip="��������" 
                                                ImageUrl="~/Images/Store/color_salatniy.png" CommandArgument="192" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="����� �������" ImageUrl="~/Images/Store/color_zebrano.png" />--%>
                                            <br />
                                            ��������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn13" runat="server" ToolTip="�������" 
                                                ImageUrl="~/Images/Store/color_goluboy.png" CommandArgument="193" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="����� ������" ImageUrl="~/Images/Store/color_olivka.png" />--%>
                                            <br />
                                            �������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn14" runat="server" ToolTip="�������" 
                                                ImageUrl="~/Images/Store/color_bejeviy.png" CommandArgument="194" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="���������� ���" ImageUrl="~/Images/Store/color_dub.png" />--%>
                                            <br />
                                            �������
                                        </td>
                                        <td>                                    
                                        </td>
                                    </tr>                                    
                                </table>
                            </div>
                            <div class="boxtitle">
                                �������� ������� ��������� �������</div>
                            <div class="color">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="imgBtn15" runat="server" ToolTip="������ ������������-�������" 
                                                ImageUrl="~/Images/Store/glass_briliant.png" CommandArgument="128" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="������ ������������-�������" ImageUrl="~/Images/Store/glass_briliant.png" />--%>
                                            <br />
                                            ������ ������������-�������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn16" runat="server" ToolTip="������ ����������" 
                                                ImageUrl="~/Images/Store/glass_cappuccino.png" CommandArgument="126" oncommand="onCommand"/>
                                            <%--<asp:Image runat="server" ToolTip="������ ����������" ImageUrl="~/Images/Store/glass_cappuccino.png" />--%>
                                            <br />
                                            ������ ����������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn17" runat="server" ToolTip="������ ��������" 
                                                ImageUrl="~/Images/Store/glass_antracit.png" CommandArgument="129" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="������ ��������" ImageUrl="~/Images/Store/glass_antracit.png" />--%>
                                            <br />
                                            ������ ��������
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="imgBtn18" runat="server" ToolTip="������ ������" 
                                                ImageUrl="~/Images/Store/glass_black.png" CommandArgument="146" oncommand="onCommand"/>                                        
                                            <%--<asp:Image runat="server" ToolTip="������ ������" ImageUrl="~/Images/Store/glass_black.png" />--%>
                                            <br />
                                            ������ ������
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
