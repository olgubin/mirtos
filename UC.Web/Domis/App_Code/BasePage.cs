using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC.BLL.Store;
using UC.Core;

namespace UC.UI
{
    public class BasePage : System.Web.UI.Page
    {
        string _lastPage = "";
        public string LastPage
        {
            get
            {
                if (Session["last_page"] != null)
                {
                    _lastPage = (string)Session["last_page"];
                }

                return _lastPage;
            }
            set
            {
                _lastPage = value;

                Session["last_page"] = value;
            }
        }

        private DateTime _lastModified = DateTime.MinValue;

        public void Assign(DateTime lastModified)
        {
            if (_lastModified < lastModified)
                _lastModified = lastModified;
        }

        protected static System.Web.SessionState.HttpSessionState SessionState
        {
            get { return HttpContext.Current.Session; }
        }

        protected override void InitializeCulture()
        {
            //Отключаем выбор культуры, делаем ее предустановленной
            //string culture = (HttpContext.Current.Profile as ProfileCommon).Preferences.Culture;
            string culture = "ru-RU";
            this.Culture = culture;
            this.UICulture = culture;
        }

        protected override void OnPreInit(EventArgs e)
        {
            //Отключаем выбор темы из профиля
            //string id = Globals.ThemesSelectorID;
            //if (id.Length > 0)
            //{
            //    // if this is a postback caused by the theme selector's dropdownlist, retrieve
            //    // the selected theme and use it for the current page request
            //    if (this.Request.Form["__EVENTTARGET"] == id && !string.IsNullOrEmpty(this.Request.Form[id]))
            //    {
            //        this.Theme = this.Request.Form[id];
            //        (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme = this.Theme;
            //    }
            //    else
            //    {
            //        // if not a postback, or a postback caused by controls other then the theme selector,
            //        // set the page's theme with the value found in the user's profile, if present
            //        if (!string.IsNullOrEmpty((HttpContext.Current.Profile as ProfileCommon).Preferences.Theme))
            //            this.Theme = (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme;
            //    }
            //}

            if ((HttpContext.Current.Profile as ProfileCommon).ShoppingCart == null)
                (HttpContext.Current.Profile as ProfileCommon).ShoppingCart = new ShoppingCart();

            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            // add onfocus and onblur javascripts to all input controls on the forum,
            // so that the active control has a difference appearance
            // нафиг подсветку
            //Helpers.SetInputControlsHighlight(this, "highlight", false);



            // Проверка возможности записи в cookie on-line идентификатора пользователя
            // проверяем есть ли GUID  в сессии
            //if (Session["guid"] == null)
            //{
            //    HttpCookie cookie = this.Request.Cookies["guid"];
            //    if (cookie != null)
            //    {
            //        // если есть в cookie то записываем в сессию
            //        Session["guid"] = cookie.Value;
            //    }
            //    else
            //    {
            //        // если нет в cookie то генерим и записываем в cookie
            //        Guid guid = Guid.NewGuid();
            //        Response.Cookies["guid"].Value = guid.ToString();
            //        Response.Cookies["guid"].Expires = DateTime.Parse("01.01.2030");
            //    }
            //}

            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Assign(File.GetLastWriteTime(Page.GetType().Assembly.Location));
            DateTime utcLastModified = _lastModified.ToUniversalTime();

            DateTime utcModifiedSince;

            if (DateTime.TryParseExact(Page.Request.Headers["If-Modified-Since"], "R", CultureInfo.InvariantCulture, DateTimeStyles.None, out utcModifiedSince))
            {
                if (utcModifiedSince > utcLastModified)
                {
                    Page.Response.AppendHeader("Content-Length", "0");
                    Page.Response.StatusCode = 304;
                    Page.Response.StatusDescription = "Not Modified";
                    Page.Response.End();
                }
            }

            Page.Response.AppendHeader("Last-Modified", utcLastModified.ToString("R"));
        }

        public void SaveLastPage()
        {
            if (this.Request.UrlReferrer != null)
            {
                if (String.Compare(this.Request.UrlReferrer.Host, this.Request.Url.Host, true) == 0)
                {
                    LastPage = this.Request.UrlReferrer.PathAndQuery;
                }
                else
                {
                    LastPage = "";
                }
            }
        }

        public string BaseUrl
        {
            get
            {
                string url = this.Request.ApplicationPath;
                if (url.EndsWith("/"))
                    return url;
                else
                    return url + "/";
            }
        }

        public string FullBaseUrl
        {
            get
            {
                return this.Request.Url.AbsoluteUri.Replace(
                   this.Request.Url.PathAndQuery, "") + this.BaseUrl;
            }
        }

        protected void RequestLogin()
        {
            this.Response.Redirect(FormsAuthentication.LoginUrl +
               "?ReturnUrl=" + this.Request.Url.PathAndQuery);
        }

        public string FormatPrice(object price)
        {
            //return Convert.ToDecimal(price).ToString(Globals.Settings.Store.PriceAccuracy) + " " + Globals.Settings.Store.CurrencyCode;
            return Convert.ToDecimal(price).ToString(Globals.Settings.Store.PriceAccuracy) + " " + CurrencyManager.WorkingCurrency.CurrencyCode;
        }

        public string FormatPrice(object price, string currencyCode)
        {
            return Convert.ToDecimal(price).ToString(Globals.Settings.Store.PriceAccuracy) + " " + currencyCode;
        }

        /// <summary>
        /// Позволяет динамиески менять на странице заголовок и ключевые слова
        /// </summary>
        public static void HeaderWrite(Page page, string title, string keywords, string description)
        {
            page.Header.Title = title;

            if (!String.IsNullOrEmpty(keywords))
            {
                foreach (Control teg in page.Header.Controls)
                {
                    if (teg is HtmlMeta)
                    {
                        if ((teg as HtmlMeta).Name == "keywords")
                        {
                            (teg as HtmlMeta).Content = keywords;
                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(description))
            {
                foreach (Control teg in page.Header.Controls)
                {
                    if (teg is HtmlMeta)
                    {
                        if ((teg as HtmlMeta).Name == "description")
                        {
                            (teg as HtmlMeta).Content = description;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Удаляет из сессии все элементы которые начинаются на переданный префикс
        /// </summary>
        public static void PurgeSessionItems(string prefix)
        {
            prefix = prefix.ToLower();
            List<string> itemsToRemove = new List<string>();

            IEnumerator enumerator = SessionState.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.ToString().ToLower().StartsWith(prefix))
                    itemsToRemove.Add(enumerator.Current.ToString());
            }

            foreach (string itemToRemove in itemsToRemove)
                SessionState.Remove(itemToRemove);
        }
    }
}
