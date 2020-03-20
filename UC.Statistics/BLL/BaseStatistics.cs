using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.DAL;

namespace UC.BLL.Statistics
{
   public abstract class BaseStatistics : BizObject
   {
      protected static StatisticsElement Settings
      {
         get { return Globals.Settings.Statistics; }
      }

      /// <summary>
      /// Кэширование входных данных если указано в настройках
      /// </summary>
      protected static void CacheData(string key, object data)
      {
         if (Settings.EnableCaching && data != null)
         {
            BizObject.Cache.Insert(key, data, null,
               DateTime.Now.AddSeconds(Settings.CacheDuration), TimeSpan.Zero);
         }
      }
   }
}