using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Представляет связанный товар
    /// </summary>
    public class ProductRelated : BaseEntity
    {
        public ProductRelated()
        {
        }

        public int ProductRelatedID { get; set; }
        public int ProductID1 { get; set; }
        public int ProductID2 { get; set; }
        public int DisplayOrder { get; set; }

        public Product Product1
        {
            get
            {
                return ProductManager.GetByProductID(ProductID1);
            }
        }

        public Product Product2
        {
            get
            {
                return ProductManager.GetByProductID(ProductID2);
            }
        }
    }

}
