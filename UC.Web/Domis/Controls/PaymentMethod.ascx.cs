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

namespace UC.UI.Controls
{
    public partial class PaymentMethod : System.Web.UI.UserControl
    {
        ProfileCommon _userProfile;
        public ProfileCommon UserProfile
        {
            get 
            {
                if (_userProfile == null)
                {
                    _userProfile = this.Profile;
                    //_userProfile = this.Profile.GetProfile(Page.User.Identity.Name);
                }
                return _userProfile;
            }
            set { _userProfile = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    switch (UserProfile.Payment.PaymentMethod)
                    {
                        case UC.BLL.Store.PaymentMethod.Cash:
                            {
                                rbtnCash.Checked = true;
                                break;
                            }
                        case UC.BLL.Store.PaymentMethod.Translation:
                            {
                                rbtnTranslation.Checked = true;
                                break;
                            }
                        case UC.BLL.Store.PaymentMethod.Wire:
                            {
                                rbtnWire.Checked = true;
                                break;
                            }
                    }
                }
            }
        }

        public void onSave(object sender, EventArgs e)
        {
            if (rbtnCash.Checked) UserProfile.Payment.PaymentMethod = UC.BLL.Store.PaymentMethod.Cash;
            if (rbtnTranslation.Checked) UserProfile.Payment.PaymentMethod = UC.BLL.Store.PaymentMethod.Translation;
            if (rbtnWire.Checked) UserProfile.Payment.PaymentMethod = UC.BLL.Store.PaymentMethod.Wire;
            //UserProfile.Save();
        }
    }
}
