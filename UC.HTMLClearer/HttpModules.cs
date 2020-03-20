using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using UC.Utils;

namespace UC.HttpModules
{
    /// <summary>
    /// HttpModule - очищает выходной html от пробелов, табуляции и т.д.
    /// </summary>
    public class HTTPModule_HtmlClearer : IHttpModule
    {
        public void Dispose()
        {
        }
        /// <summary> 
        /// Подключение обработчиков событий 
        /// </summary> 
        public void Init(HttpApplication context)
        {
            //Подключаем обработчик на событие ReleaseRequestState 
            context.ReleaseRequestState += new EventHandler(this.context_Clear);
            //Подключаем обработчик на событие PreSendRequestHeaders 
            context.PreSendRequestHeaders += new EventHandler(this.context_Clear);
            //Два обработчика необходимы для совместимости с библиотеками сжатия HTML-документов 
        }
        /// <summary> 
        /// Обработчик события PostRequestHandlerExecute 
        /// </summary> 
        void context_Clear(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender; //Получение HTTP Application 
            string realPath = app.Request.Path.Remove(0, app.Request.ApplicationPath.Length + 1); //Получаем имя файла который обрабатывается 
            if (realPath == "WebResource.axd") //Проверяем не является ли он ссылкой на ресурс сборки 
                return;
            if (app.Response.ContentType == "text/html" || app.Response.ContentType == "text/javascript") //Проверяем тип содержимого 
                app.Context.Response.Filter = new HTMLClearer(app.Context.Response.Filter); //Устанавливаем фильтр обработчик 
        }
    }
}
