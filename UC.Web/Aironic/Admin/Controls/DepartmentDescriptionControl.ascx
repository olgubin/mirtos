<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepartmentDescriptionControl.ascx.cs" Inherits="UC.UI.Admin.Controls.DepartmentDescriptionControl" %>
<%@ Register Src="~/Controls/FileUploader.ascx" TagName="FileUploader" TagPrefix="mb" %>
<%@ Register Src="~/Admin/Controls/SelectDepartmentControl.ascx" TagName="SelectDepartmentControl" TagPrefix="mb"%>
<%@ Register Src="~/Admin/Controls/SelectDepartmentTemplateControl.ascx" TagName="SelectDepartmentTemplateControl" TagPrefix="mb"%>

<asp:DetailsView ID="dvwDepartment" runat="server" AutoGenerateRows="False" DataSourceID="objCurrDepartment"
    Height="50px" Width="50%" HeaderText="Описание раздела" OnItemInserted="dvwDepartment_ItemInserted" OnItemUpdated="dvwDepartment_ItemUpdated"
    DataKeyNames="DepartmentID" OnItemCreated="dvwDepartment_ItemCreated" DefaultMode="Insert"
    OnItemCommand="dvwDepartment_ItemCommand" OnItemDeleted="dvwDepartment_ItemDeleted">
    <FieldHeaderStyle Width="100px" />
    <Fields>
        <asp:BoundField DataField="DepartmentID" HeaderText="ID" ReadOnly="True" SortExpression="DepartmentID"
            InsertVisible="False"/>
        <asp:BoundField DataField="AddedDate" HeaderText="Дата добавления" InsertVisible="False"
            ReadOnly="True" SortExpression="AddedDate"/>
        <asp:BoundField DataField="AddedBy" HeaderText="Добавил" InsertVisible="False" ReadOnly="True"
            SortExpression="AddedBy" meta:resourcekey="BoundFieldResource3" />
        <asp:CheckBoxField DataField="Published" HeaderText="Отображать" />
        <asp:TemplateField headertext="Родительский раздел:" convertemptystringtonull="true" SortExpression="ParentDepartmentID">
            <ItemTemplate>
                <%# Eval("ParentDepartmentID")%>
            </ItemTemplate>
            <EditItemTemplate>
                <mb:SelectDepartmentControl ID="ParentDepartment" runat="server" SelectedDepartmentId='<%# Bind("ParentDepartmentID") %>'></mb:SelectDepartmentControl>
            </EditItemTemplate>
            <InsertItemTemplate>
                <mb:SelectDepartmentControl ID="ParentDepartment" runat="server" SelectedDepartmentId='<%# Bind("ParentDepartmentID") %>'></mb:SelectDepartmentControl>
            </InsertItemTemplate>
        </asp:TemplateField>                
        <asp:TemplateField HeaderText="Название" SortExpression="Name">
            <ItemTemplate>
                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Name") %>' MaxLength="256" Width="100%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireTitle" runat="server" ControlToValidate="txtTitle"
                    SetFocusOnError="True" Text="The Title field is required." ToolTip="Обязательно для заполнения."
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Порядок" SortExpression="DisplayOrder">
            <ItemTemplate>
                <asp:Label ID="lblDisplayOrder" runat="server" Text='<%# Eval("DisplayOrder") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%# Bind("DisplayOrder") %>' MaxLength="256"
                    Width="100%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valRequireImportance" runat="server" ControlToValidate="txtDisplayOrder"
                    SetFocusOnError="True" Text="Обязательно для заполнения." ToolTip="Обязательно для заполнения."
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="valImportanceType" runat="server" Operator="DataTypeCheck"
                    Type="Integer" ControlToValidate="txtDisplayOrder" Text="Порядок отображения должен быть целым числом."
                    ToolTip="Порядок отображения должен быть целым числом." Display="Dynamic"/>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Изображение" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Image ID="imgImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' AlternateText='<%# Eval("Name") %>'
                    Visible='<%# !string.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "ImageUrl").ToString()) %>'/>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtImageUrl" runat="server" Text='<%# Bind("ImageUrl") %>' MaxLength="256" Width="100%"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Описание" SortExpression="Description" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' Rows="5" TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
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
        <asp:TemplateField HeaderText="Meta Keywords" SortExpression="MetaKeywords" ConvertEmptyStringToNull="False">
            <ItemTemplate>
                <asp:Label ID="lblKeywords" runat="server" Text='<%# Eval("MetaKeywords") %>' Width="100%"></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtKeywords" runat="server" Text='<%# Bind("MetaKeywords") %>' Rows="5"
                    TextMode="MultiLine" MaxLength="4000" Width="100%"></asp:TextBox>
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
        <asp:TemplateField headertext="Шаблон раздела:" convertemptystringtonull="true" SortExpression="DepartmentTemplateID">
            <ItemTemplate>
                <%# Eval("TemplateID")%>
            </ItemTemplate>
            <EditItemTemplate>
                <mb:SelectDepartmentTemplateControl ID="ddlDepartmentTemplate" runat="server" SelectedDepartmentTemplateId='<%# Bind("TemplateID") %>'></mb:SelectDepartmentTemplateControl>
            </EditItemTemplate>
            <InsertItemTemplate>
                <mb:SelectDepartmentTemplateControl ID="ddlDepartmentTemplate" runat="server" SelectedDepartmentTemplateId='<%# Bind("TemplateID") %>'></mb:SelectDepartmentTemplateControl>
            </InsertItemTemplate>
        </asp:TemplateField>                      
        <asp:TemplateField ItemStyle-HorizontalAlign="Right" ItemStyle-BackColor="White" HeaderStyle-BackColor="White">
            <InsertItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" SkinID="Insert" CommandName="Insert"/>&nbsp
            </InsertItemTemplate>
            <EditItemTemplate>
                <asp:ImageButton ID="ImageButton4" runat="server" SkinID="Delete" CommandName="Delete"/>&nbsp
                <asp:ImageButton ID="ImageButton2" runat="server" SkinID="Update" CommandName="Update"/>&nbsp
                <asp:ImageButton ID="ImageButton3" runat="server" SkinID="Cancel" CommandName="Cancel"/>&nbsp
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>        
<p style="text-align:left">
<mb:FileUploader ID="FileUploader1" runat="server" />        
<p/>        
<asp:ObjectDataSource ID="objCurrDepartment" runat="server" InsertMethod="InsertDepartment"
    SelectMethod="GetByDepartmentID" TypeName="UC.BLL.Store.DepartmentManager"
    UpdateMethod="UpdateDepartment" DeleteMethod="DeleteDepartment">
    <SelectParameters>
        <asp:ControlParameter ControlID="tvwDepartments" Name="departmentID" PropertyName="SelectedValue" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>  