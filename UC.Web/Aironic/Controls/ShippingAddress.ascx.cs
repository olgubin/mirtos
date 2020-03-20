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
    public partial class ShippingAddress : System.Web.UI.UserControl
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
                    txtFIO.Text = String.IsNullOrEmpty(UserProfile.Address.FIO) ? Page.User.Identity.Name : UserProfile.Address.FIO;
                    txtTelephone.Text = UserProfile.Address.Tel;
                    txtPostCode.Text = UserProfile.Address.PostCode;
                    txtOblast.Text = UserProfile.Address.Oblast;
                    txtRaion.Text = UserProfile.Address.Raion;
                    txtGorod.Text = UserProfile.Address.Gorod;
                    txtStreet.Text = UserProfile.Address.Street;
                    txtHouse.Text = UserProfile.Address.House;
                    txtOfis.Text = UserProfile.Address.Ofis;
                    txtComment.Text = UserProfile.Address.Comment;
                }
            }
        }

        public void onSave()
        {
            //Проверка на сервере. на случай если у клиента отключен JScript
            valRequireFIO.Validate();
            valRequireTelephone.Validate();
            if (valRequireFIO.IsValid &
                valRequireTelephone.IsValid)
            {
                UserProfile.Address.FIO = txtFIO.Text;
                UserProfile.Address.Tel = txtTelephone.Text;
                UserProfile.Address.PostCode = txtPostCode.Text;
                UserProfile.Address.Oblast = txtOblast.Text;
                UserProfile.Address.Raion = txtRaion.Text;
                UserProfile.Address.Gorod = txtGorod.Text;
                UserProfile.Address.Street = txtStreet.Text;
                UserProfile.Address.House = txtHouse.Text;
                UserProfile.Address.Ofis = txtOfis.Text;
                UserProfile.Address.Comment = txtComment.Text;
                //UserProfile.Save();
            }
        }
    }
}
