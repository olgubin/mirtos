<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollBox.ascx.cs" Inherits="UC.UI.Controls.PollBox" %>
<div class="box">
    <asp:Panel runat="server" ID="panHeader">
        <div class="boxtitle"><asp:Label runat="server" ID="lblHeader"></asp:Label></div>
    </asp:Panel>
    
    <div class="boxcontent">
        <div class="transparent"></div>
            <div class="pollquestion">
                <asp:Label runat="server" ID="lblQuestion"></asp:Label>
            </div>
            <asp:Panel runat="server" ID="panVote">
                <div class="polloptions">
                    <asp:RadioButtonList runat="server" ID="optlOptions" DataTextField="OptionText" DataValueField="ID" />
                    <asp:RequiredFieldValidator ID="valRequireOption" runat="server" ControlToValidate="optlOptions"
                        SetFocusOnError="True" Text="Выберите, пожалуйста ответ." ToolTip="Выберите, пожалуйста ответ."
                        Display="Dynamic" ValidationGroup="PollVote"></asp:RequiredFieldValidator>
                </div>
                
                <div class="vote">
                <asp:ImageButton runat="server" ID="imgbtnVote" ValidationGroup="PollVote" OnClick="btnVote_Click" SkinID="Vote" />
                <br/><br/>
                * проголосуйте, чтобы увидеть результаты опроса
                </div>
                </asp:Panel>
            <asp:Panel runat="server" ID="panResults">
                <div class="polloptions">
                    <asp:Repeater runat="server" ID="rptOptions">
                        <ItemTemplate>
                            <%# Eval("OptionText") %>
                            <small>(<%# Eval("Votes") %>
                                голос(ов) -
                                <%# Eval("Percentage", "{0:N1}") %>%)</small>
                            <br />
                            <div class="pollbar" style="width: <%# GetFixedPercentage(Eval("Percentage")) %>%">
                                &nbsp;</div>
                                <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <b>
                        <asp:Localize runat="server" ID="locTotVotes" Text="Всего проголосовало:"></asp:Localize>
                        <asp:Label runat="server" ID="lblTotalVotes" meta:resourcekey="lblTotalVotesResource1" /></b>
                </div>
            </asp:Panel>
            <asp:HyperLink runat="server" ID="lnkArchive" NavigateUrl="~/ArchivedPolls.aspx"
                Text="Archived Polls" meta:resourcekey="lnkArchiveResource1" />
    </div>

</div>
