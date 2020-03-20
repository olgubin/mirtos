using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Представляет связанный товар
    /// </summary>
    public class ProductFeatured : BaseEntity
    {
        public ProductFeatured()
        {
        }

        public int ProductFeaturedID { get; set; }
        public int ProductID { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public Product Product
        {
            get
            {
                return ProductManager.GetByProductID(ProductID);
            }
        }
    }
}
