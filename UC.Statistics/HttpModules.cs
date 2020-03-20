using System;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Web;
using UC.BLL.Statistics;

namespace UC.HttpModules
{
    /// <summary>
    /// HttpModule - все приходящие запросы отправляет на обработку модуля статистики
    /// </summary>
    public class StatisticsModule : IHttpModule
    {
        void IHttpModule.Init(HttpApplication context)
        {
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
        }
        void IHttpModule.Dispose()
        {
        }
        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            Request.DoRequest(HttpContext.Current);
            //SiteStatsBLL.Request(HttpContext.Current);
        }
    }
}
