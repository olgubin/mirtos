using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using UC;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class ProductView : BaseWebPart
    {
        private int _productID = 0;
        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _manufacturerID = 0;
        public int ManufacturerID
        {
            get { return _manufacturerID; }
            set { _manufacturerID = value; }
        }

        private string _manufacturerTitle = "";
        public string ManufacturerTitle
        {
            get { return _manufacturerTitle; }
            set { _manufacturerTitle = value; }
        }

        private string _sku = "";
        public string SKU
        {
            get { return _sku; }
            set { _sku = value; }
        }

        private string _imageURL = "";
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }

        private int _discountPercentage = 0;
        public int DiscountPercentage
        {
            get { return _discountPercentage; }
            set { _discountPercentage = value; }
        }

        private decimal _unitPrice = 0.0m;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        private decimal _finalUnitPrice = 0.0m;
        public decimal FinalUnitPrice
        {
            get { return _finalUnitPrice; }
            set { _finalUnitPrice = value; }
        }

        private string _shortDescription = "";
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { _shortDescription = value; }
        }

        private int _votes = 0;
        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        private double _averageRating = 0;
        public double AverageRating
        {
            get { return _averageRating; }
            set { _averageRating = value; }
        }

        private bool _visisbleAddToCart = true;
        public bool VisisbleAddToCart
        {
            get { return _visisbleAddToCart; }
            set { _visisbleAddToCart = value; }
        }

        private int _unitsInStock = 0;
        public int UnitsInStock
        {
            get { return _unitsInStock; }
            set { _unitsInStock = value; }
        }

        public Color TxtQuantityColor
        {
            set 
            { 
                txtQuantity.ForeColor = value;
                txtQuantityOrder.ForeColor = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }
    }
}