using System;
using System.Collections.Generic;
using System.Text;
using UC.Core;

namespace UC.BLL.Store
{
    /// <summary>
    /// Соответствие товаров разделам каталога
    /// </summary>
    public class ProductDepartmentMapping : BaseEntity
    {
        public ProductDepartmentMapping()
        {
        }

        public int ProductDepartmentID { get; set; }

        public int ProductID { get; set; }

        public int DepartmentID { get; set; }

        public int DisplayOrder { get; set; }

        public Department Department
        {
            get
            {
                return DepartmentManager.GetByDepartmentID(DepartmentID);
            }
        }

        public Product Product
        {
            get
            {
                return ProductManager.GetByProductID(ProductID);
            }
        }
    }

}
