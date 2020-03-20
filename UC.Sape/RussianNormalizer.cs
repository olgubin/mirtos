using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net;

namespace effetto.Sape
{
    class RussianNormalizer
    {
        [ThreadStatic]
        private static Dictionary<string, List<string>> replaceXML;
        [ThreadStatic]
        private static Dictionary<string, List<string>> replaceURL;
        [ThreadStatic]
        private static Dictionary<string, List<string>> replaceUnicode;

        private static void InitReplaceArray()
        {
            string russianAlphabet = "АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя "; //"";
            string fullAlphabet = "";
            int byteindex;
            for (byteindex = byte.MinValue; byteindex <= byte.MaxValue; byteindex++)
            {
                byte[] arr = { Convert.ToByte(byteindex) };
                fullAlphabet += Encoding.GetEncoding(1251).GetChars(arr)[0];
            }
            replaceXML = new Dictionary<string, List<string>>();
            lock (replaceXML)
            {
                replaceXML.Clear();
                foreach (Char c in russianAlphabet.ToCharArray())
                {
                    string chr = c.ToString();
                    byte[] charbytes = Encoding.GetEncoding(1251).GetBytes(chr);
                    string code = "&#" + charbytes[0].ToString() + ";";
                    List<string> badwords = new List<string>();
                    badwords.Add(code);
                    if ((c.ToString() != null) && (badwords != null))
                    replaceXML.Add(c.ToString(), badwords);
                }
            }
            replaceURL = new Dictionary<string, List<string>>();
            lock (replaceURL)
            {
                replaceURL.Clear();
                foreach (Char c in fullAlphabet.ToCharArray())
                {
                    string chr = c.ToString();
                    byte[] charbytes = Encoding.GetEncoding(1251).GetBytes(chr);
                    string code = "%" + charbytes[0].ToString("X2") /*+ ";"*/;
                    List<string> badwords = new List<string>();
                    badwords.Add(code.ToLower());
                    badwords.Add(code.ToUpper());
                    if ((c.ToString() != null) && (badwords != null))
                        replaceURL.Add(c.ToString(), badwords);
                }
            }            
            replaceUnicode = new Dictionary<string, List<string>>();
            lock (replaceUnicode)
            {
                replaceUnicode.Clear();
                foreach (Char c in fullAlphabet.ToCharArray())
                {
                    string chr = c.ToString();
                    byte[] charbytes = Encoding.UTF8.GetBytes(chr);
                    string code = "";
                    foreach (byte b in charbytes)
                    {
                        code += "%" + b.ToString("X2");
                    }
                    List<string> badwords = new List<string>();
                    badwords.Add(code.ToLower());
                    badwords.Add(code.ToUpper());
                    if ((c.ToString() != null) && (badwords != null))
                    replaceUnicode.Add(c.ToString(), badwords);
                }
            }

        }
        private static string GetStringByUrl(string url)
        {
            WebClient wc = new WebClient();
            byte[] data = wc.DownloadData(url);
            string str = Encoding.UTF8.GetString(data);
            return str;
        }
        public static XDocument GetFixedXML(string url)
        {
            if (replaceXML == null)                
                InitReplaceArray();
            string str = GetStringByUrl(url);

            StringBuilder builder = new StringBuilder(str);
            foreach (string word in replaceXML.Keys)
                foreach (string badword in word != null ? replaceXML[word] : new List<string>())
                    builder.Replace(badword, word);
            XDocument doc = XDocument.Parse(builder.ToString());
            return doc;
        }
        public static string GetFixedUrl(string url)
        {
            if (replaceURL == null)
                InitReplaceArray();
            StringBuilder builder = new StringBuilder(url);

            foreach (string word in replaceUnicode.Keys)
                foreach (string badword in word != null ? replaceUnicode[word] : new List<string>())
                    builder.Replace(badword, word);

            foreach (string word in replaceURL.Keys)
                foreach (string badword in word != null ? replaceURL[word] : new List<string>())
                    builder.Replace(badword, word);

            return builder.ToString();
        }
    }
}
