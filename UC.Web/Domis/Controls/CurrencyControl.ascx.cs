using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using UC.BLL.Store;

namespace UC.UI.Controls
{
    public partial class CurrencyControl : System.Web.UI.UserControl
    {
        public bool Caption_Visible
        {
            set
            {
                pnlCaption.Visible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindCurrency(CurrencyManager.WorkingCurrency.CurrencyID);
            }
        }

        protected void BindCurrency(int CurrencyID)
        {
            switch (CurrencyID)
            {
                case 1:
                    {
                        imgbtnRUR.ImageUrl = "~/Images/rur_a.gif";
                        imgbtnUSD.ImageUrl = "~/Images/usd_n.gif";
                        imgbtnEUR.ImageUrl = "~/Images/eur_n.gif";
                        break;
                    }
                case 2:
                    {
                        imgbtnRUR.ImageUrl = "~/Images/rur_n.gif";
                        imgbtnUSD.ImageUrl = "~/Images/usd_a.gif";
                        imgbtnEUR.ImageUrl = "~/Images/eur_n.gif";
                        break;
                    }
                case 3:
                    {
                        imgbtnRUR.ImageUrl = "~/Images/rur_n.gif";
                        imgbtnUSD.ImageUrl = "~/Images/usd_n.gif";
                        imgbtnEUR.ImageUrl = "~/Images/eur_a.gif";
                        break;
                    }
            }
        }

        protected void CurrencyChange(Object sender, CommandEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.CommandName))
            {
                switch (e.CommandName)
                {
                    case "RUR":
                        {
                            CurrencyManager.WorkingCurrency = CurrencyManager.GetByCurrencyID(1);
                            BindCurrency(1);
                            break;
                        }
                    case "USD":
                        {
                            CurrencyManager.WorkingCurrency = CurrencyManager.GetByCurrencyID(2);
                            BindCurrency(2);
                            break;
                        }
                    case "EUR":
                        {
                            CurrencyManager.WorkingCurrency = CurrencyManager.GetByCurrencyID(3);
                            BindCurrency(3);
                            break;
                        }
                }

                string URL = HttpContext.Current.Request.RawUrl;
                HttpContext.Current.Response.Redirect(URL);
            }
        }
    }
}
