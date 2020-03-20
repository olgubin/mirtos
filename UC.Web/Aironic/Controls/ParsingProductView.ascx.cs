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
using UC;
using UC.UI;

namespace UC.UI.Controls
{
    public partial class ParsingProductView : BaseWebPart
    {
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _navigateURL = "";
        public string NavigateURL
        {
            get { return _navigateURL; }
            set { _navigateURL = value; }
        }

        private string _departmentTitle = "";
        public string DepartmentTitle
        {
            get { return _departmentTitle; }
            set { _departmentTitle = value; }
        }

        private string _SKU = "";
        public string SKU
        {
            get { return _SKU; }
            set { _SKU = value; }
        }

        private string _error = "";
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
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

        private bool _isDeleted = false;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
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

        private string _shortDescription = "";
        public string ShortDescription
        {
            get { return _shortDescription; }
            set { _shortDescription = value; }
        }

        private int _totalRating = 0;
        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }
    }
}