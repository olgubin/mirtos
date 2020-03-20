<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShippingAddress.ascx.cs" Inherits="UC.UI.Controls.ShippingAddress"%>
<table width="100%">
    <tr style="background-color:#fef7f8">
        <td class="fieldcaption" style="width:25%">
             <span style="color: Red;">*</span> ФИО получателя:
        </td>
        <td class="fieldtext" style="width:25%">
            <asp:TextBox runat="server" ID="txtFIO" Width="99%" TabIndex="1"/>
            <asp:RequiredFieldValidator ID="valRequireFIO" runat="server" ControlToValidate="txtFIO" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Address">обязательно для заполнения</asp:RequiredFieldValidator>
        </td>
        <td class="fieldcaption" style="width:25%">
             Улица:
        </td>
        <td class="fieldtext" style="width:25%">
            <asp:TextBox runat="server" ID="txtStreet" Width="99%" TabIndex="7"/>
        </td>                             
    </tr>
    <tr>
        <td class="fieldcaption">
             <span style="color: Red;">*</span> Телефон:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtTelephone" Width="99%" TabIndex="2"/>
            <asp:RequiredFieldValidator ID="valRequireTelephone" runat="server" ControlToValidate="txtTelephone" SetFocusOnError="True" Display="Dynamic" ValidationGroup="Address">обязательно для заполнения</asp:RequiredFieldValidator>
        </td>
        <td class="fieldcaption">
             Дом:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtHouse" Width="99%" TabIndex="8"/>
        </td>        
    </tr>    
    <tr style="background-color:#fef7f8">
        <td class="fieldcaption">
             Почтовый индекс:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtPostCode" Width="99%" TabIndex="3"/>
        </td>        
        <td class="fieldcaption">
             Квартира/офис:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtOfis" Width="99%" TabIndex="9"/>
        </td>  
    </tr>  
    <tr>
        <td class="fieldcaption">
             Область:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtOblast" Width="99%" TabIndex="4"/>
        </td>
        <td class="fieldcaption" rowspan="3">
             Комментарий:
        </td>                            
        <td class="fieldtext" rowspan="3">
            <asp:TextBox runat="server" ID="txtComment" Width="99%" TextMode="MultiLine" Rows="5" TabIndex="10"/>
        </td>                             
    </tr>    
    <tr style="background-color:#fef7f8">
        <td class="fieldcaption">
             Район:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtRaion" Width="99%" TabIndex="5"/>
        </td>
    </tr>
    <tr>
        <td class="fieldcaption">
             Город/поселок:
        </td>
        <td class="fieldtext">
            <asp:TextBox runat="server" ID="txtGorod" Width="99%" TabIndex="6"/>
        </td>        
    </tr>                        
</table>
