using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectProductTypeControl : System.Web.UI.UserControl
    {
        private int productTypeId;
        public int ProductTypeId
        {
            get
            {
                return int.Parse(this.ddlProductTypes.SelectedItem.Value);
            }
            set
            {
                this.productTypeId = value;
                this.ddlProductTypes.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlProductTypes.Items.Clear();

            ProductTypeCollection productTypeCollection = ProductTypeManager.GetProductTypes();

            ddlProductTypes.DataSource = productTypeCollection;

            this.ddlProductTypes.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlProductTypes.CssClass;
            }
            set
            {
                ddlProductTypes.CssClass = value;
            }
        }
    }
}