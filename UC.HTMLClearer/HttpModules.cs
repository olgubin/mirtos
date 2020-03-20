using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using UC.Utils;

namespace UC.HttpModules
{
    /// <summary>
    /// HttpModule - ������� �������� html �� ��������, ��������� � �.�.
    /// </summary>
    public class HTTPModule_HtmlClearer : IHttpModule
    {
        public void Dispose()
        {
        }
        /// <summary> 
        /// ����������� ������������ ������� 
        /// </summary> 
        public void Init(HttpApplication context)
        {
            //���������� ���������� �� ������� ReleaseRequestState 
            context.ReleaseRequestState += new EventHandler(this.context_Clear);
            //���������� ���������� �� ������� PreSendRequestHeaders 
            context.PreSendRequestHeaders += new EventHandler(this.context_Clear);
            //��� ����������� ���������� ��� ������������� � ������������ ������ HTML-���������� 
        }
        /// <summary> 
        /// ���������� ������� PostRequestHandlerExecute 
        /// </summary> 
        void context_Clear(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender; //��������� HTTP Application 
            string realPath = app.Request.Path.Remove(0, app.Request.ApplicationPath.Length + 1); //�������� ��� ����� ������� �������������� 
            if (realPath == "WebResource.axd") //��������� �� �������� �� �� ������� �� ������ ������ 
                return;
            if (app.Response.ContentType == "text/html" || app.Response.ContentType == "text/javascript") //��������� ��� ����������� 
                app.Context.Response.Filter = new HTMLClearer(app.Context.Response.Filter); //������������� ������ ���������� 
        }
    }
}
