<%@ Application Language="C#" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Net.Mail" %>

<script RunAt="server">

    void Application_Start(Object sender, EventArgs e)
    {
        // Code that runs on application startup
    }

    void Application_End(Object sender, EventArgs e)
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(Object sender, EventArgs e)
    {
        //// Получение информации об исключении
        //Exception ex = Server.GetLastError();
        //if (ex.InnerException != null) ex = ex.InnerException;

        //// Получение текущей даты и времени
        //string dateTime = DateTime.Now.ToLongDateString() + " : " + DateTime.Now.ToShortTimeString();

        //// Сборка сообщения об ошибке
        //string errorMassage = "Исключение возникло: " + dateTime;
        //System.Web.HttpContext context = System.Web.HttpContext.Current;
        //errorMassage += "\n\n Местоположение страницы: " + context.Request.RawUrl;
        //errorMassage += "\n Сообщение: " + ex.Message;
        //errorMassage += "\n Источник: " + ex.Source;
        //errorMassage += "\n Метод: " + ex.TargetSite;
        //errorMassage += "\n ИП пользователя: " + context.Request.UserHostAddress;
        //errorMassage += "\n УРЛ пользователя: " + context.Request.UserHostName;
        //errorMassage += "\n Броузер пользователя: " + context.Request.UserAgent;
        //errorMassage += "\n Трасса стека: " + ex.StackTrace;

        //// Отправка информации об ошибке по почте
        //try
        //{
        //    SmtpClient client = new SmtpClient();
        //    MailMessage message = new MailMessage();
        //    message.From = new MailAddress("error@С-СLIMATE.RU", "Ошибка в работе С-СLIMATE.RU", System.Text.Encoding.UTF8);
        //    message.IsBodyHtml = false;
        //    message.Subject = "Отчет об ошибке на С-СLIMATE.RU";

        //    message.Body = errorMassage;

        //    message.BodyEncoding = System.Text.Encoding.UTF8;
        //    message.SubjectEncoding = System.Text.Encoding.UTF8;
        //    message.Priority = System.Net.Mail.MailPriority.High;

        //    message.To.Add("ogubin@С-СLIMATE.RU");

        //    client.Send(message);
        //}
        //catch (Exception myex)
        //{
        //    /* Игнорирование ошибки */
        //}

    }

    void Session_Start(Object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(Object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Profile_MigrateAnonymous(object sender, ProfileMigrateEventArgs e)
    {
        // get a reference to the previously anonymous user's profile
        ProfileCommon anonProfile = this.Profile.GetProfile(e.AnonymousID);
        // if set, copy its Theme and ShoppingCart to the current user's profile
        if (anonProfile.ShoppingCart.Items.Count > 0)
            this.Profile.ShoppingCart = anonProfile.ShoppingCart;

        //Отключаем получение темы из профиля
        //if (!string.IsNullOrEmpty(anonProfile.Preferences.Theme))
        //   this.Profile.Preferences.Theme = anonProfile.Preferences.Theme;

        // delete the anonymous profile
        ProfileManager.DeleteProfile(e.AnonymousID);
        AnonymousIdentificationModule.ClearAnonymousIdentifier();
    }

    /*
    void Application_PostAcquireRequestState(Object sender, EventArgs e)
    {
       System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture(
          this.Profile.Preferences.Culture);
       System.Threading.Thread.CurrentThread.CurrentCulture = culture;
       System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
    }
    */
       
</script>

