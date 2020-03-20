<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OneClickOrderControl.ascx.cs" Inherits="UC.UI.Controls.OneClickOrderControl" %>
<%@ Register Src="~/Controls/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="mb" %>
<%@ Register Src="~/Controls/ShoppingCartLightControl.ascx" TagName="Cart" TagPrefix="mb" %>
<mb:BreadCrumb ID="BreadCrumb" runat="server" />
<div id="content">
    <asp:Panel ID="pnlEmptyCart" runat="server" Visible="false">
        <p style="color: #9aaab1">
            <b>Уважаемый покупатель!</b></p>
        <p>
            В настоящее время Ваша корзина пуста.</p>
        <p>
            Вы можете выбрать товар, воспользовавшись нашим
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">каталогом</asp:HyperLink>.</p>
        <p>
            Для наполнения корзины необходимо выбрать товар в
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/">каталоге</asp:HyperLink>,
            указать количество и нажать на кнопку "Купить".</p>
    </asp:Panel>
    <asp:Panel ID="pnlOrder" runat="server">
        <p style="color: #9aaab1; font-size: larger">
            <b>Корзина</b></p>
        <p>
            Вы можете изменить количество товаров в корзине, удалить товары или продолжить покупку.
            Если ваш заказ сформирован полностью, перейдите к оформлению заказа ниже.</p>
        <mb:Cart runat="server" ID="Cart" OnDeleteItem="EmptyCart"/>
        <p style="color: #9aaab1; font-size: larger">
            <b>Оформление заказа</b></p>
        <p>
            Заполните пожалуйста форму для оформления заказа. Поля, отмеченные <span style="color: Red">
                *</span>, обязательны для заполнения. После заполнения формы, нажмите на кнопку
            "Оформить заказ"</p>
        <table width="100%">
            <tr>
                <td style="width: 60%;">
                    <table width="100%">
                        <tr style="background-color: #f1f4f5">
                            <td class="fieldcaption" style="width: 130px">
                                <span style="color: Red;">*</span> ФИО получателя:
                            </td>
                            <td class="fieldtext">
                                <asp:TextBox runat="server" ID="txtFIO" Width="99%" TabIndex="1" />
                                <asp:RequiredFieldValidator ID="valRequireFIO" runat="server" ControlToValidate="txtFIO"
                                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Order">обязательно для заполнения</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldcaption">
                                <span style="color: Red;">*</span> Телефон:
                            </td>
                            <td class="fieldtext">
                                <asp:TextBox runat="server" ID="txtTelephone" Width="99%" TabIndex="2" />
                                <asp:RequiredFieldValidator ID="valRequireTelephone" runat="server" ControlToValidate="txtTelephone"
                                    SetFocusOnError="True" Display="Dynamic" ValidationGroup="Order">обязательно для заполнения</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="background-color: #f1f4f5">
                            <td class="fieldcaption">
                                <span style="color: Red;">*</span> E-mail:
                            </td>
                            <td class="fieldtext">
                                <asp:TextBox runat="server" ID="txtEmail" Width="99%" TabIndex="3" /><asp:RequiredFieldValidator
                                    ID="valRequireEmail" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True"
                                    Display="Dynamic" ValidationGroup="Order">обязательно для заполнения</asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        runat="server" ID="valEmailPattern" Display="Dynamic" SetFocusOnError="True"
                                        ValidationGroup="Register" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">ошибка в написании e-mail адреса</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldcaption">
                                Адрес доставки:
                            </td>
                            <td class="fieldtext">
                                <asp:TextBox runat="server" ID="txtAddress" Width="99%" TextMode="MultiLine" Rows="3"
                                    TabIndex="4" />
                            </td>
                        </tr>
                        <tr style="background-color: #f1f4f5">
                            <td class="fieldcaption">
                                Комментарий:
                            </td>
                            <td class="fieldtext">
                                <asp:TextBox runat="server" ID="txtComment" Width="99%" TextMode="MultiLine" Rows="5"
                                    TabIndex="5" />
                            </td>
                        </tr>
                        <tr>
                            <td class="fieldcaption">
                                Способ оплаты:
                            </td>
                            <td class="fieldtext">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:RadioButton runat="server" ID="rbtnCash" GroupName="Payment" Checked="true"
                                                TabIndex="6" />
                                        </td>
                                        <td class="fieldcaption">
                                            <asp:Label ID="Label1" runat="server" AssociatedControlID="rbtnCash">
                                            <strong>Оплата наличными</strong>
                                            <br/>
                                            Вы оплачиваете товар наличными при доставке. Оплата производится только в рублях.
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton runat="server" ID="rbtnCard" GroupName="Payment" TabIndex="7" />
                                        </td>
                                        <td class="fieldcaption">
                                            <asp:Label ID="Label4" runat="server" AssociatedControlID="rbtnCard">
                                            <strong>Оплата картой</strong>
                                            <br/>
                                            Вы оплачиваете товар банковской картой Visa или Mastercard. Без комиссии.
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton runat="server" ID="rbtnTranslation" GroupName="Payment" TabIndex="8" />
                                        </td>
                                        <td class="fieldcaption">
                                            <asp:Label ID="Label2" runat="server" AssociatedControlID="rbtnTranslation">
                                            <strong>Банковский перевод</strong>
                                            <br/>
                                            Вам на e-mail или факс (по желанию) высылается квитанция для оплаты. В поле "Назначение платежа" следует указать номер вашего заказа. Например, "Заказ № DP-0237".
                                            </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton runat="server" ID="rbtnWire" GroupName="Payment" TabIndex="9" />
                                        </td>
                                        <td class="fieldcaption">
                                            <asp:Label ID="Label3" runat="server" AssociatedControlID="rbtnWire">
                                            <strong>Безналичный расчет</strong>
                                            (только для юридических лиц)
                                            <br/>
                                            Для оплаты товара по безналичному расчету юридическим лицам после поступления заказа высылается счет.
                                            </asp:Label>
                                        </td>
                                    </tr>
<%--                                    <tr>
                                        <td>
                                            <asp:RadioButton runat="server" ID="rbtnPOD" GroupName="Payment" TabIndex="10" />
                                        </td>
                                        <td class="fieldcaption">
                                            <asp:Label ID="Label5" runat="server" AssociatedControlID="rbtnPOD">
                                            <strong>Наложенный платеж</strong>
                                            <br/>
                                            Вы оплачиваете товар в отделении Почты России по указанному адресу. Доступно при доставке Почтой России.
                                            </asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40%; padding: 0px;">
                    <table width="100%">
                        <tr style="background-color: #f1f4f5">
                            <td valign="middle" style="padding: 6px 10px; border: solid 1px white;">
                                Как Вы нас нашли?<br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 17px;">
                                <asp:RadioButtonList runat="server" ID="optlOptions" DataTextField="OptionText" DataValueField="ID">
                                    <asp:ListItem>От друзей или знакомых</asp:ListItem>
                                    <asp:ListItem>Яндекс Маркет</asp:ListItem>
                                    <asp:ListItem>Товары Mail.ru</asp:ListItem>
                                    <asp:ListItem>Price.ru</asp:ListItem>
                                    <asp:ListItem>Через поисковый сервер Яндекс</asp:ListItem>
                                    <asp:ListItem>Через поисковый сервер Google</asp:ListItem>
                                    <asp:ListItem>Через поисковый сервер Rambler</asp:ListItem>
                                    <asp:ListItem>Через другой поисковый сервер</asp:ListItem>
                                    <asp:ListItem>Реклама на одном из сайтов</asp:ListItem>
                                    <asp:ListItem>По электронной почте</asp:ListItem>
                                    <asp:ListItem>Рекламный листок</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox runat="server" ID="chkNews" Checked="true" Text="Получать информацию об изменении цен, спецпредложениях и новостях" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="ErrorMessage" SkinID="FeedbackKO" runat="server" EnableViewState="False"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="padding: 7px 0px 7px 0px">
            <asp:ImageButton ID="btnReserve" runat="server" OnClick="btnReserve_Click" SkinID="Reserve"
                EnableViewState="false" ValidationGroup="Order" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAdopt" runat="server" Visible="false">
        <p style="font-weight: bold; color: #9aaab1; font-size: 14px">
            Заказ принят</p>
        <asp:Label runat="server" ID="lblAdopt" />
    </asp:Panel>
</div>
