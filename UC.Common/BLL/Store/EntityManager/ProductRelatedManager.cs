using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Web;
using UC.BLL.Store;
using UC.DAL.Store;

namespace UC.BLL.Store
{
    /// <summary>
    /// Менеджер связанных товаров
    /// </summary>
    public class ProductRelatedManager
    {
        public static void DeleteProductRelated(int ProductRelatedID)
        {
            SqlProductedRelatedProvider.DeleteProductRelated(ProductRelatedID);
        }

        public static ProductRelatedCollection GetProductRelatedByProductID1(int ProductID1)
        {
            bool showHidden = HttpContext.Current.User.IsInRole("Administrator");
            return SqlProductedRelatedProvider.GetProductRelatedByProductID1(ProductID1, showHidden);
        }

        public static ProductRelated GetByProductRelatedID(int RelatedProductID)
        {
            return SqlProductedRelatedProvider.GetByProductRelatedID(RelatedProductID);
        }

        public static ProductRelated InsertProductRelated(int ProductID1, int ProductID2, int DisplayOrder)
        {
            return SqlProductedRelatedProvider.InsertProductRelated(ProductID1, ProductID2, DisplayOrder);
        }

        public static ProductRelated UpdateProductRelated(int ProductRelatedID, int ProductID1, int ProductID2,
            int DisplayOrder)
        {
            return SqlProductedRelatedProvider.UpdateProductRelated(ProductRelatedID, ProductID1, ProductID2, DisplayOrder);
        }
    }
}
