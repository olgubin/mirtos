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
    public partial class PaymentOptions : System.Web.UI.UserControl
    {
        ProfileCommon _userProfile;
        public ProfileCommon UserProfile
        {
            get
            {
                if (_userProfile == null)
                {
                    _userProfile = Profile;
                    //_userProfile = Profile.GetProfile(Page.User.Identity.Name);
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
                    txtOrganization.Text = UserProfile.Payer.Organization;
                    txtJurAddress.Text = UserProfile.Payer.UrAddress;
                    txtINN.Text = UserProfile.Payer.INN;
                    txtKPP.Text = UserProfile.Payer.KPP;
                    txtOKPO.Text = UserProfile.Payer.OKPO;
                    txtOKONH.Text = UserProfile.Payer.OKONH;
                    txtPostAddress.Text = UserProfile.Payer.PostAddress;
                    txtAccount.Text = UserProfile.Payer.Account;
                    txtCorrAccount.Text = UserProfile.Payer.CorrAccount;
                    txtBank.Text = UserProfile.Payer.Bank;
                    txtBIK.Text = UserProfile.Payer.BIK;
                }
            }
        }

        public void onSave(object sender, EventArgs e)
        {
            //Проверка на сервере. на случай если у клиента отключен JScript
            valRequireOrgName.Validate();
            valRequireJurAddress.Validate();
            valRequireINN.Validate();
            valRequireAccount.Validate();
            valRequireKPP.Validate();
            valRequireBank.Validate();
            valRequireBIK.Validate();
            if (valRequireOrgName.IsValid &
                valRequireJurAddress.IsValid &
                valRequireINN.IsValid &
                valRequireAccount.IsValid &
                valRequireKPP.IsValid &
                valRequireBank.IsValid &
                valRequireBIK.IsValid)
            {
                UserProfile.Payer.Organization = txtOrganization.Text;
                UserProfile.Payer.UrAddress = txtJurAddress.Text;
                UserProfile.Payer.INN = txtINN.Text;
                UserProfile.Payer.KPP = txtKPP.Text;
                UserProfile.Payer.OKPO = txtOKPO.Text;
                UserProfile.Payer.OKONH = txtOKONH.Text;
                UserProfile.Payer.PostAddress = txtPostAddress.Text;
                UserProfile.Payer.Account = txtAccount.Text;
                UserProfile.Payer.CorrAccount = txtCorrAccount.Text;
                UserProfile.Payer.Bank = txtBank.Text;
                UserProfile.Payer.BIK = txtBIK.Text;
                //UserProfile.Save();
            }
        }
    }
}
