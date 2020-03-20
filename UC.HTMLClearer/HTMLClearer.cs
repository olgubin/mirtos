using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;

namespace UC.Utils
{
    public class HTMLClearer : System.IO.Stream
    {
        System.IO.Stream _HTML;

        public HTMLClearer(System.IO.Stream HTML)
        { _HTML = HTML; }

        public override bool CanRead
        {
            get { return false; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length
        {
            get { return _HTML.Length; }
        }

        public override long Position
        {
            get { return _HTML.Position; }
            set { _HTML.Position = value; }
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            return _HTML.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            _HTML.SetLength(value);
        }

        public override void Flush()
        {
            _HTML.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _HTML.Read(buffer, offset, count);
        }

        /// <summary> 
        /// Обрабатываем данные поступающие в Response 
        /// </summary> 
        public override void Write(byte[] buffer, int offset, int count)
        {
            //Преобразовываем массив байт в строку 
            //string s = System.Text.Encoding.UTF8.GetString(buffer);
            string s = System.Text.Encoding.Default.GetString(buffer);
            //Используя регулярные выражения убираем все ненужные символы 
            s = Regex.Replace(s, ">(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}(\r\n){0,10} {0,20}(\r\n){0,10} {0,20}<", "><", RegexOptions.Compiled);
            s = Regex.Replace(s, ";(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}", ";", RegexOptions.Compiled);
            s = Regex.Replace(s, "{(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}", "{", RegexOptions.Compiled);
            s = Regex.Replace(s, ">(\r\n){0,10}\t{0,10}<", "><", RegexOptions.Compiled);
            s = Regex.Replace(s, ">\r{0,10}\t{0,10}<", "><", RegexOptions.Compiled);
            //Получивщуюся строку преобразовываем обратно в byte 
            //byte[] outdata = System.Text.Encoding.UTF8.GetBytes(s);
            byte[] outdata = System.Text.Encoding.Default.GetBytes(s);
            //Записываем ее в Response 
            _HTML.Write(outdata, 0, outdata.Length);
        }
    }
}
