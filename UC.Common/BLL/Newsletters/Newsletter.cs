//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Collections.Generic;
//using System.Threading;
//using System.Web.Profile;
//using UC.DAL;
//using System.Text.RegularExpressions;
//using System.Net.Mail;
//using System.Net.Mime;
//using System.IO;

//namespace UC.BLL.Newsletters
//{
//    public struct SubscriberInfo
//    {
//        public string UserName;
//        public string Email;
//        public string FirstName;
//        public string LastName;

//        public SubscriberInfo(string userName, string email, string firstName, string lastName)
//        {
//            this.UserName = userName;
//            this.Email = email;
//            this.FirstName = firstName;
//            this.LastName = lastName;
//        }
//    }

//    public class Newsletter : BizObject
//    {
//        private static NewslettersElement Settings
//        {
//            get { return Globals.Settings.Newsletters; }
//        }

//        private int _id = 0;
//        public int ID
//        {
//            get { return _id; }
//            private set { _id = value; }
//        }

//        private DateTime _addedDate = DateTime.Now;
//        public DateTime AddedDate
//        {
//            get { return _addedDate; }
//            private set { _addedDate = value; }
//        }

//        private string _addedBy = "";
//        public string AddedBy
//        {
//            get { return _addedBy; }
//            private set { _addedBy = value; }
//        }

//        private string _subject = "";
//        public string Subject
//        {
//            get { return _subject; }
//            set { _subject = value; }
//        }

//        private string _abstract = "";
//        public string Abstract
//        {
//            get { return _abstract; }
//            set { _abstract = value; }
//        }

//        private string _htmlBody = null;
//        public string HtmlBody
//        {
//            get
//            {
//                if (_htmlBody == null)
//                    FillBody();
//                return _htmlBody;
//            }
//            set { _htmlBody = value; }
//        }

//        private bool _isSending = false;
//        public bool IsSending
//        {
//            get { return _isSending; }
//            set { _isSending = value; }
//        }

//        public Newsletter(int id, DateTime addedDate, string addedBy, string subject, string newsabstract, string htmlBody, bool isSending)
//        {
//            this.ID = id;
//            this.AddedDate = addedDate;
//            this.AddedBy = addedBy;
//            this.Subject = subject;
//            this.Abstract = newsabstract;
//            this.HtmlBody = htmlBody;
//            this.IsSending = isSending;
//        }

//        public bool Delete()
//        {
//            bool success = Newsletter.DeleteNewsletter(this.ID);
//            if (success)
//                this.ID = 0;
//            return success;
//        }

//        public bool Update()
//        {
//            return Newsletter.UpdateNewsletter(this.ID, this.Subject, this.Abstract, this.HtmlBody);
//        }

//        private void FillBody()
//        {
//            NewsletterDetails record = SiteProvider.Newsletters.GetNewsletterByID(this.ID);
//            this.HtmlBody = record.HtmlBody;
//        }

//        /***********************************
//        * Static properties
//        ************************************/
//        public static ReaderWriterLock Lock = new ReaderWriterLock();

//        private static bool _sending = false;
//        public static bool Sending
//        {
//            get { return _sending; }
//            private set { _sending = value; }
//        }

//        private static double _percentageCompleted = 0.0;
//        public static double PercentageCompleted
//        {
//            get { return _percentageCompleted; }
//            private set { _percentageCompleted = value; }
//        }

//        private static int _totalMails = -1;
//        public static int TotalMails
//        {
//            get { return _totalMails; }
//            private set { _totalMails = value; }
//        }

//        private static int _sentMails = 0;
//        public static int SentMails
//        {
//            get { return _sentMails; }
//            private set { _sentMails = value; }
//        }

//        /***********************************
//        * Static methods
//        ************************************/

//        /// <summary>
//        /// Возвращает весь список новостей
//        /// </summary>      
//        public static List<Newsletter> GetNewsletters()
//        {
//            return GetNewsletters(0, BizObject.MAXROWS);
//        }

//        /// <summary>
//        /// Возвращает последние новости
//        /// </summary>      
//        public static List<Newsletter> GetNewslettersLast(int count)
//        {
//            List<Newsletter> newsletters = null;
//            string key = "Newsletters_NewslettersLast_" + count.ToString();

//            if (Settings.EnableCaching && BizObject.Cache[key] != null)
//            {
//                newsletters = (List<Newsletter>)BizObject.Cache[key];
//            }
//            else
//            {
//                List<NewsletterDetails> recordset = SiteProvider.Newsletters.GetNewslettersLast(count);
//                newsletters = GetNewsletterListFromNewsletterDetailsList(recordset);
//                CacheData(key, newsletters);
//            }
//            return newsletters;
//        }

//        /// <summary>
//        /// Возвращает неразосланные новости. Не используем кэш, поскольку операция разовая.
//        /// </summary>      
//        public static List<Newsletter> GetNewslettersNoSending()
//        {
//            List<Newsletter> newsletters = null;
//            List<NewsletterDetails> recordset = SiteProvider.Newsletters.GetNewslettersNoSending();
//            newsletters = GetNewsletterListFromNewsletterDetailsList(recordset);
//            return newsletters;
//        }

//        /// <summary>
//        /// Возвращает список статей
//        /// </summary> 
//        public static List<Newsletter> GetNewsletters(int startRowIndex, int maximumRows)
//        {
//            List<Newsletter> newsletters = null;
//            string key = "Newsletters_Newsletters_" + startRowIndex.ToString() + "_" + maximumRows.ToString();

//            if (Settings.EnableCaching && BizObject.Cache[key] != null)
//            {
//                newsletters = (List<Newsletter>)BizObject.Cache[key];
//            }
//            else
//            {
//                List<NewsletterDetails> recordset = SiteProvider.Newsletters.GetNewsletters(GetPageIndex(startRowIndex, maximumRows), maximumRows);
//                newsletters = GetNewsletterListFromNewsletterDetailsList(recordset);
//                CacheData(key, newsletters);
//            }
//            return newsletters;
//        }

//        /// <summary>
//        /// Возвращает общее количество новостей
//        /// </summary>
//        public static int GetNewsletterCount()
//        {
//            int newsCount = 0;
//            string key = "Newsletters_NewsletterCount";

//            if (Settings.EnableCaching && BizObject.Cache[key] != null)
//            {
//                newsCount = (int)BizObject.Cache[key];
//            }
//            else
//            {
//                newsCount = SiteProvider.Newsletters.GetNewsletterCount();
//                CacheData(key, newsCount);
//            }
//            return newsCount;
//        }

//        /// <summary>
//        /// Returns a Newsletter object with the specified ID
//        /// </summary>
//        public static Newsletter GetNewsletterByID(int newsletterID)
//        {
//            Newsletter newsletter = null;
//            string key = "Newsletters_Newsletter_" + newsletterID.ToString();

//            if (Settings.EnableCaching && BizObject.Cache[key] != null)
//            {
//                newsletter = (Newsletter)BizObject.Cache[key];
//            }
//            else
//            {
//                newsletter = GetNewsletterFromNewsletterDetails(SiteProvider.Newsletters.GetNewsletterByID(newsletterID));
//                CacheData(key, newsletter);
//            }
//            return newsletter;
//        }

//        /// <summary>
//        /// Updates an existing newsletter
//        /// </summary>
//        public static bool UpdateNewsletter(int id, string subject, string Abstract, string htmlBody)
//        {
//            subject = BizObject.ConvertNullToEmptyString(subject);
//            Abstract = BizObject.ConvertNullToEmptyString(Abstract);
//            htmlBody = BizObject.ConvertNullToEmptyString(htmlBody);

//            NewsletterDetails record = new NewsletterDetails(id, DateTime.Now, "", subject, Abstract, htmlBody, false);
//            bool ret = SiteProvider.Newsletters.UpdateNewsletter(record);
//            BizObject.PurgeCacheItems("newsletters_newsletter");
//            return ret;
//        }

//        /// <summary>
//        /// Добалвяет новость
//        /// </summary>
//        public static int InsertNewsletter(string subject, string Abstract, string htmlBody)
//        {
//            NewsletterDetails record = new NewsletterDetails(0, DateTime.Now, BizObject.CurrentUserName, subject, Abstract, htmlBody, false);
//            int ret = SiteProvider.Newsletters.InsertNewsletter(record);
//            BizObject.PurgeCacheItems("newsletters_newsletter");
//            return ret;
//        }

//        /// <summary>
//        /// Deletes an existing newsletter
//        /// </summary>
//        public static bool DeleteNewsletter(int id)
//        {
//            bool ret = SiteProvider.Newsletters.DeleteNewsletter(id);
//            new RecordDeletedEvent("newsletter", id, null).Raise();
//            BizObject.PurgeCacheItems("newsletters_newsletter");
//            return ret;
//        }

//        /// <summary>
//        /// Устанавливает признак новость разослана
//        /// </summary>
//        public static bool IsSendingNewsletter(int id)
//        {
//            bool ret = SiteProvider.Newsletters.IsSendingNewsletter(id);
//            BizObject.PurgeCacheItems("newsletters_newsletter");
//            return ret;
//        }

//        /// <summary>
//        /// Рассылает новость
//        /// </summary>
//        public static void SendNewsletter(string subject, string newsabstract, string htmlBody)
//        {
//            Lock.AcquireWriterLock(Timeout.Infinite);
//            Newsletter.TotalMails = -1;
//            Newsletter.SentMails = 0;
//            Newsletter.PercentageCompleted = 0.0;
//            Newsletter.Sending = true;
//            Lock.ReleaseWriterLock();

//            // асинхронная отправка сообщений
//            object[] parameters = new object[] { subject, newsabstract, htmlBody, BizObject.CurrentUserName.ToLower() == "sampleeditor", HttpContext.Current };
//            ParameterizedThreadStart pts = new ParameterizedThreadStart(SendEmails);
//            Thread thread = new Thread(pts);
//            thread.Name = "SendEmails";
//            thread.Priority = ThreadPriority.BelowNormal;
//            thread.Start(parameters);
//        }

//        /// <summary>
//        /// Рассылает все неразосланные новости
//        /// </summary>
//        public static void SendNoSendingNewsletters(string subject, string newsFileName, string bodyFileName, string logo, string baner)
//        {
//            Lock.AcquireWriterLock(Timeout.Infinite);
//            Newsletter.TotalMails = -1;
//            Newsletter.SentMails = 0;
//            Newsletter.PercentageCompleted = 0.0;
//            Newsletter.Sending = true;
//            Lock.ReleaseWriterLock();

//            // формируем содержание письма для рассылки из шаблона заполняя его новостями
//            List<Newsletter> newsletters = Newsletter.GetNewslettersNoSending();

//            // считываем шаблон новости
//            StreamReader reader = File.OpenText(newsFileName);
//            string newsletterShablon = reader.ReadToEnd();
//            reader.Close();

//            string news = "";
//            foreach (Newsletter item in newsletters)
//            {
//                news += string.Format(newsletterShablon, item.ID.ToString(), item.AddedDate.ToShortDateString(), item.Subject, item.Abstract);
//                Newsletter.IsSendingNewsletter(item.ID);
//            }

//            // считываем шаблон письма
//            reader = File.OpenText(bodyFileName);
//            string mailShablon = reader.ReadToEnd();
//            reader.Close();

//            mailShablon = string.Format(mailShablon, news);

//            // асинхронная отправка сообщений
//            object[] parameters = new object[] { subject, mailShablon, BizObject.CurrentUserName.ToLower() == "sampleeditor", HttpContext.Current, logo, baner };
//            ParameterizedThreadStart pts = new ParameterizedThreadStart(SendEmails);
//            Thread thread = new Thread(pts);
//            thread.Name = "SendEmails";
//            thread.Priority = ThreadPriority.BelowNormal;
//            thread.Start(parameters);
//        }

//        /// <summary>
//        /// Отправка новости всем подписчикам
//        /// </summary>
//        private static void SendEmails(object data)
//        {
//            object[] parameters = (object[])data;
//            string subject = (string)parameters[0];
//            string htmlBody = (string)parameters[1];
//            bool isTestCall = (bool)parameters[2];
//            HttpContext context = (HttpContext)parameters[3];
//            string logo = (string)parameters[4];
//            string baner = (string)parameters[5];

//            if (isTestCall)
//            {
//                Lock.AcquireWriterLock(Timeout.Infinite);
//                Newsletter.TotalMails = 1256;
//                Lock.ReleaseWriterLock();

//                for (int i = 1; i <= 1256; i++)
//                {
//                    Thread.Sleep(15);
//                    Lock.AcquireWriterLock(Timeout.Infinite);
//                    Newsletter.SentMails = i;
//                    Newsletter.PercentageCompleted =
//                       (double)Newsletter.SentMails * 100 / (double)Newsletter.TotalMails; ;
//                    Lock.ReleaseWriterLock();
//                }
//            }
//            else
//            {
//                Lock.AcquireWriterLock(Timeout.Infinite);
//                Newsletter.TotalMails = 0;
//                Lock.ReleaseWriterLock();

//                // check if the plain-text and the HTML bodies have personalization placeholders
//                // that will need to be replaced on a per-mail basis. If not, the parsing will
//                // be completely avoided later.
//                bool htmlIsPersonalized = HasPersonalizationPlaceholders(htmlBody);

//                // retrieve all subscribers to the plain-text and HTML newsletter, 
//                List<SubscriberInfo> subscribers = new List<SubscriberInfo>();
//                ProfileCommon profile = context.Profile as ProfileCommon;

//                foreach (MembershipUser user in Membership.GetAllUsers())
//                {
//                    ProfileCommon userProfile = profile.GetProfile(user.UserName);
//                    if (userProfile.Preferences.Newsletter)
//                    {
//                        SubscriberInfo subscriber = new SubscriberInfo(user.UserName, user.Email, userProfile.FirstName, userProfile.LastName);
//                        subscribers.Add(subscriber);
//                        Lock.AcquireWriterLock(Timeout.Infinite);
//                        Newsletter.TotalMails += 1;
//                        Lock.ReleaseWriterLock();
//                    }
//                }

//                // send the newsletter
//                SmtpClient smtpClient = new SmtpClient();
//                foreach (SubscriberInfo subscriber in subscribers)
//                {
//                    MailMessage mail = new MailMessage();
//                    mail.From = new MailAddress(Settings.FromEmail, Settings.FromDisplayName, System.Text.Encoding.UTF8);
//                    mail.To.Add(subscriber.Email);

//                    mail.BodyEncoding = System.Text.Encoding.UTF8;
//                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

//                    mail.Subject = subject;

//                    // Вот эта хрень используется когда надо вложить в письмо картинку или другой медиа-файл, чтобы
//                    // он отображался в почтовых программах

//                    AlternateView av = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
//                    if (!String.IsNullOrEmpty(logo))
//                    {
//                        LinkedResource linkedResourceLogo = new LinkedResource(logo);
//                        linkedResourceLogo.ContentId = "logo";
//                        linkedResourceLogo.ContentType.Name = "logo.gif";
//                        av.LinkedResources.Add(linkedResourceLogo);
//                    }
//                    if (!String.IsNullOrEmpty(baner))
//                    {
//                        LinkedResource linkedResourceBaner = new LinkedResource(baner);
//                        linkedResourceBaner.ContentId = "baner";
//                        linkedResourceBaner.ContentType.Name = "baner.gif";
//                        av.LinkedResources.Add(linkedResourceBaner);
//                    }
//                    mail.AlternateViews.Add(av);

//                    string body = htmlBody;
//                    if (htmlIsPersonalized)
//                        body = ReplacePersonalizationPlaceholders(body, subscriber);
//                    mail.Body = body;
//                    mail.IsBodyHtml = true;

//                    try
//                    {
//                        smtpClient.Send(mail);
//                    }
//                    catch { }

//                    Lock.AcquireWriterLock(Timeout.Infinite);
//                    Newsletter.SentMails += 1;
//                    Newsletter.PercentageCompleted =
//                       (double)Newsletter.SentMails * 100 / (double)Newsletter.TotalMails;
//                    Lock.ReleaseWriterLock();
//                }
//            }

//            Lock.AcquireWriterLock(Timeout.Infinite);
//            Newsletter.Sending = false;
//            Lock.ReleaseWriterLock();
//        }

//        /// <summary>
//        /// Returns whether the input text contains personalization placeholders
//        /// </summary>
//        private static bool HasPersonalizationPlaceholders(string text)
//        {
//            if (Regex.IsMatch(text, @"&lt;%\s*username\s*%&gt;", RegexOptions.IgnoreCase | RegexOptions.Compiled))
//                return true;
//            if (Regex.IsMatch(text, @"&lt;%\s*email\s*%&gt;", RegexOptions.IgnoreCase | RegexOptions.Compiled))
//                return true;
//            if (Regex.IsMatch(text, @"&lt;%\s*firstname\s*%&gt;", RegexOptions.IgnoreCase | RegexOptions.Compiled))
//                return true;
//            if (Regex.IsMatch(text, @"&lt;%\s*lastname\s*%&gt;", RegexOptions.IgnoreCase | RegexOptions.Compiled))
//                return true;

//            return false;
//        }

//        /// <summary>
//        /// Replaces the input text's personalization placeholders
//        /// </summary>
//        private static string ReplacePersonalizationPlaceholders(string text, SubscriberInfo subscriber)
//        {
//            text = Regex.Replace(text, @"&lt;%\s*username\s*%&gt;",
//             subscriber.UserName, RegexOptions.IgnoreCase | RegexOptions.Compiled);
//            text = Regex.Replace(text, @"&lt;%\s*email\s*%&gt;",
//               subscriber.Email, RegexOptions.IgnoreCase | RegexOptions.Compiled);
//            text = Regex.Replace(text, @"&lt;%\s*firstname\s*%&gt;",
//               (subscriber.FirstName.Length > 0 ? subscriber.FirstName : "reader"),
//               RegexOptions.IgnoreCase | RegexOptions.Compiled);
//            text = Regex.Replace(text, @"&lt;%\s*lastname\s*%&gt;",
//               subscriber.LastName, RegexOptions.IgnoreCase | RegexOptions.Compiled);

//            return text;
//        }

//        /// <summary>
//        /// Returns a Newsletter object filled with the data taken from the input NewsletterDetails
//        /// </summary>
//        private static Newsletter GetNewsletterFromNewsletterDetails(NewsletterDetails record)
//        {
//            if (record == null)
//                return null;
//            else
//            {
//                return new Newsletter(record.ID, record.AddedDate, record.AddedBy, record.Subject,
//                   record.Abstract, record.HtmlBody, record.IsSending);
//            }
//        }

//        /// <summary>
//        /// Returns a list of Newsletter objects filled with the data taken from the input list of NewsletterDetails
//        /// </summary>
//        private static List<Newsletter> GetNewsletterListFromNewsletterDetailsList(List<NewsletterDetails> recordset)
//        {
//            List<Newsletter> newsletters = new List<Newsletter>();
//            foreach (NewsletterDetails record in recordset)
//                newsletters.Add(GetNewsletterFromNewsletterDetails(record));
//            return newsletters;
//        }

//        /// <summary>
//        /// Cache the input data, if caching is enabled
//        /// </summary>
//        private static void CacheData(string key, object data)
//        {
//            if (Settings.EnableCaching && data != null)
//            {
//                BizObject.Cache.Insert(key, data, null,
//                   DateTime.Now.AddSeconds(Settings.CacheDuration), TimeSpan.Zero);
//            }
//        }
//    }
//}