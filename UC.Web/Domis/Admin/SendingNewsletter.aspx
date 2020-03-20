<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="Admin.master" AutoEventWireup="true" CodeFile="SendingNewsletter.aspx.cs" Inherits="UC.UI.Admin.SendingNewsletter"%>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="breadcrumb">
        <table>
            <tr>
                <td class="h1">
                    <a href="../Default.aspx">Мебель для ванной</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="Default.aspx">Администрирование</a>
                </td>
                <td class="s">|</td>
                <td class="h1">
                    <a href="ManageNewsletters.aspx">Управление новостями</a>
                </td>
            </tr>
        </table>
    </div>
    <div id="content">
   <asp:Panel ID="panProgress" runat="server">
   <div class="sectiontitle">
      <asp:Literal runat="server" ID="lblSendNewsletter" Text="Рассылка новостей..." />
   </div>
   <p></p>
   <div class="progressbarcontainer">
      <div class="progressbar" id="progressbar"></div>
   </div>
   <br /><br />
   <div id="progressdescription"></div>
   <br /><br />
   <div style="text-align: center; display: none;" id="panelcomplete"><img src="../Images/100ok.gif" width="70px" alt="" /></div>
   </asp:Panel>
   
   <asp:Panel ID="panNoNewsletter" runat="server" Visible="false">
      <b>Проблемы при рассылке новостей.</b>
   </asp:Panel>
   
   <script type="text/javascript">      
      function CallUpdateProgress()
      {
         <asp:Literal runat="server" ID="lblScriptName" />;
      }
      
      function UpdateProgress(result, context) 
      {
         // result is a semicolon-separated list of values, so split it
         var params = result.split(";");
         var percentage = params[0];
         var sentMails = params[1];
         var totalMails = params[2];
         
         if (totalMails < 0)
            totalMails = '???';
         
         // update progressbar's width and description text
         var progBar = window.document.getElementById('progressbar');
         progBar.style.width = percentage + '%';
         var descr = window.document.getElementById('progressdescription');
         descr.innerHTML = '<b>' + percentage + '% выполнено</b> - ' +
            sentMails + ' из ' + totalMails + ' писем отправлено.';
         
         // if the current percentage is less than 100%, 
         // recall the server callback method in 2 seconds
         if (percentage == '100')
            window.document.getElementById('panelcomplete').style.display = '';
         else
            setTimeout('CallUpdateProgress()', 2000);
      }
   </script>
   </div>
</asp:Content>

