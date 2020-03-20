<%@ Page Language="C#" MasterPageFile="Admin.master" ValidateRequest="false" AutoEventWireup="true"
    CodeFile="ManageManufacturers.aspx.cs" Inherits="UC.UI.Admin.ManageManufacturers"
    Culture="auto" UICulture="auto" MaintainScrollPositionOnPostback="false" %>

<%@ Register Src="~/Admin/Controls/ManufacturerDescriptionControl.ascx" TagName="ManufacturerDescriptionControl"
    TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/ManufacturerFiltersControl.ascx" TagName="ManufacturerFiltersControl"
    TagPrefix="mb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                        ������� �������/��������������</h1>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
        <p>
        </p>
        <asp:UpdatePanel ID="updpnlManageDepartment" runat="server">
            <ContentTemplate>
                <table width="100%" cellpadding="5px">
                    <tr>
                        <td style="width:300px">
                            <asp:GridView ID="gvwManufacturers" runat="server" AutoGenerateColumns="False" DataSourceID="objAllManufacturers"
                                Width="100%" DataKeyNames="ManufacturerID" OnRowCreated="gvwManufacturers_RowCreated" ShowHeader="true"
                                OnSelectedIndexChanged="gvwManufacturers_SelectedIndexChanged" OnRowCommand="gvwManufacturers_RowCommand">
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="Visible">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                    </asp:ButtonField>                                  
                                    <asp:TemplateField HeaderText="�����/�������������">
                                        <ItemTemplate>
                                            <%# Eval("Title") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DisplayOrder" HeaderText="���." ItemStyle-Width="30px" />
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="�������������" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                    </asp:CommandField>                                    
                                </Columns>
                                <EmptyDataTemplate>
                                    <b>������� ����</b></EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="objAllManufacturers" runat="server" SelectMethod="GetManufacturers"
                                TypeName="UC.BLL.Store.ManufacturerManager" DeleteMethod="DeleteManufacturer">
                            </asp:ObjectDataSource>
                        </td>
                        <td>
                            <ajaxToolkit:TabContainer runat="server" ID="ManufacturerTabs" ActiveTabIndex="0"
                                Width="100%">
                                <ajaxToolkit:TabPanel runat="server" ID="pnlManufacturerDescription" HeaderText="��������"
                                    Width="100%">
                                    <ContentTemplate>
                                        <mb:ManufacturerDescriptionControl ID="ManufacturerDescription" runat="server" OnItemInserted="UpdateTree"
                                            OnItemUpdated="UpdateTree" OnItemDeleted="UpdateTree" OnItemCancel="UpdateTree" />
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel runat="server" ID="pnlManufacturerFilter" HeaderText="�������"
                                    Width="100%">
                                    <ContentTemplate>
                                        <mb:ManufacturerFiltersControl ID="ManufacturerFiltersControl" runat="server" />
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                            </ajaxToolkit:TabContainer>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        <%--        <asp:DetailsView ID="dvwManufacturer" runat="server" AutoGenerateRows="False" DataSourceID="objCurrManufacturer"
            Height="50px" Width="50%" HeaderText="�����/�������������" OnItemInserted="dvwManufacturer_ItemInserted" OnItemUpdated="dvwManufacturer_ItemUpdated"
            DataKeyNames="ManufacturerID" OnItemCreated="dvwManufacturer_ItemCreated" DefaultMode="Insert"
            OnItemCommand="dvwManufacturer_ItemCommand">
            <FieldHeaderStyle Width="170px" />
            <Fields>
                <asp:BoundField DataField="ManufacturerID" HeaderText="ID" ReadOnly="True" SortExpression="ManufacturerID" InsertVisible="False"/>
                <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" InsertVisible="False" ReadOnly="True" SortExpression="AddedDate"/>
                <asp:BoundField DataField="AddedBy" HeaderText="AddedBy" InsertVisible="False" ReadOnly="True" SortExpression="AddedBy"/>
                <asp:CheckBoxField DataField="Published" HeaderText="����������" />
                <asp:TemplateField HeaderText="�����/�������������" SortExpression="Title">
                    <ItemTemplate>
                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' MaxLength="256"
                            Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                            SetFocusOnError="True" Text="����������� ��� ����������." ToolTip="����������� ��� ����������."
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��������" SortExpression="Description" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' Width="100%"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>'
                            Rows="5" TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���� �������������" SortExpression="Url" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Label ID="lblUrl" runat="server" Text='<%# Eval("Url") %>' Width="100%"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUrl" runat="server" Text='<%# Bind("Url") %>' Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="�������" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Image ID="imgImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText='<%# Eval("Title") %>'
                            Visible='<%# !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageUrl").ToString()) %>'/>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>' MaxLength="256" Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>                                
                <asp:TemplateField HeaderText="������" SortExpression="Importance">
                    <ItemTemplate>
                        <asp:Label ID="lblArticle" runat="server" Text='<%# Eval("ArticleID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="ddlArticles" DataSourceID="objArticles" AutoPostBack="False" DataTextField="Title" 
                            DataValueField="ID" AppendDataBoundItems="True" SelectedValue='<%# Bind("ArticleID") %>'>
                         <asp:ListItem Text="" Value="0"/>
                     </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="�������" SortExpression="DisplayOrder">
                    <ItemTemplate>
                        <asp:Label ID="lblImportance" runat="server" Text='<%# Eval("DisplayOrder") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtImportance" runat="server" Text='<%# Bind("DisplayOrder") %>' MaxLength="256" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valRequireImportance" runat="server" ControlToValidate="txtImportance"
                            SetFocusOnError="True" Text="����������� ��� ����������." ToolTip="����������� ��� ����������." Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="valImportanceType" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtImportance" Text="�������� ������ ���� ����� ������."
                            ToolTip="�������� ������ ���� ����� ������." Display="Dynamic"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Meta Title" SortExpression="MetaTitle" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Label ID="lblMetaTitle" runat="server" Text='<%# Eval("MetaTitle") %>' Width="100%"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMetaTitle" runat="server" Text='<%# Bind("MetaTitle") %>' MaxLength="400" Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Meta Description" SortExpression="MetaDescription" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Label ID="lblMetaDescription" runat="server" Text='<%# Eval("MetaDescription") %>' Width="100%"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMetaDescription" runat="server" Text='<%# Bind("MetaDescription") %>' Rows="5"
                            TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Meta Keywords" SortExpression="MetaKeywords" ConvertEmptyStringToNull="False">
                    <ItemTemplate>
                        <asp:Label ID="lblKeywords" runat="server" Text='<%# Eval("MetaKeywords") %>' Width="100%"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtKeywords" runat="server" Text='<%# Bind("MetaKeywords") %>' Rows="5"
                            TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White" HeaderStyle-BackColor="White">
                    <InsertItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert"/>&nbsp
                    </InsertItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update"/>&nbsp
                        <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel"/>&nbsp
                    </EditItemTemplate>
                </asp:TemplateField>                
            </Fields>
        </asp:DetailsView>
        <table style="width: 100%">
            <tr>
                <td style="height:27px;vertical-align:middle;">������ �� ����������� �������:</td>
                <td colspan="2" style="height:27px;vertical-align:middle">
                    <asp:Literal runat="server" ID="lblImgUrl" />
                </td>
            </tr>           
            <tr>
                <td style="width: 230px; vertical-align: middle;">
                    ��������� ����������� �� �����:</td>
                <td>
                    <asp:FileUpload ID="imgUpload" runat="server" Width="100%" EnableViewState="false"/>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnFileUpload" Text="���������" OnClick="btnFileUpload_Click" CausesValidation="false"/>
                </td>
            </tr>
        </table>        
        <p/>
        <asp:GridView ID="gvwManufacturers" runat="server" AutoGenerateColumns="False" DataSourceID="objAllManufacturers"
            Width="100%" DataKeyNames="ManufacturerID" OnRowDeleted="gvwManufacturers_RowDeleted" OnRowCreated="gvwManufacturers_RowCreated"
            OnRowCommand="gvwManufacturers_RowCommand" OnSelectedIndexChanged="gvwManufacturers_SelectedIndexChanged" ShowHeader="false">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="departmentimage">
                            <asp:Image ID="imgLogo" runat="server" GenerateEmptyAlternateText="true" ImageUrl='<%# Eval("ImageUrl") %>'
                                ImageAlign="AbsMiddle" Visible='<%# !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageUrl").ToString()) %>' />
                        </div>
                    </ItemTemplate>
                    <ItemStyle Width="89px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="sectionsubtitle">
                            <span><%# Eval("Title") %></span>
                        </div>
                        ���� �������������: <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Url") %>'><%# Eval("Url") %></asp:HyperLink>
                        <br />
                        ������ � �������������: <asp:HyperLink runat="server" NavigateUrl='<%# "../Article.aspx?ID=" + Eval("ArticleID") %>'><%# Eval("Article.Title") %></asp:HyperLink>
                        <br/><br/><%# Eval("Description") %><br/><br/>
                        <span style="color: #AAAAAA;"><%# Eval("MetaKeywords") %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate><b>���. <%# Eval("DisplayOrder")%></b></ItemTemplate>
                <ItemStyle Width="77px" HorizontalAlign="right"/>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Image" CommandName="Visible">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:ButtonField>                
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Edit.gif" SelectText="�������������" ShowSelectButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Delete.gif" DeleteText="�������" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                </asp:CommandField>
            </Columns>
            <EmptyDataTemplate><b>������� ����</b></EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource ID="objAllManufacturers" runat="server" SelectMethod="GetManufacturers"
            TypeName="UC.BLL.Store.ManufacturerManager" DeleteMethod="DeleteManufacturer">
        </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="objCurrManufacturer" runat="server" InsertMethod="InsertManufacturer"
            SelectMethod="GetManufacturerByID" TypeName="UC.BLL.Store.ManufacturerManager"
            UpdateMethod="UpdateManufacturer">
            <SelectParameters>
                <asp:ControlParameter ControlID="gvwManufacturers" Name="manufacturerID" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        
        <asp:ObjectDataSource ID="objArticles" runat="server" SelectMethod="GetArticles"
            TypeName="UC.BLL.Articles.Article">
             <SelectParameters>
                 <asp:Parameter Name="publishedOnly" DefaultValue="true" Type="Boolean" />
             </SelectParameters>   
        </asp:ObjectDataSource>  --%>
    </div>
</asp:Content>
