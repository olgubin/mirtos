<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageCurrency.aspx.cs" Inherits="UC.UI.Admin.ManageCurrency" Culture="auto"
    UICulture="auto" %>

<%@ Register Src="~/Admin/Controls/NumericTextBox.ascx" TagName="NumericTextBox"
    TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/DecimalTextBox.ascx" TagName="DecimalTextBox"
    TagPrefix="mb" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">�������</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" SkinID="Separator" />
                </td>
                <td class="h1">
                    <a href="Default.aspx">�����������������</a>
                </td>
                <td>
                    <asp:Image ID="Image2" runat="server" SkinID="Separator" />
                </td>
                <td>
                    <h1>
                        ���������� ��������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <asp:UpdatePanel runat="server" ID="pnlUpdate">
            <ContentTemplate>
                <asp:DetailsView ID="dvwCurrency" runat="server" AutoGenerateRows="False" DataSourceID="objCurrency"
                    Height="50px" Width="50%" HeaderText="������" OnItemInserted="dvwCurrency_ItemInserted"
                    OnItemUpdated="dvwCurrency_ItemUpdated" OnItemCommand="dvwCurrency_ItemCommand"
                    DataKeyNames="CurrencyID" DefaultMode="Insert">
                    <FieldHeaderStyle Width="170px" />
                    <Fields>
                        <asp:BoundField DataField="CurrencyID" HeaderText="ID" ReadOnly="True" SortExpression="CurrencyID"
                            InsertVisible="False" />
                        <asp:TemplateField HeaderText="������" SortExpression="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' MaxLength="256"
                                    Width="99%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireName" runat="server" ControlToValidate="txtName"
                                    SetFocusOnError="True" Text="����������� ��� ����������." ToolTip="����������� ��� ����������."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���" SortExpression="CurrencyCode">
                            <ItemTemplate>
                                <asp:Label ID="lblCurrencyCode" runat="server" Text='<%# Eval("CurrencyCode") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCurrencyCode" runat="server" Text='<%# Bind("CurrencyCode") %>'
                                    MaxLength="5" Width="99%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valRequireCurrencyCode" runat="server" ControlToValidate="txtCurrencyCode"
                                    SetFocusOnError="True" Text="����������� ��� ����������." ToolTip="����������� ��� ����������."
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����" SortExpression="Rate">
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <mb:DecimalTextBox runat="server" ID="txtRate" Value='<%# Bind("Rate") %>' CssClass="adminInput"
                                    RequiredErrorMessage="������� ����������� ����������� ��� ����������" MinimumValue="0"
                                    MaximumValue="999999" RangeErrorMessage="�������� ������ ���� � ��������� �� -0 �� 99999">
                                </mb:DecimalTextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:CheckBoxField DataField="Published" HeaderText="����������" />
                        <asp:TemplateField HeaderText="������� �����������">
                            <ItemTemplate>
                                <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder") %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <mb:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtDisplayOrder"
                                    Value='<%# Bind("DisplayOrder") %>' RequiredErrorMessage="������� ����������� ����������� ��� ����������"
                                    RangeErrorMessage="�������� ������ ���� � ��������� �� -99999 �� 99999" MinimumValue="-99999"
                                    MaximumValue="99999"></mb:NumericTextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White"
                            HeaderStyle-BackColor="White">
                            <InsertItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert" />&nbsp
                            </InsertItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update" />&nbsp
                                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel" />&nbsp
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Fields>
                </asp:DetailsView>
                <p />
                <asp:GridView ID="gvwCurrencies" runat="server" AutoGenerateColumns="False" DataSourceID="objCurrencies"
                    Width="100%" DataKeyNames="CurrencyID" OnRowDeleted="gvwCurrencies_RowDeleted"
                    OnRowCreated="gvwCurrencies_RowCreated" OnSelectedIndexChanged="gvwCurrencies_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="�������� ������" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:RadioButton runat="server" ID="rdbIsPrimaryCurrency" Checked='<%#Eval("IsPrimaryCurrency")%>'
                                    OnCheckedChanged="rdbIsPrimaryCurrency_CheckedChanged" AutoPostBack="true" />
                                <asp:HiddenField runat="server" ID="hfCurrencyID" Value='<%#Eval("CurrencyID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="��������" SortExpression="Name" />
                        <asp:BoundField DataField="CurrencyCode" HeaderText="���" SortExpression="CurrencyCode" />
                        <asp:BoundField DataField="Rate" HeaderText="����" SortExpression="Rate" />
                        <asp:CheckBoxField DataField="Published" HeaderText="����������" SortExpression="Published" />
                        <asp:BoundField DataField="DisplayOrder" HeaderText="�������" SortExpression="DisplayOrder" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="�������������"
                            ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="�������"
                            ShowDeleteButton="True">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                        </asp:CommandField>
                    </Columns>
                    <EmptyDataTemplate>
                        <b>������� ����</b></EmptyDataTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:GridView>
                <asp:ObjectDataSource ID="objCurrencies" runat="server" SelectMethod="GetCurrencies"
                    TypeName="UC.BLL.Store.CurrencyManager" DeleteMethod="DeleteCurrency"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="objCurrency" runat="server" InsertMethod="InsertCurrency"
                    SelectMethod="GetByCurrencyID" TypeName="UC.BLL.Store.CurrencyManager" UpdateMethod="UpdateCurrency">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="gvwCurrencies" Name="CurrencyID" PropertyName="SelectedValue"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
