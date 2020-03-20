using System;
using System.Web.UI.WebControls;
using UC.BLL.Store;

namespace UC.UI.Admin.Controls
{
    public partial class SelectCurrencyControl : System.Web.UI.UserControl
    {
        private int selectedCurrencyId;
        public int SelectedCurrencyId
        {
            get
            {
                return int.Parse(this.ddlCurrencies.SelectedItem.Value);
            }
            set
            {
                this.selectedCurrencyId = value;
                this.ddlCurrencies.SelectedValue = value.ToString();
            }
        }

        public void BindData()
        {
            ddlCurrencies.Items.Clear();

            CurrencyCollection currencyCollection = CurrencyManager.GetCurrencies();

            ddlCurrencies.DataSource = currencyCollection;

            this.ddlCurrencies.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlCurrencies.CssClass;
            }
            set
            {
                ddlCurrencies.CssClass = value;
            }
        }
    }
}