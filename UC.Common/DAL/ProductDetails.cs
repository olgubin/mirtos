using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.DAL
{
    public class ProductDetails
    {
        public ProductDetails() { }

        public ProductDetails(int id, DateTime addedDate, string addedBy,
           string departmentTitle, string title, int manufacturerID, string manufacturerTitle, 
            string shortDescription, string longDescription, string sku, decimal unitPrice, int discountPercentage, 
            int unitsInStock, string smallImageUrl, string fullImageUrl, int votes, int totalRating, bool visible)
        {
            this.ID = id;
            this.AddedDate = addedDate;
            this.AddedBy = addedBy;
            //this.DepartmentID = departmentID;
            this.DepartmentTitle = departmentTitle;
            this.Title = title;
            this.ManufacturerID = manufacturerID;
            this.ManufacturerTitle = manufacturerTitle;
            this.ShortDescription = shortDescription;
            this.LongDescription = longDescription;
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.DiscountPercentage = discountPercentage;
            this.UnitsInStock = unitsInStock;
            this.SmallImageUrl = smallImageUrl;
            this.FullImageUrl = fullImageUrl;
            this.Votes = votes;
            this.TotalRating = totalRating;
            this.Visible = visible;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        private string _addedBy = "";
        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        //private int _departmentID = 0;
        //public int DepartmentID
        //{
        //    get { return _departmentID; }
        //    set { _departmentID = value; }
        //}

        private string _departmentTitle = "";
        public string DepartmentTitle
        {
            get { return _departmentTitle; }
            set { _departmentTitle = value; }
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

        private string _shortDescription = "";
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { _shortDescription = value; }
        }

        private string _longDescription = "";
        public string LongDescription
        {
            get { return _longDescription; }
            set { _longDescription = value; }
        }

        private string _sku = "";
        public string SKU
        {
            get { return _sku; }
            set { _sku = value; }
        }

        private decimal _unitPrice = 0.0m;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        private int _discountPercentage = 0;
        public int DiscountPercentage
        {
            get { return _discountPercentage; }
            set { _discountPercentage = value; }
        }

        private int _unitsInStock = 0;
        public int UnitsInStock
        {
            get { return _unitsInStock; }
            set { _unitsInStock = value; }
        }

        private string _smallImageUrl = "";
        public string SmallImageUrl
        {
            get { return _smallImageUrl; }
            set { _smallImageUrl = value; }
        }

        private string _fullImageUrl = "";
        public string FullImageUrl
        {
            get { return _fullImageUrl; }
            set { _fullImageUrl = value; }
        }

        private int _votes = 0;
        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        private int _totalRating = 0;
        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        private bool _visible = true;
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
    }
}