using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.Core;

namespace UC.BLL.Store
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public int ProductID { get; set; }
        public string Title 
        {
            get
            {
                if (ProductType != null)
                {
                    string productType = ProductType != null ? ProductType.Type + " " : "";

                    string vendor = Manufacturer != null ? Manufacturer.Title + " " : "";

                    return productType + vendor + Model;
                }
                else
                {
                    return Model;
                }
            }
        }
        public int ProductTypeID { get; set; }
        public string Model { get; set; }
        public string ShortDescription { get; set; }
        public int ManufacturerID { get; set; }
        public string SKU { get; set; }
        public int CurrencyID { get; set; }
        public decimal UnitPrice { get; set; } 
        public int MarginPercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int UnitsInStock { get; set; }
        public string SmallImageUrl { get; set; }
        public string FullImageUrl { get; set; }
        public int Votes { get; set; }
        public int TotalRating { get; set; }
        public bool Visible { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }

        public string LongDescription
        {
            get { return ProductManager.GetProductLongDescription(ProductID); }
        }

        public decimal Price
        {
            get
            {
                    return this.UnitPrice + (this.UnitPrice * this.MarginPercentage / 100);
            }
        }

        public decimal FinalPrice
        {
            get
            {
                if (this.DiscountPercentage > 0)
                    return this.Price - (this.Price * this.DiscountPercentage / 100);
                else
                    return this.Price;
            }
        }

        public double AverageRating
        {
            get
            {
                if (this.Votes >= 1)
                    return ((double)this.TotalRating / (double)this.Votes);
                else
                    return 0.0;
            }
        }

        /// <summary>
        /// Получает связанные товары
        /// </summary>
        public ProductRelatedCollection ProductRelated
        {
            get
            {
                return ProductRelatedManager.GetProductRelatedByProductID1(ProductID);
            }
        }

        /// <summary>
        /// Получает ссылки на разделы товаров
        /// </summary>
        public ProductDepartmentMappingCollection ProductDepartments
        {
            get
            {
                return ProductDepartmentMappingManager.GetProductDepartmentMappingByProductID(ProductID);
            }
        }

        /// <summary>
        /// Получает производителя
        /// </summary>
        public Manufacturer Manufacturer
        {
            get
            {
                return ManufacturerManager.GetManufacturerByID(ManufacturerID);
            }
        }

        /// <summary>
        /// Получает производителя
        /// </summary>
        public ProductType ProductType
        {
            get
            {
                return ProductTypeManager.GetByProductTypeID(ProductTypeID);
            }
        }

        /// <summary>
        /// Получает список характеристик товаров
        /// </summary>
        public ProductAttributeMappingCollection ProductAttributes
        {
            get
            {
                return ProductAttributeMappingManager.GetProductAttributeMappingByProductID(ProductID);
            }
        }

        /// <summary>
        /// Gets the currency
        /// </summary>
        public Currency Currency
        {
            get
            {
                return CurrencyManager.GetByCurrencyID(CurrencyID);
            }
        }
    }
}
