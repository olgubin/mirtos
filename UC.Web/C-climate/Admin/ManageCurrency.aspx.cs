using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using UC;
using UC.BLL.Store;
using UC.UI.Admin.Controls;

namespace UC.UI.Admin
{
    public partial class ManageCurrency : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvwCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwCurrency.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwCurrencies_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            gvwCurrencies.SelectedIndex = -1;
            gvwCurrencies.DataBind();
            dvwCurrency.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwCurrencies_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton btn = e.Row.Cells[7].Controls[0] as ImageButton;
                btn.OnClientClick = "if (confirm('Подтвердите удаление') == false) return false;";
            }
        }

        protected void dvwCurrency_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            gvwCurrencies.SelectedIndex = -1;
            gvwCurrencies.DataBind();
        }

        protected void dvwCurrency_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            gvwCurrencies.SelectedIndex = -1;
            gvwCurrencies.DataBind();
        }

        protected void dvwCurrency_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                gvwCurrencies.SelectedIndex = -1;
                gvwCurrencies.DataBind();
            }
        }

        protected void rdbIsPrimaryCurrency_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvwCurrencies.Rows)
            {
                RadioButton rdbIsPrimaryCurrency = (RadioButton)row.FindControl("rdbIsPrimaryCurrency");
                HiddenField hfCurrencyID = (HiddenField)row.FindControl("hfCurrencyID");
                int currencyID = int.Parse(hfCurrencyID.Value);
                if (rdbIsPrimaryCurrency == sender)
                    CurrencyManager.PrimaryCurrency = CurrencyManager.GetByCurrencyID(currencyID);
            }

            gvwCurrencies.DataBind();
        }
    }
}
