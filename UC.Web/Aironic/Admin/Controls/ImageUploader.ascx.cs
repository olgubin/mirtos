using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using UC.BLL.Images;

namespace UC.UI.Admin.Controls
{
    public partial class ImageUploader : System.Web.UI.UserControl
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _absoluteUrl;
        public string AbsoluteUrl
        {
            get { return _absoluteUrl; }
            set { _absoluteUrl = value; }
        }

        /// <summary>
        /// Загружает изображение по ссылке в указанную папку
        /// и возвращает относительную ссылку на изображение
        /// </summary>
        protected void btnUrlUpload_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtImageUrl.Text))
            {
                string filename = DateTime.Now.Ticks.ToString();
                lblImgUrl.Text = "~/" + Url + Images.GetImageUrl(filename, AppDomain.CurrentDomain.BaseDirectory + AbsoluteUrl, txtImageUrl.Text.Trim());

                txtImageUrl.Text = "";
            }
        }

        /// <summary>
        /// Загружает изображение из файла в указанную папку
        /// и возвращает относительную ссылку на изображение
        /// </summary>
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            if (imgUpload.PostedFile != null && imgUpload.PostedFile.ContentLength > 0)
            {
                try
                {
                    Stream stream = imgUpload.PostedFile.InputStream;

                    if (stream != null)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                        string filename = DateTime.Now.Ticks.ToString();
                        lblImgUrl.Text = "~/" + Url + Images.GetImageUrlByStream(filename, AppDomain.CurrentDomain.BaseDirectory + AbsoluteUrl, img);
                    }
                }
                catch { }
            }
        }
    }
}
