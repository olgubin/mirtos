using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.BLL.Store
{
    public enum StatusCode : int
    {
        WaitingForPayment = 1,
        Confirmed = 2,
        Verified = 3
    }

    public enum PaymentMethod : int
    {
        Cash = 0,
        Translation = 1,
        Wire = 2
    }
}