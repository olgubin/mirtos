using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    public class ProductDepartmentMappingCollection : BaseEntityCollection<ProductDepartmentMapping>
    {
        /// <summary>
        /// Возвращает связь Раздела и Товара
        /// </summary>
        /// <param name="ProductID">Идентификатор товара</param>
        /// <param name="CategoryID">Идентификатор раздела</param>
        /// <returns>A ProductCategory that has the specified values; otherwise null</returns>
        public ProductDepartmentMapping FindProductDepartment(int ProductID, int DepartmentID)
        {
            foreach (ProductDepartmentMapping productDepartment in this)
                if (productDepartment.ProductID == ProductID && productDepartment.DepartmentID == DepartmentID)
                    return productDepartment;
            return null;
        }
    }
}
