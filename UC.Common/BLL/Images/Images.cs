using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Web;

namespace UC.BLL.Images
{
    public class Images
    {
        /***********************************
        * Static methods
        ************************************/

        /// <summary>
        /// Перегрузка метода, принимает на вход размеры к которым нужно преобразовать исходное
        /// изображение
        /// </summary>
        /// <param name="imgName">имя файла изображения (без расширения)</param>
        /// <param name="path">путь папки в которую будет сохранено изображение</param>
        /// <param name="imgOriginal">образ оригинала изображения</param>
        /// <returns>ссылку на изображение</returns>
        public static string GetImageUrlByStream(string imgName, string path, Image imgOriginal, int width, int height)
        {
            string imgUrl = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Image imgSmallResize = Images.ResizeImage(imgOriginal, width, height);
                    Images.SaveImageToFile(imgSmallResize, path, imgName, imgOriginal.RawFormat);
                    imgUrl = imgName + "." + imgFormat;
                }
                else
                {
                    imgUrl = "";
                }
            }
            else
            {
                imgUrl = "";
            }

            return imgUrl;
        }

        /// <summary>
        /// Получает путь к ссылке на рисунок
        /// </summary>
        public static string GetImageUrl(string imgName, string path, string url)
        {
            Image imgOriginal = null;

            if (!String.IsNullOrEmpty(url))
                imgOriginal = Images.GetImageByUrl(url);

            string result = Images.GetImageUrlByStream(imgName, path, imgOriginal);

            if (imgOriginal != null)
                imgOriginal.Dispose();

            return result;
        }

        /// <summary>
        /// Сохраняет маленький рисунок из потока маленький рисунок
        /// </summary>
        public static string GetImageUrlByStream(string imgName, string path, Image imgOriginal)
        {
            string imgUrl = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Images.SaveImageToFile(imgOriginal, path, imgName, imgOriginal.RawFormat);
                    imgUrl = imgName + "." + imgFormat;
                }
                else
                {
                    imgUrl = "";
                }
            }
            else
            {
                imgUrl = "";
            }

            return imgUrl;
        }

        /// <summary>
        /// Преобразовывает картинку к заданному размеру, сохраняет в текущей папке и возвращает путь к ней
        /// </summary>
        public static string GetResizeImageByUrl(string imgName, string sourceUrl, int imageWidth, int imageHeight, string imgUrl, string imgAbsoluteUrl)
        {
            Image imgOriginal = null;

            if (!String.IsNullOrEmpty(sourceUrl))
                imgOriginal = Images.GetImageByUrl(sourceUrl);

            string result = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Image imgSmallResize = Images.ResizeImage(imgOriginal, imageWidth, imageHeight);
                    Images.SaveImageToFile(imgSmallResize, AppDomain.CurrentDomain.BaseDirectory + imgAbsoluteUrl, imgName, imgOriginal.RawFormat);
                    result = "~/" + imgUrl + imgName + "." + imgFormat;
                }
                else
                {
                    result = "";
                }
            }
            else
            {
                result = "";
            }

            if (imgOriginal != null)
                imgOriginal.Dispose();

            return result;
        }

        /// <summary>
        /// Получает путь к ссылке на маленький рисунок
        /// </summary>
        public static string GetSmallImageUrl(string imgName, string url, string watermarkText, int watermarkFontSize, int imageWidth, int imageHeight)
        {
            Image imgOriginal = null;

            if (!String.IsNullOrEmpty(url))
                imgOriginal = Images.GetImageByUrl(url);

            string result = Images.GetSmallImageUrlByStream(imgName, imgOriginal, watermarkText, watermarkFontSize, imageWidth, imageHeight);

            if (imgOriginal != null)
                imgOriginal.Dispose();

            return result;
        }

        /// <summary>
        /// Сохраняет большой рисунок с внешнего сайта и возвращает ссылку на него
        /// </summary>
        public static string GetFullImageUrl(string imgName, string url, string watermarkImagePath, int imageWidth, int imageHeight)
        {
            Image imgOriginal = null;

            if (!String.IsNullOrEmpty(url))
                imgOriginal = Images.GetImageByUrl(url);

            return Images.GetFullImageUrlByStream(imgName, imgOriginal, watermarkImagePath, imageWidth, imageHeight);
        }

        /// <summary>
        /// Сохраняет рисунок с внешнего сайта и возвращает ссылку на него
        /// </summary>
        public static string GetImageUrl(string imgName, string url, int imageWidth, int imageHeight)
        {
            Image imgOriginal = null;

            if (!String.IsNullOrEmpty(url))
                imgOriginal = Images.GetImageByUrl(url);

            return Images.GetImageUrlByStream(imgName, imgOriginal, imageWidth, imageHeight);
        }

        /// <summary>
        /// Сохраняет большой рисунок с внешнего сайта и возвращает ссылку на него
        /// </summary>
        public static string GetImageUrlByStream(string imgName, Image imgOriginal, int imageWidth, int imageHeight)
        {
            string imgUrl = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Image imgFullResize = Images.ResizeImage(imgOriginal, imageWidth, imageHeight);
                    Images.SaveImageToFile(imgFullResize, AppDomain.CurrentDomain.BaseDirectory + "Images\\Store\\", imgName + "_full", imgOriginal.RawFormat);
                    imgUrl = "~/Images/Store/" + imgName + "_full." + imgFormat;
                }
                else
                {
                    imgUrl = "";
                }
            }
            else
            {
                imgUrl = "";
            }

            return imgUrl;
        }



        /// <summary>
        /// Сохраняет маленький рисунок из потока маленький рисунок
        /// </summary>
        public static string GetSmallImageUrlByStream(string imgName, Image imgOriginal, string watermarkText, int watermarkFontSize, int imageWidth, int imageHeight)
        {
            string imgUrl = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Image imgSmallResize = Images.ResizeImage(imgOriginal, imageWidth, imageHeight);
                    Image imgSmallText = Images.InsertText(imgSmallResize, @watermarkText, watermarkFontSize);
                    Images.SaveImageToFile(imgSmallText, AppDomain.CurrentDomain.BaseDirectory + "Images\\Store\\", imgName + "_small", imgOriginal.RawFormat);
                    imgUrl = "~/Images/Store/" + imgName + "_small." + imgFormat;
                }
                else
                {
                    imgUrl = "";
                }
            }
            else
            {
                imgUrl = "";
            }

            return imgUrl;
        }

        /// <summary>
        /// Сохраняет большой рисунок с внешнего сайта и возвращает ссылку на него
        /// </summary>
        public static string GetFullImageUrlByStream(string imgName, Image imgOriginal, string watermarkImagePath, int imageWidth, int imageHeight)
        {
            string imgUrl = "";
            string imgFormat = "";

            if (imgOriginal != null)
            {
                imgFormat = Images.GetImageFormat(imgOriginal.RawFormat);

                if (imgFormat != "")
                {
                    Image imgFullResize = Images.ResizeImage(imgOriginal, imageWidth, imageHeight);
                    //получение изображения маски
                    Image imgFullMark = Images.GetImageByFile(AppDomain.CurrentDomain.BaseDirectory + watermarkImagePath);
                    Image imgFullWatermark = Images.InsertWatermak(imgFullResize, imgFullMark, 1.0f);
                    Images.SaveImageToFile(imgFullWatermark, AppDomain.CurrentDomain.BaseDirectory + "Images\\Store\\", imgName + "_full", imgOriginal.RawFormat);
                    imgUrl = "~/Images/Store/" + imgName + "_full." + imgFormat;
                }
                else
                {
                    imgUrl = "";
                }
            }
            else
            {
                imgUrl = "";
            }

            return imgUrl;
        }

        /// <summary>
        /// Удаляет изображение по имени файл формат "~/..."
        /// </summary>
        public static void DeleteImageByUrl(string imgName)
        {
            if (!String.IsNullOrEmpty(imgName))
            {
                try
                {
                    imgName = imgName.Remove(0, 2);
                    imgName = imgName.Replace('/', '\\');
                    imgName = AppDomain.CurrentDomain.BaseDirectory + imgName;
                    File.Delete(imgName);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Получает объект типа Image по переданному url на файл
        /// </summary>
        public static Image GetImageByUrl(string url)
        {
            Image result = null;

            try
            {
                //запрос на получение картинки
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; strbot/2.1;)";
                myHttpWebRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                myHttpWebRequest.Headers.Add("Accept-Language", "ru");

                //получение ответа
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                //записываем полученные данные в поток
                Stream stream = myHttpWebResponse.GetResponseStream();

                result = Image.FromStream(stream);
            }
            catch
            {
                result = null;
            }

            return result;
        }

        /// <summary>
        /// Получает объект типа Image по указанному пути из файла
        /// </summary>
        public static Image GetImageByFile(string pathFile)
        {
            return new Bitmap(pathFile);
        }

        /// <summary>
        /// Изменяет размер изображения
        /// </summary>
        public static Image ResizeImage(Image imgOriginal, int width, int height)
        {
            Image imgResize = new Bitmap(width, height);

            Graphics graphic = Graphics.FromImage(imgResize);

            graphic.FillRectangle(Brushes.White, 0, 0, width, height); //заполняем белым цветом

            //определяем новые высоту и ширину у источника изображения
            float srcHeight, srcWidth;
            float x, y;
            if ((float)imgOriginal.Height / (float)height > (float)imgOriginal.Width / (float)width)
            {
                srcHeight = height;
                srcWidth = imgOriginal.Width * ((float)height / (float)imgOriginal.Height);
                y = 0;
                x = ((float)width - srcWidth) / 2;
            }
            else
            {
                srcWidth = width;
                srcHeight = imgOriginal.Height * ((float)width / (float)imgOriginal.Width);
                y = ((float)height - srcHeight) / 2;
                x = 0;
            }

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;

            graphic.DrawImage(imgOriginal, x, y, srcWidth, srcHeight);

            graphic.Dispose();

            return imgResize;
        }

        /// <summary>
        /// Добавляет в объект Image текст, который размещается внизу посередине, размер шрифта подбирается автоматически
        /// </summary>
        public static Image InsertText(Image imgOriginal, string text, int fontSize)
        {
            Image img = new Bitmap(imgOriginal);

            Graphics graphic = Graphics.FromImage(img);

            //устанавливаем качество рисования на объекте Graphics
            graphic.SmoothingMode = SmoothingMode.AntiAlias;

            //Draws the photo Image object at original size to the graphics object.
            //grPhoto.DrawImage(
            //    imgPhoto,                               // Photo Image object
            //    new Rectangle(0, 0, phWidth, phHeight), // Rectangle structure
            //    0,                                      // x-coordinate of the portion of the source image to draw. 
            //    0,                                      // y-coordinate of the portion of the source image to draw. 
            //    phWidth,                                // Width of the portion of the source image to draw. 
            //    phHeight,                               // Height of the portion of the source image to draw. 
            //    GraphicsUnit.Pixel);                    // Units of measure 

            //-------------------------------------------------------
            //to maximize the size of the Copyright message we will 
            //test multiple Font sizes to determine the largest posible 
            //font we can use for the width of the Photograph
            //define an array of point sizes you would like to consider as possiblities
            //-------------------------------------------------------
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };

            Font crFont = null;
            SizeF crSize = new SizeF();

            ////Loop through the defined sizes checking the length of the Copyright string
            ////If its length in pixles is less then the image width choose this Font size.
            //for (int i = 0; i < 7; i++)
            //{
            //    //set a Font object to Arial (i)pt, Bold
            //    crFont = new Font("arial", sizes[i], FontStyle.Bold);
            //    //Measure the Copyright string in this Font
            //    crSize = graphic.MeasureString(text, crFont);

            //    if ((ushort)crSize.Width < (ushort)img.Width)
            //        break;
            //}

            crFont = new Font("arial", fontSize, FontStyle.Bold);

            crSize = graphic.MeasureString(text, crFont);

            //Since all photographs will have varying heights, determine a 
            //position 5% from the bottom of the image
            int yPixlesFromBottom = (int)(img.Height * .05);

            //Now that we have a point size use the Copyrights string height 
            //to determine a y-coordinate to draw the string of the photograph
            float yPosFromBottom = ((img.Height - yPixlesFromBottom) - (crSize.Height / 2)) - 3;

            //Determine its x-coordinate by calculating the center of the width of the image
            float xCenterOfImg = (img.Width / 2);

            //Define the text layout by setting the text alignment to centered
            StringFormat StrFormat = new StringFormat();
            StrFormat.Alignment = StringAlignment.Center;

            //define a Brush which is semi trasparent black (Alpha set to 153)
            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));

            //Draw the Copyright string
            graphic.DrawString(text, crFont, semiTransBrush2, new PointF(xCenterOfImg + 1, yPosFromBottom + 1), StrFormat);

            //define a Brush which is semi trasparent white (Alpha set to 153)
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            //Создание эффекта тени
            graphic.DrawString(text, crFont, semiTransBrush, new PointF(xCenterOfImg, yPosFromBottom), StrFormat);

            graphic.Dispose();

            return img;
        }

        /// <summary>
        /// Накладывает одно изображение на другое, изображение размещается в правом нижнем углу,
        /// opacity - определяет прозрачность накладываемого изображения от 
        /// 0.1f - практически невидивое
        /// 1.0f - отсутствие прозрачности
        /// </summary>
        public static Image InsertWatermak(Image img, Image watermark, float opacity)
        {
            //Создание и прорисовка графического объекта исходным изображением

            int phWidth = img.Width;
            int phHeight = img.Height;

            //..создание Bitmap размером с рисунок на который бедет накладываться изображение
            //Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight);

            bmPhoto.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            //..загрузка Bitmap в объект Graphics
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.SmoothingMode = SmoothingMode.HighQuality;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.CompositingQuality = CompositingQuality.HighQuality;

            //..прорисовка объекта Image оригинального изображения в графический объект
            //grPhoto.DrawImage(
            //    img,                                    // Photo Image object
            //    new Rectangle(0, 0, phWidth, phHeight), // Rectangle structure
            //    0,                                      // x-coordinate of the portion of the source image to draw. 
            //    0,                                      // y-coordinate of the portion of the source image to draw. 
            //    phWidth,                                // Width of the portion of the source image to draw. 
            //    phHeight,                               // Height of the portion of the source image to draw. 
            //    GraphicsUnit.Pixel);                    // Units of measure 

            grPhoto.DrawImage(img, 0, 0);

            //Создание и прорисовка маски

            int wmWidth = watermark.Width;
            int wmHeight = watermark.Height;

            //создание Bitmap основанного на Bitmap ранее измененной фотографии
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            //загрузка этого Bitmap в новый объект Graphic
            Graphics grWatermark = Graphics.FromImage(bmWatermark);

            grWatermark.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grWatermark.SmoothingMode = SmoothingMode.HighQuality;
            grWatermark.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grWatermark.CompositingQuality = CompositingQuality.HighQuality;

            //To achieve a transulcent watermark we will apply (2) color 
            //manipulations by defineing a ImageAttributes object and 
            //seting (2) of its properties.
            ImageAttributes imageAttributes = new ImageAttributes();

            //The first step in manipulating the watermark image is to replace 
            //the background color with one that is trasparent (Alpha=0, R=0, G=0, B=0)
            //to do this we will use a Colormap and use this to define a RemapTable
            ColorMap colorMap = new ColorMap();

            //My watermark was defined with a background of 100% Green this will
            //be the color we search for and replace with transparency
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);

            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            //The second color manipulation is used to change the opacity of the 
            //watermark.  This is done by applying a 5x5 matrix that contains the 
            //coordinates for the RGBA space.  By setting the 3rd row and 3rd column 
            //to 0.3f we achive a level of opacity
            float[][] colorMatrixElements = { 
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},       
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  opacity, 0.0f},        
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};

            ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);

            //For this example we will place the watermark in the upper right
            //hand corner of the photograph. offset down 10 pixels and to the 
            //left 10 pixles

            int xPosOfWm = ((phWidth - wmWidth) - 0);
            int yPosOfWm = phHeight - wmHeight - 0;

            grWatermark.DrawImage(watermark,
                new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight),  //Set the detination Position
                0,                  // x-coordinate of the portion of the source image to draw. 
                0,                  // y-coordinate of the portion of the source image to draw. 
                wmWidth,            // Watermark Width
                wmHeight,		    // Watermark Height
                GraphicsUnit.Pixel, // Unit of measurment
                imageAttributes);   //ImageAttributes Object

            grPhoto.Dispose();
            grWatermark.Dispose();

            return bmWatermark;
        }

        /// <summary>
        /// Сохраняет изображение в файл по указанному пути c указанным именем.
        /// Имя должно передаваться без расширения.
        /// </summary>
        public static void SaveImageToFile(Image imgOriginal, string path, string name, ImageFormat format)
        {
            if (format.Guid == ImageFormat.Gif.Guid)
            {
                using (imgOriginal)
                {
                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap quantized = quantizer.Quantize(imgOriginal))
                    {
                        quantized.Save(path + name + ".gif", ImageFormat.Gif);
                        quantized.Dispose();
                    }
                }
            }
            else  //ImageFormat.Jpeg  ImageFormat.PNG .....
            {
                imgOriginal.Save(path + name + "." + Images.GetImageFormat(format),format);
            }
        }

        /// <summary>
        /// Сохраняет изображение в указанный поток
        /// </summary>
        public static void SaveImageProductToStream(Image imgOriginal, Stream outputStream)
        {
            if (imgOriginal.RawFormat.Guid == ImageFormat.Gif.Guid)
            {
                using (imgOriginal)
                {
                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap quantized = quantizer.Quantize(imgOriginal))
                    {
                        //Response.ContentType = "image/gif";
                        //quantized.Save(Response.OutputStream, ImageFormat.Gif);
                        quantized.Save(outputStream, ImageFormat.Gif);
                    }
                }
            }
            else  //ImageFormat.Jpeg  ImageFormat.PNG .....
            {
                ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                //Response.ContentType = "image/jpeg";
                //thumbnail.Save(Response.OutputStream, info[1], encoderParameters);
                imgOriginal.Save(outputStream, info[1], encoderParameters);
            }
        }

        /// <summary>
        /// Выводит изображение товара со скидкой в поток
        /// </summary>
        public static void SaveSalesProductImageFromFileToStream(string productImagePath, int imageWidth, int imageHeight, 
            string discountImagePath, int discountPercentage, string fontName, int fontSize, Stream outputStream)
        {
                System.Drawing.Image image = System.Drawing.Image.FromFile(productImagePath);

                image = Images.ResizeImage(image, imageWidth, imageHeight);

                Bitmap btmp = new Bitmap(imageWidth, imageHeight);
                Graphics g = Graphics.FromImage(btmp);

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(image, 0, 0, imageWidth, imageHeight);

                System.Drawing.Image discImage = System.Drawing.Image.FromFile(discountImagePath);
                g.DrawImageUnscaled(discImage, 0, 0);

                Font font = new Font(fontName, fontSize);
                SizeF crSize = new SizeF();

                string text = discountPercentage.ToString() + "%";

                crSize = g.MeasureString(text, font);

                g.DrawString(text, font, Brushes.Red, discImage.Width / 2 - crSize.Width / 2 + 2, discImage.Height / 2 - crSize.Height / 2);

                //ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
                //EncoderParameters encoderParameters = new EncoderParameters(1);
                //encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                //btmp.Save(response.OutputStream, info[1], encoderParameters);

                OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                using (Bitmap quantized = quantizer.Quantize(btmp))
                {
                    quantized.Save(outputStream, System.Drawing.Imaging.ImageFormat.Gif);
                }
        }

        /// <summary>
        /// Выводит изображение товара со скидкой в поток
        /// </summary>
        public static void SaveSalesProductImageToStream(Image image, int imageWidth, int imageHeight,
            string discountImagePath, int discountPercentage, string fontName, int fontSize, Stream outputStream)
        {
            image = Images.ResizeImage(image, imageWidth, imageHeight);

            Bitmap btmp = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(btmp);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(image, 0, 0, imageWidth, imageHeight);

            System.Drawing.Image discImage = System.Drawing.Image.FromFile(discountImagePath);
            g.DrawImageUnscaled(discImage, 0, 0);

            Font font = new Font(fontName, fontSize);
            SizeF crSize = new SizeF();

            string text = discountPercentage.ToString() + "%";

            crSize = g.MeasureString(text, font);

            g.DrawString(text, font, Brushes.Red, discImage.Width / 2 - crSize.Width / 2 + 2, discImage.Height / 2 - crSize.Height / 2);

            //ImageCodecInfo[] info = ImageCodecInfo.GetImageEncoders();
            //EncoderParameters encoderParameters = new EncoderParameters(1);
            //encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            //btmp.Save(response.OutputStream, info[1], encoderParameters);

            OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
            using (Bitmap quantized = quantizer.Quantize(btmp))
            {
                quantized.Save(outputStream, System.Drawing.Imaging.ImageFormat.Gif);
            }
        }

        /// <summary>
        /// Выводит изображение товара со скидкой в поток
        /// </summary>
        public static void SaveProductFeaturedImageToStream(Image image, int imageWidth, int imageHeight,
            string discountImagePath, int discountPercentage, string fontName, int fontSize, Stream outputStream)
        {
            image = Images.ResizeImage(image, imageWidth, imageHeight);

            Bitmap btmp = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(btmp);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(image, 0, 0, imageWidth, imageHeight);

            if (discountPercentage > 0)
            {
                System.Drawing.Image discImage = System.Drawing.Image.FromFile(discountImagePath);
                g.DrawImageUnscaled(discImage, 0, 0);

                Font font = new Font(fontName, fontSize);
                SizeF crSize = new SizeF();

                string text = discountPercentage.ToString() + "%";

                crSize = g.MeasureString(text, font);

                g.DrawString(text, font, Brushes.Red, discImage.Width / 2 - crSize.Width / 2 + 2, discImage.Height / 2 - crSize.Height / 2);
            }

            OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
            using (Bitmap quantized = quantizer.Quantize(btmp))
            {
                quantized.Save(outputStream, System.Drawing.Imaging.ImageFormat.Gif);
            }
        }

        /// <summary>
        /// Выводит указанное изображение из файла в указанный поток с заданными размерами
        /// </summary>
        public static void SaveImageFromFileToStream(string imagePath, int imageWidth, int imageHeight, Stream outputStream)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath);

            image = Images.ResizeImage(image, imageWidth, imageHeight);

            Bitmap btmp = new Bitmap(imageWidth, imageHeight);
            Graphics g = Graphics.FromImage(btmp);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.DrawImage(image, 0, 0, imageWidth, imageHeight);

            OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
            using (Bitmap quantized = quantizer.Quantize(btmp))
            {
                quantized.Save(outputStream, System.Drawing.Imaging.ImageFormat.Gif);
            }
        }

        static public string GetImageFormat(ImageFormat format)
        {
            string result = "";
            if (format.Equals(ImageFormat.Bmp)) { result = "bmp"; }
            if (format.Equals(ImageFormat.Emf)) { result = "emf"; }
            if (format.Equals(ImageFormat.Gif)) { result = "gif"; }
            if (format.Equals(ImageFormat.Icon)) { result = "ico"; }
            if (format.Equals(ImageFormat.Jpeg)) { result = "jpg"; }
            if (format.Equals(ImageFormat.Png)) { result = "png"; }
            if (format.Equals(ImageFormat.Tiff)) { result = "tiff"; }
            if (format.Equals(ImageFormat.Wmf)) { result = "wmf"; }

            return result;
        }
    }
}
