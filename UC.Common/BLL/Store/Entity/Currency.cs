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
    public class Currency : BaseEntity
    {
        public Currency()
        {
        }
        public int CurrencyID { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }

        public bool IsPrimaryCurrency
        {
            get
            {
                Currency activePrimaryCurrency = CurrencyManager.PrimaryCurrency;
                return ((activePrimaryCurrency != null && activePrimaryCurrency.CurrencyID == CurrencyID));
            }
        }
    }
}