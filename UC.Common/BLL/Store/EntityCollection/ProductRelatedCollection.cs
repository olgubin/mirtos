using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// ������������ ��������� �������� �������
    /// </summary>
    public class ProductRelatedCollection : BaseEntityCollection<ProductRelated>
    {
        /// <summary>
        /// ���� ��������� ������ �� �������� ���������������
        /// </summary>
        /// <param name="ProductID1">������������� ������� ������</param>
        /// <param name="ProductID2">������������� ������� ������</param>
        /// <returns>��������� ��������� �����</returns>
        public ProductRelated FindRelatedProduct(int ProductID1, int ProductID2)
        {
            foreach (ProductRelated relatedProduct in this)
                if (relatedProduct.ProductID1 == ProductID1 && relatedProduct.ProductID2 == ProductID2)
                    return relatedProduct;
            return null;
        }
    }
}
