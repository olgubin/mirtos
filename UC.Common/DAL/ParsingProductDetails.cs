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
    public class ParsingProductDetails
    {
        public ParsingProductDetails() { }

        public ParsingProductDetails(int id, int linkID, string url, int catalogID, DateTime addedDate,
           string departmentTitle, string title, string shortDescription, string longDescription,
           string sku, decimal unitPrice, int discountPercentage, int unitsInStock,
           string smallImageUrl, string fullImageUrl, int totalRating,
           bool isNew, bool isUpdated, bool isDeleted, bool isRestored, string error)
        {
            this.ID = id;  //идентификатор товара в БД каталога, для обновленного товара он равен 0 устанавливается при сравнении на идентификатор товара из каталога
            this.LinkID = linkID; //идентификатор связанного товара из нашей БД
            this.Url = url;
            this.CatalogID = catalogID;
            this.AddedDate = addedDate;
            this.DepartmentTitle = departmentTitle;
            this.Title = title;
            this.ShortDescription = shortDescription;
            this.LongDescription = longDescription;
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.DiscountPercentage = discountPercentage;
            this.UnitsInStock = unitsInStock;
            this.SmallImageUrl = smallImageUrl;
            this.FullImageUrl = fullImageUrl;
            this.TotalRating = totalRating;
            this.IsNew = isNew;
            this.IsDeleted = isDeleted;
            this.IsUpdated = isUpdated;
            this.IsRestored = isRestored;
            this.Error = error;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _linkID = 0;
        public int LinkID
        {
            get { return _linkID; }
            set { _linkID = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private int _catalogID = 0;
        public int CatalogID
        {
            get { return _catalogID; }
            set { _catalogID = value; }
        }

        private DateTime _addedDate = DateTime.Now;
        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

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

        private int _totalRating = 0;
        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        private bool _isUpdated = false;
        public bool IsUpdated
        {
            get { return _isUpdated; }
            set { _isUpdated = value; }
        }

        private bool _isRestored = false;
        public bool IsRestored
        {
            get { return _isRestored; }
            set { _isRestored = value; }
        }

        private string _error = "";
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
    }
}