using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// ������������ ��������� ��������������� �������
    /// </summary>
    public class ProductFeaturedCollection : BaseEntityCollection<ProductFeatured>
    {
        public ProductFeatured FindProductFeatured(int ProductID)
        {
            foreach (ProductFeatured productFeatured in this)
                if (productFeatured.ProductID == ProductID)
                    return productFeatured;
            return null;
        }
    }
}
