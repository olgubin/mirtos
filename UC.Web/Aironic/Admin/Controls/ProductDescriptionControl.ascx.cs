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
using FredCK.FCKeditorV2;
using UC.BLL.Store;
using UC.BLL.Images;

namespace UC.UI.Admin.Controls
{
    public partial class ProductDescriptionControl : System.Web.UI.UserControl
    {
        public int ProductID
        {
            get
            {
                if (!String.IsNullOrEmpty(this.Request.QueryString["ID"]))
                {
                    string resultStr = this.Request.QueryString["ID"].ToUpperInvariant();
                    int result;
                    Int32.TryParse(resultStr, out result);
                    return result;
                }
                else
                {
                    return 0;
                }
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                {
                    if (Page.User.Identity.IsAuthenticated &&
                       (Page.User.IsInRole("Administrators") || Page.User.IsInRole("Editors")))
                    {
                        dvwProduct.ChangeMode(DetailsViewMode.Edit);
                    }
                }
            }
        }

        protected void dvwProduct_ItemCreated(object sender, EventArgs e)
        {
            string baseUrl = Page.Request.ApplicationPath;
            if (!baseUrl.EndsWith("/"))
                baseUrl = baseUrl + "/";

            Control ctl = dvwProduct.FindControl("txtShortDescription");
            if (ctl != null)
            {
                FCKeditor txtShortDescription = ctl as FCKeditor;
                txtShortDescription.BasePath = baseUrl + "FCKeditor/";
            }

            ctl = dvwProduct.FindControl("txtLongDescription");
            if (ctl != null)
            {
                FCKeditor txtLongDescription = ctl as FCKeditor;
                txtLongDescription.BasePath = baseUrl + "FCKeditor/";
            }
        }

        protected void dvwProduct_DataBound(object sender, EventArgs e)
        {
            // Tn InserMode, set the UnitsInStock to 1000000 and DiscountPercentage to 0
            if (dvwProduct.CurrentMode == DetailsViewMode.Insert)
            {
                (dvwProduct.FindControl("txtUnitsInStock") as TextBox).Text = "1000000";
                (dvwProduct.FindControl("txtDiscountPercentage") as TextBox).Text = "0";
            }
        }

        protected void dvwProduct_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            //После обновления открываем карточку этого товара
            if (e.Keys[0] != null)
            {
                this.Response.Redirect("~/ShowProduct.aspx?ID=" + e.Keys[0].ToString());
            }
        }

        protected void objCurrProduct_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                if (e.ReturnValue != null)
                {
                    Product productRet = (Product)e.ReturnValue;

                    //string SmallImageUrl = "";
                    string FullImageUrl = "";

                    if (!String.IsNullOrEmpty(txtImageUrl.Text))
                    {
                        //SmallImageUrl = Images.GetSmallImageUrl(productRet.ProductID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                        //FullImageUrl = Images.GetFullImageUrl(productRet.ProductID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                        FullImageUrl = Images.GetImageUrl(productRet.ProductID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);

                        //ProductManager.ChangeImageUrl(productRet.ProductID, SmallImageUrl, FullImageUrl);
                        ProductManager.ChangeImageUrl(productRet.ProductID, "", FullImageUrl);
                    }
                    else
                    {
                        if (imgUpload.PostedFile != null && imgUpload.PostedFile.ContentLength > 0)
                        {
                            try
                            {
                                Stream stream = imgUpload.PostedFile.InputStream;

                                if (stream != null)
                                {
                                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                                    //SmallImageUrl = Images.GetSmallImageUrlByStream(productRet.ProductID.ToString(), img, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                                    //FullImageUrl = Images.GetFullImageUrlByStream(productRet.ProductID.ToString(), img, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                                    FullImageUrl = Images.GetImageUrlByStream(productRet.ProductID.ToString(), img, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);

                                    //ProductManager.ChangeImageUrl(productRet.ProductID, SmallImageUrl, FullImageUrl);
                                    ProductManager.ChangeImageUrl(productRet.ProductID, "", FullImageUrl);
                                }
                            }
                            catch { }
                        }
                    }

                    this.Response.Redirect("~/Admin/AddEditProduct.aspx?ID=" + productRet.ProductID.ToString());
                }
            }
        }

        protected void dvwProduct_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (e.Keys[0] != null)
            {
                int productID = (int)e.Keys[0];

                if (!String.IsNullOrEmpty(txtImageUrl.Text))
                {
                    //e.NewValues["smallImageUrl"] = Images.GetSmallImageUrl(productID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                    //e.NewValues["fullImageUrl"] = Images.GetFullImageUrl(productID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                    e.NewValues["fullImageUrl"] =  Images.GetImageUrl(ProductID.ToString(), txtImageUrl.Text.Trim(), Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                }
                else
                {
                    if (imgUpload.PostedFile != null && imgUpload.PostedFile.ContentLength > 0)
                    {
                        try
                        {
                            Stream stream = imgUpload.PostedFile.InputStream;

                            if (stream != null)
                            {
                                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

                                //e.NewValues["smallImageUrl"] = Images.GetSmallImageUrlByStream(productID.ToString(), img, Globals.Settings.Images.WatermarkText, Globals.Settings.Images.WatermarkFontSize, Globals.Settings.Images.SmallImageWidth, Globals.Settings.Images.SmallImageHeight);
                                //e.NewValues["fullImageUrl"] = Images.GetFullImageUrlByStream(productID.ToString(), img, Globals.Settings.Images.WatermarkImagePath, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                                e.NewValues["fullImageUrl"] = Images.GetImageUrlByStream(ProductID.ToString(), img, Globals.Settings.Images.FullImageWidth, Globals.Settings.Images.FullImageHeight);
                            }
                        }
                        catch { }
                    }
                }

            }
        }
    }
}
