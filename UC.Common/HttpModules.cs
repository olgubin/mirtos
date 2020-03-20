using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using UC.BLL.Store;
using UC.BLL.Images;

namespace UC
{
    /// <summary>
    /// HttpModule - очищает выходной html от пробелов, табуляции и т.д.
    /// </summary>
    public class HTTPModule_Clearer : IHttpModule
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

    // Обработчик запроса выводящий маленькие рисунки товаров
    public class SmallImagePictureHandler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            {
                int ID = Int32.Parse(request.QueryString["ID"]);

                Product product = ProductManager.GetByProductID(ID);

                string path = "";

                if (!String.IsNullOrEmpty(product.SmallImageUrl))
                {
                    path = context.Server.MapPath(product.SmallImageUrl);
                }
                else
                {
                    if (!String.IsNullOrEmpty(product.FullImageUrl))
                    {
                        path = context.Server.MapPath(product.FullImageUrl);
                    }
                    else
                    {
                        path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
                    }
                }

                System.Drawing.Image imgOriginal = null;

                if (!String.IsNullOrEmpty(path))
                {
                    imgOriginal = System.Drawing.Image.FromFile(path);

                    //imgOriginal = Images.GetImageByUrl(path);

                }
                System.Drawing.Image imgSmallResize = Images.ResizeImage(imgOriginal, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                System.Drawing.Image imgSmallText = Images.InsertText(imgSmallResize, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize);

                Images.SaveImageProductToStream(imgSmallText, response.OutputStream);
            }
        }
    }

    // Обработчик запроса выводящий маленькие рисунки товаров
    public class FullImagePictureHandler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            {
                int ID = Int32.Parse(request.QueryString["ID"]);

                Product product = ProductManager.GetByProductID(ID);

                string path = "";

                if (!String.IsNullOrEmpty(product.FullImageUrl))
                {
                    path = context.Server.MapPath(product.FullImageUrl);
                }
                else
                {
                    path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
                }

                System.Drawing.Image imgOriginal = null;

                if (!String.IsNullOrEmpty(path))
                {
                    imgOriginal = System.Drawing.Image.FromFile(path);

                    //imgOriginal = Images.GetImageByUrl(path);

                }

                System.Drawing.Image imgFullResize = Images.ResizeImage(imgOriginal, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                //получение изображения маски
                System.Drawing.Image imgFullMark = Images.GetImageByFile(AppDomain.CurrentDomain.BaseDirectory + Globals.Settings.Images.WatermarkImagePath);
                System.Drawing.Image imgFullWatermark = Images.InsertWatermak(imgFullResize, imgFullMark, 1.0f);

                Images.SaveImageProductToStream(imgFullWatermark, response.OutputStream);
            }
        }
    }

    // Обработчик запроса выводящий маленькие рисунки для распродажи
    public class SalesPictureHandler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            //if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            //{
            //    int ID = Int32.Parse(request.QueryString["ID"]);

            //    Product product = ProductManager.GetByProductID(ID);

            //    string path = "";

            //    if (!String.IsNullOrEmpty(product.SmallImageUrl))
            //    {
            //        path = context.Server.MapPath(product.SmallImageUrl);
            //    }
            //    else
            //    {
            //        path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
            //    }

            //    Images.SaveSalesProductImageFromFileToStream(path, Globals.Settings.Images.ProductSalesImageWidth, Globals.Settings.Images.ProductSalesImageHeight, context.Server.MapPath(Globals.Settings.Images.DiscountImagePath), product.DiscountPercentage, Globals.Settings.Images.DiscountFontName, Globals.Settings.Images.DiscountFontSize, response.OutputStream);
            //}

            if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            {
                int ID = Int32.Parse(request.QueryString["ID"]);

                Product product = ProductManager.GetByProductID(ID);

                string path = "";

                if (!String.IsNullOrEmpty(product.SmallImageUrl))
                {
                    path = context.Server.MapPath(product.SmallImageUrl);
                }
                else
                {
                    if (!String.IsNullOrEmpty(product.FullImageUrl))
                    {
                        path = context.Server.MapPath(product.FullImageUrl);
                    }
                    else
                    {
                        path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
                    }
                }

                System.Drawing.Image imgOriginal = null;

                if (!String.IsNullOrEmpty(path))
                {
                    imgOriginal = System.Drawing.Image.FromFile(path);

                    //imgOriginal = Images.GetImageByUrl(path);

                }
                System.Drawing.Image imgSmallResize = Images.ResizeImage(imgOriginal, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageWidth);
                System.Drawing.Image imgSmallText = Images.InsertText(imgSmallResize, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize);

                Images.SaveSalesProductImageToStream(imgSmallText, Globals.Settings.Images.ProductSalesImageWidth, Globals.Settings.Images.ProductSalesImageHeight, context.Server.MapPath(Globals.Settings.Images.DiscountImagePath), product.DiscountPercentage, Globals.Settings.Images.DiscountFontName, Globals.Settings.Images.DiscountFontSize, response.OutputStream);
            }
        }
    }

    // Обработчик запроса выводящий маленькие рисунки для распродажи
    public class FeaturedPictureHandler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            //if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            //{
            //    int ID = Int32.Parse(request.QueryString["ID"]);

            //    Product product = ProductManager.GetByProductID(ID);

            //    string path = "";

            //    if (!String.IsNullOrEmpty(product.SmallImageUrl))
            //    {
            //        path = context.Server.MapPath(product.SmallImageUrl);
            //    }
            //    else
            //    {
            //        path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
            //    }

            //    Images.SaveProductFeaturedImageFromFileToStream(path, Globals.Settings.Images.ProductFeaturedImageWidth, Globals.Settings.Images.ProductFeaturedImageHeight, context.Server.MapPath(Globals.Settings.Images.DiscountImagePath), product.DiscountPercentage, Globals.Settings.Images.DiscountFontName, Globals.Settings.Images.DiscountFontSize, response.OutputStream);
            //}

            if (!String.IsNullOrEmpty(request.QueryString["ID"]))
            {
                int ID = Int32.Parse(request.QueryString["ID"]);

                Product product = ProductManager.GetByProductID(ID);

                string path = "";

                if (!String.IsNullOrEmpty(product.SmallImageUrl))
                {
                    path = context.Server.MapPath(product.SmallImageUrl);
                }
                else
                {
                    if (!String.IsNullOrEmpty(product.FullImageUrl))
                    {
                        path = context.Server.MapPath(product.FullImageUrl);
                    }
                    else
                    {
                        path = context.Server.MapPath(Globals.Settings.Images.DefaultProductImagePath);
                    }
                }

                System.Drawing.Image imgOriginal = null;

                if (!String.IsNullOrEmpty(path))
                {
                    imgOriginal = System.Drawing.Image.FromFile(path);

                    //imgOriginal = Images.GetImageByUrl(path);

                }
                System.Drawing.Image imgSmallResize = Images.ResizeImage(imgOriginal, Globals.Settings.Images.ProductFeaturedImageWidth, Globals.Settings.Images.ProductFeaturedImageHeight);
                System.Drawing.Image imgSmallText = Images.InsertText(imgSmallResize, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize);

                Images.SaveProductFeaturedImageToStream(imgSmallText, Globals.Settings.Images.ProductFeaturedImageWidth, Globals.Settings.Images.ProductFeaturedImageHeight, context.Server.MapPath(Globals.Settings.Images.DiscountImagePath), product.DiscountPercentage, Globals.Settings.Images.DiscountFontName, Globals.Settings.Images.DiscountFontSize, response.OutputStream);
            }
        }
    }

    // Обработчик запроса выводящий маленькие рисунки для производителей
    public class ManufacturersHandler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get { return true; }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            if (!String.IsNullOrEmpty(request.QueryString["ManID"]))
            {
                int ID = Int32.Parse(request.QueryString["ManID"]);

                Manufacturer manufacturer = ManufacturerManager.GetManufacturerByID(ID);
                string path = context.Server.MapPath(manufacturer.ImageUrl);

                Images.SaveImageFromFileToStream(path, Globals.Settings.Images.ManufacturerImageWidth, Globals.Settings.Images.ManufacturerImageHeight, response.OutputStream);
            }
        }
    }

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
