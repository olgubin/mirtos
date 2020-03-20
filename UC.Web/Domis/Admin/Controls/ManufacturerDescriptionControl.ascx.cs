using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using FredCK.FCKeditorV2;
using UC.Core;
using UC.BLL.Store;
using UC.BLL.Images;

namespace UC.UI.Admin.Controls
{
    public partial class ManufacturerDescriptionControl : System.Web.UI.UserControl
    {
        public delegate void ItemInsertedEventHandler(object sender);
        public event ItemInsertedEventHandler ItemInserted;

        public delegate void ItemUpdatedEventHandler(object sender);
        public event ItemUpdatedEventHandler ItemUpdated;

        public delegate void ItemDeletedEventHandler(object sender);
        public event ItemDeletedEventHandler ItemDeleted;

        public delegate void ItemCancelEventHandler(object sender);
        public event ItemCancelEventHandler ItemCancel;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dvwManufacturer_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            if (ItemInserted != null)
            {
                ItemInserted(this);
            }
        }

        protected void dvwManufacturer_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (ItemUpdated != null)
            {
                ItemUpdated(this);
            }
        }

        protected void dvwManufacturer_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            dvwManufacturer.ChangeMode(DetailsViewMode.Insert);

            if (ItemDeleted != null)
            {
                ItemDeleted(this);
            }
        }

        protected void dvwManufacturer_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                if (ItemCancel != null)
                {
                    ItemCancel(this);
                }
            }
        }

        public void ChangeMode(DetailsViewMode newMode)
        {
            dvwManufacturer.ChangeMode(newMode);
        }

        protected void dvwManufacturer_ItemCreated(object sender, EventArgs e)
        {
            SelectArticleControl ddlArticle = dvwManufacturer.FindControl("ddlArticle") as SelectArticleControl;
            if (ddlArticle != null)
                ddlArticle.BindData();

            if (dvwManufacturer.CurrentMode == DetailsViewMode.Insert)
            {
                TextBox txtImportance = dvwManufacturer.FindControl("txtImportance") as TextBox;
                txtImportance.Text = "0";
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

                        string[] file = imgUpload.FileName.Split('.');
                        string filename = file[0];
                        lblImgUrl.Text = "~/Images/Brands/" + Images.GetImageUrlByStream(filename, AppDomain.CurrentDomain.BaseDirectory + "Images\\Brands\\", img, 87, 87);
                    }
                }
                catch { }
            }
        }
    }
}
