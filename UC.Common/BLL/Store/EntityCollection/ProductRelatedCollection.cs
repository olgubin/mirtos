using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Представляет коллекцию свзанных товраов
    /// </summary>
    public class ProductRelatedCollection : BaseEntityCollection<ProductRelated>
    {
        /// <summary>
        /// Ищет связанные товары по указаным идентификаторам
        /// </summary>
        /// <param name="ProductID1">идентификатор первого товара</param>
        /// <param name="ProductID2">идентификатор второго товара</param>
        /// <returns>найденный связанный товар</returns>
        public ProductRelated FindRelatedProduct(int ProductID1, int ProductID2)
        {
            foreach (ProductRelated relatedProduct in this)
                if (relatedProduct.ProductID1 == ProductID1 && relatedProduct.ProductID2 == ProductID2)
                    return relatedProduct;
            return null;
        }
    }
}
