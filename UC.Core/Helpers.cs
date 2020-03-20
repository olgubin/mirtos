using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Text.RegularExpressions;
using UC.Core;

namespace UC
{
    public static class Helpers
    {
        private static string[] _countries = new string[] { 
         "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", 
         "Angola", "Anguilla", "Antarctica", "Antigua And Barbuda", "Argentina", 
         "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan",
		   "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus",
		   "Belgium", "Belize", "Benin", "Bermuda", "Bhutan",
		   "Bolivia", "Bosnia Hercegovina", "Botswana", "Bouvet Island", "Brazil",
		   "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Byelorussian SSR",
		   "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands",
		   "Central African Republic", "Chad", "Chile", "China", "Christmas Island",
		   "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Cook Islands",
		   "Costa Rica", "Cote D'Ivoire", "Croatia", "Cuba", "Cyprus",
		   "Czech Republic", "Czechoslovakia", "Denmark", "Djibouti", "Dominica",
		   "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador",
		   "England", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia",
		   "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France",
		   "Gabon", "Gambia", "Georgia", "Germany", "Ghana",
		   "Gibraltar", "Great Britain", "Greece", "Greenland", "Grenada",
		   "Guadeloupe", "Guam", "Guatemela", "Guernsey", "Guiana",
		   "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Islands",
		   "Honduras", "Hong Kong", "Hungary", "Iceland", "India",
		   "Indonesia", "Iran", "Iraq", "Ireland", "Isle Of Man",
		   "Israel", "Italy", "Jamaica", "Japan", "Jersey",
		   "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, South",
		   "Korea, North", "Kuwait", "Kyrgyzstan", "Lao People's Dem. Rep.", "Latvia",
		   "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein",
		   "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar",
		   "Malawi", "Malaysia", "Maldives", "Mali", "Malta",
		   "Mariana Islands", "Marshall Islands", "Martinique", "Mauritania", "Mauritius",
		   "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco",
		   "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar",
		   "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles",
		   "Neutral Zone", "New Caledonia", "New Zealand", "Nicaragua", "Niger",
		   "Nigeria", "Niue", "Norfolk Island", "Northern Ireland", "Norway",
		   "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea",
		   "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland",
		   "Polynesia", "Portugal", "Puerto Rico", "Qatar", "Reunion",
		   "Romania", "Russian Federation", "Rwanda", "Saint Helena", "Saint Kitts",
		   "Saint Lucia", "Saint Pierre", "Saint Vincent", "Samoa", "San Marino",
		   "Sao Tome and Principe", "Saudi Arabia", "Scotland", "Senegal", "Seychelles",
		   "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands",
		   "Somalia", "South Africa", "South Georgia", "Spain", "Sri Lanka",
		   "Sudan", "Suriname", "Svalbard", "Swaziland", "Sweden",
		   "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikista", "Tanzania",
		   "Thailand", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago",
		   "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu",
		   "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States",
		   "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City State", "Venezuela",
		   "Vietnam", "Virgin Islands", "Wales", "Western Sahara", "Yemen",
		   "Yugoslavia", "Zaire", "Zambia", "Zimbabwe"};

        /// <summary>
        /// Returns an array with all countries
        /// </summary>     
        public static StringCollection GetCountries()
        {
            StringCollection countries = new StringCollection();
            countries.AddRange(_countries);
            return countries;
        }
        public static SortedList GetCountries(bool insertEmpty)
        {
            SortedList countries = new SortedList();
            if (insertEmpty)
                countries.Add("", "Please select one...");
            foreach (String country in _countries)
                countries.Add(country, country);
            return countries;
        }

        /// <summary>
        /// Returns an array with the names of all local Themes
        /// </summary>
        public static string[] GetThemes()
        {
            if (HttpContext.Current.Cache["SiteThemes"] != null)
            {
                return (string[])HttpContext.Current.Cache["SiteThemes"];
            }
            else
            {
                string themesDirPath = HttpContext.Current.Server.MapPath("~/App_Themes");
                // get the array of themes folders under /app_themes
                string[] themes = Directory.GetDirectories(themesDirPath);
                for (int i = 0; i <= themes.Length - 1; i++)
                    themes[i] = Path.GetFileName(themes[i]);
                // cache the array with a dependency to the folder
                CacheDependency dep = new CacheDependency(themesDirPath);
                HttpContext.Current.Cache.Insert("SiteThemes", themes, dep);
                return themes;
            }
        }

        /// <summary>
        /// Adds the onfocus and onblur attributes to all input controls found in the specified parent,
        /// to change their apperance with the control has the focus
        /// </summary>
        public static void SetInputControlsHighlight(Control container, string className, bool onlyTextBoxes)
        {
            foreach (Control ctl in container.Controls)
            {
                if ((onlyTextBoxes && ctl is TextBox) || ctl is TextBox || ctl is DropDownList ||
                    ctl is ListBox || ctl is CheckBox || ctl is RadioButton ||
                    ctl is RadioButtonList || ctl is CheckBoxList)
                {
                    WebControl wctl = ctl as WebControl;
                    wctl.Attributes.Add("onfocus", string.Format("this.className = '{0}';", className));
                    wctl.Attributes.Add("onblur", "this.className = '';");
                }
                else
                {
                    if (ctl.Controls.Count > 0)
                        SetInputControlsHighlight(ctl, className, onlyTextBoxes);
                }
            }
        }

        public static string ConvertNullToEmptyString(string input)
        {
            return (input == null ? "" : input);
        }

        /// <summary>
        /// Converts the input plain-text to HTML version, replacing carriage returns
        /// and spaces with <br /> and &nbsp;
        /// </summary>
        public static string ConvertToHtml(string content)
        {
            content = HttpUtility.HtmlEncode(content);
            content = content.Replace("  ", "&nbsp;&nbsp;").Replace(
               "\t", "&nbsp;&nbsp;&nbsp;").Replace("\n", "<br>");
            return content;
        }

        /// <summary>
        /// Преобразует поисковый запрос в соответствии с алгоритмом DotShoppingCart 
        /// </summary>
        public static string ConvertToFullTextSearchString(string search)
        {
            if (string.IsNullOrEmpty(search))
                return search;

            char[] wordSeparators = new char[] { ',', ';', ',', '.', '!', ',', '?', ' ' };//char elemnets is used when to seperat the entered query
            search = search.Replace("'", " ");
            string[] words = search.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(",",words);

            //search = search.Replace("'", "").Replace("-", "").Replace(",", ""); // disallow single quote and dash for security reason although sproc has another level of defense
            //List<string> keywords = new List<string>();
            //int firstQuotePosition = -1;
            //int wordStartPostion = 0;
            //for (int i = 0; i < search.Length; i++)
            //{
            //    switch (search[i])
            //    {
            //        case '\"':
            //            if (firstQuotePosition >= 0)
            //            {
            //                keywords.Add(search.Substring(firstQuotePosition, i - firstQuotePosition + 1));
            //                firstQuotePosition = -1;
            //                wordStartPostion = i + 1;
            //            }
            //            else
            //            {
            //                //word break with quote
            //                if (wordStartPostion < i)
            //                    keywords.Add(search.Substring(wordStartPostion, i - wordStartPostion));
            //                firstQuotePosition = i;
            //            }
            //            break;
            //        case ' ':
            //            if (-1 == firstQuotePosition)
            //            {
            //                //word break with space
            //                if (wordStartPostion < i)
            //                    keywords.Add(search.Substring(wordStartPostion, i - wordStartPostion));
            //                wordStartPostion = i + 1;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //if (firstQuotePosition >= 0)
            //    keywords.Add(search.Substring(firstQuotePosition) + "\"");
            //else if (wordStartPostion < search.Length)
            //    keywords.Add(search.Substring(wordStartPostion));
            //return string.Join(",", keywords.ToArray());
        }

        /// <summary>
        /// Отправляет письма
        /// </summary>
        public static bool SendEmail(string from, string fromCaption, string to, string subject, string pathFileName, MembershipUser user)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from, fromCaption, System.Text.Encoding.UTF8);
                message.To.Add(to);
                message.IsBodyHtml = false;
                message.Subject = subject;

                StreamReader reader = File.OpenText(pathFileName);
                message.Body = reader.ReadToEnd();
                reader.Close();

                message.Body = Regex.Replace(message.Body, @"<%\s*e-mail\s*%>", user.Email, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                message.Body = Regex.Replace(message.Body, @"<%\s*username\s*%>", user.Comment, RegexOptions.IgnoreCase | RegexOptions.Compiled);
                message.Body = Regex.Replace(message.Body, @"<%\s*password\s*%>", user.GetPassword(), RegexOptions.IgnoreCase | RegexOptions.Compiled);
                message.Body = Regex.Replace(message.Body, @"<%\s*ShopName\s*%>", SettingManager.GetSettingValue("Common.Domen"), RegexOptions.IgnoreCase | RegexOptions.Compiled);
                message.Body = Regex.Replace(message.Body, @"<%\s*FullShopName\s*%>", SettingManager.GetSettingValue("Common.StoreName"), RegexOptions.IgnoreCase | RegexOptions.Compiled);
                message.Body = Regex.Replace(message.Body, @"<%\s*Phone\s*%>", SettingManager.GetSettingValue("Common.Phone"), RegexOptions.IgnoreCase | RegexOptions.Compiled);

                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Priority = System.Net.Mail.MailPriority.High;

                client.Send(message);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Заполняет мета тэг страницы
        /// </summary>
        /// <param name="page">Страница</param>
        /// <param name="name">Название тэга</param>
        /// <param name="content">содержание</param>
        /// <param name="OverwriteExisting">Перезаписывать существующий или нет</param>
        public static void RenderMetaTag(Page page, string name, string content, bool OverwriteExisting)
        {
            foreach (Control control in page.Header.Controls)
                if (control is HtmlMeta)
                {
                    HtmlMeta meta = (HtmlMeta)control;
                    if (meta.Name.ToLower().Equals(name.ToLower()) && !string.IsNullOrEmpty(content))
                    {
                        if (OverwriteExisting)
                            meta.Content = content;
                        else
                        {
                            if (String.IsNullOrEmpty(meta.Content))
                                meta.Content = content;
                        }
                    }
                }
        }

        /// <summary>
        /// Заполняет титл страницы
        /// </summary>
        /// <param name="page">Инстанс страницы</param>
        /// <param name="title">Титл</param>
        /// <param name="OverwriteExisting">Перезаписывать или нет</param>
        public static void RenderTitle(Page page, string title, bool OverwriteExisting)
        {
            if (String.IsNullOrEmpty(title))
                return;

            if (OverwriteExisting)
                page.Title = title;
            else
            {
                if (String.IsNullOrEmpty(page.Title))
                    page.Title = title;
            }
        }

        /// <summary>
        /// Заполняет титл страницы
        /// </summary>
        /// <param name="page">Инстанс страницы</param>
        /// <param name="title">Титл</param>
        /// <param name="OverwriteExisting">Перезаписывать или нет</param>
        public static void AddMetaTag(Page page, string name, string content)
        {
            HtmlMeta yandex = new HtmlMeta();
            yandex.Name = name;
            yandex.Content = content;
            page.Header.Controls.Add(yandex);
        }
    }
}
