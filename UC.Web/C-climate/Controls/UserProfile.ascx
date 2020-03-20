<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserProfile.ascx.cs" Inherits="UC.UI.Controls.UserProfile" %>
<asp:Panel runat="server" DefaultButton="btnUpdate">
<table width="100%">
    <tr style="background-color: #f1f4f5">
        <td class="fieldcaption" style="width: 127px;">
            <span style="color: Red;">*</span> Фамилия:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtLastName" Width="99%" />
            <asp:RequiredFieldValidator ID="valRequireLastName" runat="server" ControlToValidate="txtLastName"
                SetFocusOnError="True" Display="Dynamic" ValidationGroup="EditProfile">обязательно для заполнения</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="fieldcaption">
            <span style="color: Red;">*</span> Имя:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtFirstName" Width="99%" />
            <asp:RequiredFieldValidator ID="valRequireFirstName" runat="server" ControlToValidate="txtFirstName"
                SetFocusOnError="True" Display="Dynamic" ValidationGroup="EditProfile">обязательно для заполнения</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr style="background-color: #f1f4f5">
        <td class="fieldcaption">
            Отчество:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtMiddleName" Width="99%" />
        </td>
    </tr>
    <tr>
        <td class="fieldcaption">
            <span style="color: Red;">*</span> E-mail:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtEmail" Width="99%" />
            <asp:RequiredFieldValidator ID="valRequireEmail" runat="server" ControlToValidate="txtEmail"
                SetFocusOnError="True" Display="Dynamic" ValidationGroup="EditProfile">обязательно для заполнения</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator runat="server" ID="valEmailPattern" Display="Dynamic"
                SetFocusOnError="True" ValidationGroup="EditProfile" ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">ошибка в написании e-mail адреса</asp:RegularExpressionValidator>
        </td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td style="width:27px;text-align:center">
            <asp:CheckBox runat="server" ID="chkNews" Checked="true"/>
        </td>
        <td style="text-align:justify">Получать информацию об изменении цен, специальных предложениях и новостях</td>
    </tr>    
    <tr>
        <td colspan="2" style="height:37px;vertical-align:middle">
                <asp:ImageButton ID="btnUpdate" ValidationGroup="EditProfile" runat="server" AlternateText="Сохранить" ImageUrl="~/App_Themes/Diktophone/images/save.gif" OnClick="btnUpdate_Click" />                        
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="ErrorMessage" SkinID="FeedbackKO" runat="server" EnableViewState="False"></asp:Label>
        </td>
    </tr>          
    <tr>
        <td colspan="2">
            <asp:Label runat="server" ID="lblFeedbackOK" SkinID="FeedbackOK" Text="Изменения сохранены. На, указанный Вами, E-mail отправлено письмо с новыми данными." Visible="False" EnableViewState="false"/>
        </td>
    </tr>
</table>  
</asp:Panel>

<%--<div class="sectionsubtitle">
<asp:Literal runat="server" Text="<%$ resources:Sitepreferences %>" />
</div>
<p></p>
<table cellpadding="2">
   <tr>
      <td style="width: 110px;" class="fieldname"><asp:Label runat="server" ID="lblNewsletter" AssociatedControlID="ddlSubscriptions" Text="Newsletter:" meta:resourcekey="lblNewsletterResource1" /></td>
      <td style="width: 400px;">
         <asp:DropDownList runat="server" ID="ddlSubscriptions" meta:resourcekey="ddlSubscriptionsResource1">
            <asp:ListItem Text="No subscription" Value="None" Selected="True" meta:resourcekey="ListItemResource1" />
            <asp:ListItem Text="Subscribe to plain-text version" Value="PlainText" meta:resourcekey="ListItemResource2" />
            <asp:ListItem Text="Subscribe to HTML version" Value="Html" meta:resourcekey="ListItemResource3" />
         </asp:DropDownList>
      </td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblLanguage" AssociatedControlID="ddlLanguages" Text="Language:" meta:resourcekey="lblLanguageResource1" /></td>
      <td>
         <asp:DropDownList runat="server" ID="ddlLanguages" meta:resourcekey="ddlLanguagesResource1">
            <asp:ListItem Text="Русский" Value="ru-RU" Selected="True" meta:resourcekey="ListItemResource4" />
            <asp:ListItem Text="English" Value="en-US" meta:resourcekey="ListItemResource5" />
         </asp:DropDownList>
      </td>
   </tr>
</table>
<p></p>
<div class="sectionsubtitle">
<asp:Literal ID="Literal1" runat="server" Text="<%$ resources:Foruminformation %>" />
</div>
<p></p>
<table cellpadding="2">
   <tr>
      <td style="width: 110px;" class="fieldname"><asp:Label runat="server" ID="lblAvatarUrl" AssociatedControlID="txtAvatarUrl" Text="Avatar Url:" meta:resourcekey="lblAvatarUrlResource1" /></td>
      <td style="width: 400px;"><asp:TextBox runat="server" ID="txtAvatarUrl" Width="99%" meta:resourcekey="txtAvatarUrlResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblSignature" AssociatedControlID="txtSignature" Text="Signature:" meta:resourcekey="lblSignatureResource1" /></td>
      <td><asp:TextBox runat="server" ID="txtSignature" Width="99%" MaxLength="500" TextMode="MultiLine" Rows="4" meta:resourcekey="txtSignatureResource1" /></td>
   </tr>
</table>
<p></p>
<div class="sectionsubtitle">
<asp:Literal ID="Literal2" runat="server" Text="<%$ resources:Personaldetails %>" />
</div>
<p></p>
<table cellpadding="2">
   <tr>
      <td style="width: 110px;" class="fieldname"><asp:Label runat="server" ID="lblFirstName" AssociatedControlID="txtFirstName" Text="First name:" meta:resourcekey="lblFirstNameResource1" /></td>
      <td style="width: 400px;"><asp:TextBox ID="txtFirstName" runat="server" Width="99%" meta:resourcekey="txtFirstNameResource1"></asp:TextBox></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblLastName" AssociatedControlID="txtLastName" Text="Last name:" meta:resourcekey="lblLastNameResource1" /></td>
      <td><asp:TextBox ID="txtLastName" runat="server" Width="99%" meta:resourcekey="txtLastNameResource1"></asp:TextBox></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblGender" AssociatedControlID="ddlGenders" Text="Gender:" meta:resourcekey="lblGenderResource1" /></td>
      <td>
         <asp:DropDownList runat="server" ID="ddlGenders" meta:resourcekey="ddlGendersResource1">
            <asp:ListItem Text="Please select one..." Selected="True" meta:resourcekey="ListItemResource6" />
            <asp:ListItem Text="Male" Value="M" meta:resourcekey="ListItemResource7" />
            <asp:ListItem Text="Female" Value="F" meta:resourcekey="ListItemResource8" />
         </asp:DropDownList>
      </td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblBirthDate" AssociatedControlID="txtBirthDate" Text="Birth date:" meta:resourcekey="lblBirthDateResource1" /></td>
      <td>
         <asp:TextBox ID="txtBirthDate" runat="server" Width="99%" meta:resourcekey="txtBirthDateResource1"></asp:TextBox>
         <asp:CompareValidator runat="server" ID="valBirthDateType" ControlToValidate="txtBirthDate"
            SetFocusOnError="True" Display="Dynamic" Operator="DataTypeCheck" Type="Date"
            ErrorMessage="The format of the birth date is not valid." ToolTip="The format of the birth date is not valid."
            ValidationGroup="EditProfile" meta:resourcekey="valBirthDateTypeResource1"><br />The format of the birth date is not valid.</asp:CompareValidator>
      </td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblOccupation" AssociatedControlID="ddlOccupations" Text="Occupation:" meta:resourcekey="lblOccupationResource1" /></td>
      <td>
         <asp:DropDownList ID="ddlOccupations" runat="server" Width="99%" meta:resourcekey="ddlOccupationsResource1">
            <asp:ListItem Text="Please select one..." Selected="True" meta:resourcekey="ListItemResource9" />
            <asp:ListItem Text="Academic" meta:resourcekey="ListItemResource10" />
            <asp:ListItem Text="Accountant" meta:resourcekey="ListItemResource11" />
            <asp:ListItem Text="Actor" meta:resourcekey="ListItemResource12" />
            <asp:ListItem Text="Architect" meta:resourcekey="ListItemResource13" />
            <asp:ListItem Text="Artist" meta:resourcekey="ListItemResource14" />
            <asp:ListItem Text="Business Manager" meta:resourcekey="ListItemResource15" />
            <asp:ListItem Text="Carpenter" meta:resourcekey="ListItemResource16" />
            <asp:ListItem Text="Chief Executive" meta:resourcekey="ListItemResource17" />
            <asp:ListItem Text="Cinematographer" meta:resourcekey="ListItemResource18" />
            <asp:ListItem Text="Civil Servant" meta:resourcekey="ListItemResource19" />
            <asp:ListItem Text="Coach" meta:resourcekey="ListItemResource20" />
            <asp:ListItem Text="Composer" meta:resourcekey="ListItemResource21" />
            <asp:ListItem Text="Computer programmer" meta:resourcekey="ListItemResource22" />
            <asp:ListItem Text="Cook" meta:resourcekey="ListItemResource23" />
            <asp:ListItem Text="Counsellor" meta:resourcekey="ListItemResource24" />
            <asp:ListItem Text="Doctor" meta:resourcekey="ListItemResource25" />
            <asp:ListItem Text="Driver" meta:resourcekey="ListItemResource26" />
            <asp:ListItem Text="Economist" meta:resourcekey="ListItemResource27" />
            <asp:ListItem Text="Editor" meta:resourcekey="ListItemResource28" />
            <asp:ListItem Text="Electrician" meta:resourcekey="ListItemResource29" />
            <asp:ListItem Text="Engineer" meta:resourcekey="ListItemResource30" />
            <asp:ListItem Text="Executive Producer" meta:resourcekey="ListItemResource31" />
            <asp:ListItem Text="Fixer" meta:resourcekey="ListItemResource32" />
            <asp:ListItem Text="Graphic Designer" meta:resourcekey="ListItemResource33" />
            <asp:ListItem Text="Hairdresser" meta:resourcekey="ListItemResource34" />
            <asp:ListItem Text="Headhunter" meta:resourcekey="ListItemResource35" />
            <asp:ListItem Text="HR - Recruitment" meta:resourcekey="ListItemResource36" />
            <asp:ListItem Text="Information Officer" meta:resourcekey="ListItemResource37" />
            <asp:ListItem Text="IT Consultant" meta:resourcekey="ListItemResource38" />
            <asp:ListItem Text="Journalist" meta:resourcekey="ListItemResource39" />
            <asp:ListItem Text="Lawyer / Solicitor" meta:resourcekey="ListItemResource40" />
            <asp:ListItem Text="Lecturer" meta:resourcekey="ListItemResource41" />
            <asp:ListItem Text="Librarian" meta:resourcekey="ListItemResource42" />
            <asp:ListItem Text="Mechanic" meta:resourcekey="ListItemResource43" />
            <asp:ListItem Text="Model" meta:resourcekey="ListItemResource44" />
            <asp:ListItem Text="Musician" meta:resourcekey="ListItemResource45" />
            <asp:ListItem Text="Office Worker" meta:resourcekey="ListItemResource46" />
            <asp:ListItem Text="Performer" meta:resourcekey="ListItemResource47" />
            <asp:ListItem Text="Photographer" meta:resourcekey="ListItemResource48" />
            <asp:ListItem Text="Presenter" meta:resourcekey="ListItemResource49" />
            <asp:ListItem Text="Producer / Director" meta:resourcekey="ListItemResource50" />
            <asp:ListItem Text="Project Manager" meta:resourcekey="ListItemResource51" />
            <asp:ListItem Text="Researcher" meta:resourcekey="ListItemResource52" />
            <asp:ListItem Text="Salesman" meta:resourcekey="ListItemResource53" />
            <asp:ListItem Text="Social Worker" meta:resourcekey="ListItemResource54" />
            <asp:ListItem Text="Soldier" meta:resourcekey="ListItemResource55" />
            <asp:ListItem Text="Sportsperson" meta:resourcekey="ListItemResource56" />
            <asp:ListItem Text="Student" meta:resourcekey="ListItemResource57" />
            <asp:ListItem Text="Teacher" meta:resourcekey="ListItemResource58" />
            <asp:ListItem Text="Technical Crew" meta:resourcekey="ListItemResource59" />
            <asp:ListItem Text="Technical Writer" meta:resourcekey="ListItemResource60" />
            <asp:ListItem Text="Therapist" meta:resourcekey="ListItemResource61" />
            <asp:ListItem Text="Translator" meta:resourcekey="ListItemResource62" />
            <asp:ListItem Text="Waitress / Waiter" meta:resourcekey="ListItemResource63" />
            <asp:ListItem Text="Web designer / author" meta:resourcekey="ListItemResource64" />
            <asp:ListItem Text="Writer" meta:resourcekey="ListItemResource65" />
            <asp:ListItem Text="Other" meta:resourcekey="ListItemResource66" />
         </asp:DropDownList>
      </td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblWebsite" AssociatedControlID="txtWebsite" Text="Website:" meta:resourcekey="lblWebsiteResource1" /></td>
      <td><asp:TextBox ID="txtWebsite" runat="server" Width="99%" meta:resourcekey="txtWebsiteResource1"></asp:TextBox></td>
   </tr>
</table>
<p></p>
<div class="sectionsubtitle">
<asp:Literal ID="Literal3" runat="server" Text="<%$ resources:Address %>" />
</div>
<p></p>
<table cellpadding="2">
   <tr>
      <td style="width: 110px;" class="fieldname"><asp:Label runat="server" ID="lblStreet" AssociatedControlID="txtStreet" Text="Street:" meta:resourcekey="lblStreetResource1" /></td>
      <td style="width: 400px;"><asp:TextBox runat="server" ID="txtStreet" Width="99%" meta:resourcekey="txtStreetResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblPostalCode" AssociatedControlID="txtPostalCode" Text="Zip / Postal code:" meta:resourcekey="lblPostalCodeResource1" /></td>
      <td><asp:TextBox runat="server" ID="txtPostalCode" Width="99%" meta:resourcekey="txtPostalCodeResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblCity" AssociatedControlID="txtCity" Text="City:" meta:resourcekey="lblCityResource1" /></td>
      <td><asp:TextBox runat="server" ID="txtCity" Width="99%" meta:resourcekey="txtCityResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblState" AssociatedControlID="txtState" Text="State / Region:" meta:resourcekey="lblStateResource1" /></td>
      <td><asp:TextBox runat="server" ID="txtState" Width="99%" meta:resourcekey="txtStateResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblCountry" AssociatedControlID="ddlCountries" Text="Country:" meta:resourcekey="lblCountryResource1" /></td>
      <td>
         <asp:DropDownList ID="ddlCountries" runat="server" AppendDataBoundItems="True" Width="99%" meta:resourcekey="ddlCountriesResource1">
            <asp:ListItem Text="Please select one..." Selected="True" meta:resourcekey="ListItemResource67" />
         </asp:DropDownList>
      </td>
   </tr>
</table>
<p></p>
<div class="sectionsubtitle">
<asp:Literal ID="Literal4" runat="server" Text="<%$ resources:Othercontacts %>" />
</div>
<p></p>
<table cellpadding="2">
   <tr>
      <td style="width: 110px;" class="fieldname"><asp:Label runat="server" ID="lblPhone" AssociatedControlID="txtPhone" Text="Phone:" meta:resourcekey="lblPhoneResource1" /></td>
      <td style="width: 400px;"><asp:TextBox runat="server" ID="txtPhone" Width="99%" meta:resourcekey="txtPhoneResource1" /></td>
   </tr>
   <tr>
      <td class="fieldname"><asp:Label runat="server" ID="lblFax" AssociatedControlID="txtFax" Text="Fax:" meta:resourcekey="lblFaxResource1" /></td>
      <td><asp:TextBox runat="server" ID="txtFax" Width="99%" meta:resourcekey="txtFaxResource1" /></td>
   </tr>
</table>--%>
