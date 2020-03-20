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
    public class ProductAttributeMapping : BaseEntity
    {
        public ProductAttributeMapping()
        {
        }

        public int ProductAttributeMappingID { get; set; }
        public int ProductID { get; set; }
        public int ProductAttributeID { get; set; }
        public string AttributeValue { get; set; }
        public int DisplayOrder { get; set; }
        public bool DisplayInShort { get; set; }

        /// <summary>
        /// Возвращает характеристику
        /// </summary>
        public ProductAttribute ProductAttribute
        {
            get
            {
                return ProductAttributeManager.GetByProductAttributeID(ProductAttributeID);
            }
        }

        ///// <summary>
        ///// Получает продукт
        ///// </summary>
        //public Product Product
        //{
        //    get
        //    {
        //        return ProductManager.GetByProductID(ProductID);
        //    }
        //}
    }

}
