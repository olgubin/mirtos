using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC;
using UC.UI;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class ProductAttributes : BaseWebPart
    {
        private bool _isShortDescription = true;
        public bool IsShortDescription
        {
            get { return _isShortDescription; }
            set { _isShortDescription = value; }
        }

        private string _cssClass="";
        public string CssClass
        {
            get
            {
                return _cssClass;
            }
            set
            {
                _cssClass = value;
            }
        }

        private string _cssClassAlt = "";
        public string CssClassAlt
        {
            get
            {
                return _cssClassAlt;
            }
            set
            {
                _cssClassAlt = value;
            }
        }

        private string _padding="0px";
        public string Padding
        {
            get
            {
                return _padding;
            }
            set
            {
                _padding = value;
            }
        }

        public int ProductID
        {
            set
            {
                ProductAttributeMappingCollection productAttributesMapping = null;

                if (IsShortDescription)
                {
                    productAttributesMapping = ProductAttributeMappingManager.GetProductAttributeMappingByProductIDInShort(value);
                }
                else
                {
                    productAttributesMapping = ProductAttributeMappingManager.GetProductAttributeMappingByProductID(value);
                }

                if (productAttributesMapping.Count > 0)
                {
                    repProductAttributeMapping.Visible = true;
                    repProductAttributeMapping.DataSource = productAttributesMapping;
                    repProductAttributeMapping.DataBind();
                }
                else
                    repProductAttributeMapping.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //
        }
    }
}