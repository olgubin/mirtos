using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectProductControl : System.Web.UI.UserControl
    {
        private int selectedProductId;
        public int SelectedProductId
        {
            get
            {
                return int.Parse(this.ddlProducts.SelectedItem.Value);
            }
            set
            {
                this.selectedProductId = value;
                this.ddlProducts.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlProducts.Items.Clear();

            ProductCollection productCollection = ProductManager.GetAllProducts(false);

            ddlProducts.DataSource = productCollection;

            this.ddlProducts.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public string CssClass
        {
            get
            {
                return ddlProducts.CssClass;
            }
            set
            {
                ddlProducts.CssClass = value;
            }
        }
    }
}