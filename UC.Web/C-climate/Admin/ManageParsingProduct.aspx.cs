using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security;
using UC;
using UC.BLL.Parsing;
using UC.BLL.Store;

namespace UC.UI
{
    public partial class ManageParsingProduct : BasePage
    {
        int _productID = 0;
        public int ProductID
        {
            get
            {
                if (_productID == 0)
                {
                    // ����� ID ������ �� ������ �������
                    if (string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                        throw new ApplicationException("�� ���� ��������� �������� ������ � ������ �������.");
                    else
                        _productID = int.Parse(this.Request.QueryString["ID"]);

                }
                return _productID;
            }
        }

        int _catalogID = 0;
        public int CatalogID
        {
            get
            {
                if (_catalogID == 0)
                {
                    // ����� ID ������ �� ������ �������
                    if (string.IsNullOrEmpty(this.Request.QueryString["CatalogID"]))
                        throw new ApplicationException("�� ���� ��������� �������� �������� � ������ �������.");
                    else
                        _catalogID = int.Parse(this.Request.QueryString["CatalogID"]);

                }
                return _catalogID;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //�������� ����� � ������������ � ��� ID????, ���� ����� �� ������ ��������� ����������
                ParsingProduct product = ParsingProduct.GetProductByID(CatalogID, ProductID);

                if (product == null)
                    throw new ApplicationException("����� �� ������.");

                // ��������� �������� �� ID �������� ���� �� ����� ������
                ParsingCatalog catalog = ParsingCatalog.GetCatalogByID(CatalogID);
                if (catalog == null)
                    throw new ApplicationException("������� �� ������.");                

                //��������� ����� � ������ � ������� ������ �� �������
                lnkCatalogTitle.Text = catalog.Title;
                lnkCatalogTitle.NavigateUrl = "~/Admin/ManageParsingProducts.aspx?CatalogID=" + CatalogID.ToString();

                //��������� ���� � ��������� ������
                lblTitle.Text = product.Title;

                //������� �������� ������
                //...���������� �������
                //if (product.SmallImageUrl.Length > 0)
                //    imgProduct.ImageUrl = product.SmallImageUrl;
                //if (product.FullImageUrl.Length > 0)
                //{
                //    lnkFullImage.NavigateUrl = product.FullImageUrl;
                //    lnkFullImage.Visible = true;
                //}
                //else
                //    lnkFullImage.Visible = false;

                imgProduct.ImageUrl = product.FullImageUrl;
                lnkFullImage.Visible = false;


                //..���������� ������
                lblDiscountedPrice.Text = string.Format(lblDiscountedPrice.Text, this.FormatPrice(product.UnitPrice));
                pnlDiscountedPrice.Visible = (product.DiscountPercentage > 0);

                //..���������� ����
                lblPrice.Text = this.FormatPrice(product.UnitPrice);

                //..���������� ������� ���� ����



                //..���������� ��������� � �������
                lblDepartmentTitle.Text = product.DepartmentTitle;
                lblSKU.Text = "�������: " + product.SKU;

                //..���������� ������ �� ���� ��������
                lnkURL.Text = product.Url;
                lnkURL.NavigateUrl = product.Url;

                //..���������� ��������
                lblShortDescription.Text = product.ShortDescription;
                lblLongDescription.Text = product.LongDescription;

                //lblRating.Text = string.Format(lblRating.Text, product.Votes);
                //ratDisplay.Value = product.AverageRating;
                //ratDisplay.Visible = (product.Votes > 0);

                //mbRating.Value = product.AverageRating;
                //mbRating.Visible = (product.Votes > 0);
                
                //panEditProduct.Visible = this.UserCanEdit;

                //������ ��������������
                //lnkEditProduct.NavigateUrl = string.Format(lnkEditProduct.NavigateUrl, _productID);
            }
        }

        protected void btnAddToCart_Click(object sender, ImageClickEventArgs e)
        {
            //try
            //{
            //    int quantity = Convert.ToInt32(txtQuantity.Text);

            //    if (quantity > 0)
            //    {
            //        Product product = Product.GetProductByID(_productID);

            //        this.Profile.ShoppingCart.InsertItem(product.ID, product.Title, product.SKU, product.FinalPrice, quantity);

            //        txtQuantity.ForeColor = System.Drawing.Color.Black;
            //    }
            //    else
            //    {
            //        txtQuantity.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
            //catch
            //{
            //    txtQuantity.ForeColor = System.Drawing.Color.Red;
            //}
        }

        protected void btnDelete_Click(object sender, ImageClickEventArgs e)
        {
            //Product.DeleteProduct(_productID);
            //this.Response.Redirect("Departments.aspx", false);
        }
    }
}
