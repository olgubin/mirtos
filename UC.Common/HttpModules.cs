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
    /// HttpModule - ������� �������� html �� ��������, ��������� � �.�.
    /// </summary>
    public class HTTPModule_Clearer : IHttpModule
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

    // ���������� ������� ��������� ��������� ������� �������
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

    // ���������� ������� ��������� ��������� ������� �������
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
                //��������� ����������� �����
                System.Drawing.Image imgFullMark = Images.GetImageByFile(AppDomain.CurrentDomain.BaseDirectory + Globals.Settings.Images.WatermarkImagePath);
                System.Drawing.Image imgFullWatermark = Images.InsertWatermak(imgFullResize, imgFullMark, 1.0f);

                Images.SaveImageProductToStream(imgFullWatermark, response.OutputStream);
            }
        }
    }

    // ���������� ������� ��������� ��������� ������� ��� ����������
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

    // ���������� ������� ��������� ��������� ������� ��� ����������
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

    // ���������� ������� ��������� ��������� ������� ��� ��������������
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
        /// ������������ ������ ����������� � Response 
        /// </summary> 
        public override void Write(byte[] buffer, int offset, int count)
        {
            //��������������� ������ ���� � ������ 
            //string s = System.Text.Encoding.UTF8.GetString(buffer);
            string s = System.Text.Encoding.Default.GetString(buffer);
            //��������� ���������� ��������� ������� ��� �������� ������� 
            s = Regex.Replace(s, ">(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}(\r\n){0,10} {0,20}(\r\n){0,10} {0,20}<", "><", RegexOptions.Compiled);
            s = Regex.Replace(s, ";(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}", ";", RegexOptions.Compiled);
            s = Regex.Replace(s, "{(\r\n){0,10} {0,20}\t{0,10}(\r\n){0,10}\t{0,10}", "{", RegexOptions.Compiled);
            s = Regex.Replace(s, ">(\r\n){0,10}\t{0,10}<", "><", RegexOptions.Compiled);
            s = Regex.Replace(s, ">\r{0,10}\t{0,10}<", "><", RegexOptions.Compiled);
            //������������ ������ ��������������� ������� � byte 
            //byte[] outdata = System.Text.Encoding.UTF8.GetBytes(s);
            byte[] outdata = System.Text.Encoding.Default.GetBytes(s);
            //���������� �� � Response 
            _HTML.Write(outdata, 0, outdata.Length);
        }
    }
}
