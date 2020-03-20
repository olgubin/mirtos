<%@ Page Language="C#" MasterPageFile="~/Template.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="UC.UI.ShowArticle"
    MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="./Controls/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="mb" %>
<%@ Register Src="Controls/404.ascx" TagName="Control404" TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
    <div id="content">
        <mb:Control404 runat="server" ID="ctrl404" />
        <asp:Panel runat="server" ID="pnlContent">
            <br />
            <asp:Panel runat="server" ID="panEditArticle" Width="100%" HorizontalAlign="Right">
                <asp:ImageButton runat="server" ID="btnApprove" CausesValidation="false" AlternateText="Утвердить статью"
                    ImageUrl="~/Images/Checkmark.gif" OnClientClick="if (confirm('Подтвердите утверждение статьи') == false) return false;"
                    OnClick="btnApprove_Click" />
                &nbsp;
                <asp:HyperLink runat="server" ID="lnkEditArticle" ImageUrl="~/Images/Edit.gif" ToolTip="Edit article"
                    NavigateUrl="~/Admin/AddEditArticle.aspx?ID={0}" />
                &nbsp;
                <asp:ImageButton runat="server" ID="btnDelete" CausesValidation="false" AlternateText="Удалить статью"
                    ImageUrl="~/Images/Delete.gif" OnClientClick="if (confirm('Подтвердите удаление статьи') == false) return false;"
                    OnClick="btnDelete_Click" />
            </asp:Panel>
            <div style="float: left; margin-top: -2px; padding-right: 7px;">
                <h2 style="font-size: small">
                    <asp:Literal runat="server" ID="lblTitle" /></h2>
            </div>
            <mb:RatingDisplay runat="server" ID="ratDisplay" />
            &nbsp<asp:Label runat="server" ID="lblNotApproved" Text="Не утверждена" SkinID="NotApproved" />
            <div style="padding: 17px; text-align: justify">
                <%--            <asp:Label runat="server" ID="lblAbstract" ForeColor="#777777" />
            <br />
            <br />--%>
                <asp:Literal runat="server" ID="lblBody" />
            </div>
            <br />
            <div style="padding-bottom: 7px; padding-top: 7px; width: 100%; border-top: solid 1px #E4E4E4">
                Как вы оцениваете эту статью?</div>
            <asp:DropDownList runat="server" ID="ddlRatings">
                <asp:ListItem Value="1" Text="1 бал" />
                <asp:ListItem Value="2" Text="2 балла" />
                <asp:ListItem Value="3" Text="3 балла" />
                <asp:ListItem Value="4" Text="4 балла" />
                <asp:ListItem Value="5" Text="5 баллов" Selected="true" />
            </asp:DropDownList>
            <asp:Button runat="server" ID="btnRate" Text="Голосовать" OnClick="btnRate_Click"
                CausesValidation="false" Font-Size="9pt" />
            <div style="padding-left: 7px">
                <asp:Label runat="server" ID="lblUserRating" Visible="False" Text="Ваша оценка этой статьи {0} бал(ла/лов)."
                    ForeColor="#777777" />
            </div>
            <p />
            <%--        <div style="padding-bottom: 7px">
            Комментарии к статье:</div>
        <asp:Panel runat="server" ID="panComments">
            <asp:DataList ID="dlstComments" runat="server" DataSourceID="objComments" DataKeyField="ID"
                OnSelectedIndexChanged="dlstComments_SelectedIndexChanged" OnItemCommand="dlstComments_ItemCommand">
                <ItemTemplate>
                    <asp:Literal ID="lblAddedDate" runat="server" Text='<%# Eval("AddedDate", "{0:f}") + " " + Eval("AddedBy") %>' />
                    <div style="padding-left: 7px; text-align: justify">
                        <asp:Label ID="lblBody" runat="server" Text='<%# Eval("EncodedBody") %>' ForeColor="#777777" />
                    </div>
                    <asp:Panel runat="server" ID="panAdmin" Visible='<%# UserCanEdit %>'>
                        <asp:ImageButton runat="server" ID="btnSelect" CommandName="Select" CausesValidation="false"
                            AlternateText="Редактировать комментарий" ImageUrl="~/Images/Edit.gif" />
                        <asp:ImageButton runat="server" ID="btnDelete" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                            CausesValidation="false" AlternateText="Удалить комментарий" ImageUrl="~/Images/Delete.gif"
                            OnClientClick="if (confirm('Подтвердите удаление комментария') == false) return false;" />
                    </asp:Panel>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="objComments" runat="server" SelectMethod="GetComments"
                TypeName="UC.BLL.Articles.Comment">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="0" Name="articleID" QueryStringField="ID"
                        Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <br />
            <div style="padding-bottom: 7px">
                Ваш комментарий:</div>
            <asp:DetailsView SkinID="DetailsView" ID="dvwComment" runat="server" AutoGenerateInsertButton="false"
                AutoGenerateEditButton="false" AutoGenerateRows="False" DataSourceID="objCurrComment"
                DefaultMode="Insert" OnItemInserted="dvwComment_ItemInserted" OnItemCommand="dvwComment_ItemCommand"
                DataKeyNames="ID" OnItemUpdated="dvwComment_ItemUpdated" OnItemCreated="dvwComment_ItemCreated"
                BackColor="Transparent">
                <FieldHeaderStyle Width="107px" />
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="ID:" ReadOnly="True" InsertVisible="False" />
                    <asp:BoundField DataField="AddedDate" HeaderText="Дата добавления:" InsertVisible="False"
                        ReadOnly="True" />
                    <asp:BoundField DataField="AddedByIP" HeaderText="IP:" ReadOnly="True" InsertVisible="False" />
                    <asp:TemplateField HeaderText="<b style='color:red;'>*</b> Имя:">
                        <ItemTemplate>
                            <asp:Label ID="lblAddedBy" runat="server" Text='<%# Eval("AddedBy") %>' />
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtAddedBy" runat="server" Text='<%# Bind("AddedBy") %>' MaxLength="256"
                                Width="99%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRequireAddedBy" runat="server" ControlToValidate="txtAddedBy"
                                SetFocusOnError="true" Display="Dynamic">обязательно для заполнения</asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<b style='color:red;'>*</b> E-mail:">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkAddedByEmail" runat="server" Text='<%# Eval("AddedByEmail") %>'
                                NavigateUrl='<%# "mailto:" + Eval("AddedByEmail") %>' />
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtAddedByEmail" runat="server" Text='<%# Bind("AddedByEmail") %>'
                                MaxLength="256" Width="99%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRequireAddedByEmail" runat="server" ControlToValidate="txtAddedByEmail"
                                SetFocusOnError="true" Display="Dynamic">обязательно для заполнения</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="valEmailPattern" Display="Dynamic"
                                SetFocusOnError="true" ControlToValidate="txtAddedByEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">неправильный формат адреса электронной почты</asp:RegularExpressionValidator>
                        </InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<b style='color:red;'>*</b> Комментарий:">
                        <ItemTemplate>
                            <asp:Label ID="lblBody" runat="server" Text='<%# Eval("Body") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtBody" runat="server" Text='<%# Bind("Body") %>' TextMode="MultiLine"
                                Rows="5" Width="99%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valRequireBody" runat="server" ControlToValidate="txtBody"
                                SetFocusOnError="true" Display="Dynamic">обязательно для заполнения</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                        <EditItemTemplate>
                            <asp:Button ID="Button4" CommandName="Update" Text="Обновить" runat="Server" Font-Size="8pt"
                                Width="77px" />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <asp:Button ID="Button6" CommandName="Insert" Text="Добавить" runat="Server" Font-Size="8pt"
                                Width="77px" />
                        </InsertItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
            <asp:ObjectDataSource ID="objCurrComment" runat="server" InsertMethod="InsertComment"
                SelectMethod="GetCommentByID" TypeName="UC.BLL.Articles.Comment" UpdateMethod="UpdateComment">
                <UpdateParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="body" Type="String" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="dlstComments" Name="commentID" PropertyName="SelectedValue"
                        Type="Int32" />
                </SelectParameters>
                <InsertParameters>
                    <asp:Parameter Name="addedBy" Type="String" />
                    <asp:Parameter Name="addedByEmail" Type="String" />
                    <asp:QueryStringParameter Name="articleID" QueryStringField="ID" Type="Int32" />
                    <asp:Parameter Name="body" Type="String" />
                </InsertParameters>
            </asp:ObjectDataSource>
        </asp:Panel>--%>
        </asp:Panel>
    </div>
</asp:Content>
