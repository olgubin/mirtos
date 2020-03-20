using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Management;

namespace UC
{
    public abstract class WebCustomEvent : WebBaseEvent
    {
        public WebCustomEvent(string message, object eventSource, int eventCode) : base(message, eventSource, eventCode) 
        { }
    }

    public class RecordDeletedEvent : WebCustomEvent
    {
        private const int eventCode = WebEventCodes.WebExtendedBase + 10;
        private const string message = "{0} ID = {1} был удален пользователем {2}.";

        public RecordDeletedEvent(string entity, int id, object eventSource) : base(string.Format(message, entity, id, HttpContext.Current.User.Identity.Name), eventSource, eventCode) 
        { }
    }

    public class RecordCustomEvent : WebCustomEvent
    {
        private const int eventCode = WebEventCodes.WebExtendedBase + 10;

        public RecordCustomEvent(string message, object eventSource)
            : base(message, eventSource, eventCode)
        { }
    }
}
