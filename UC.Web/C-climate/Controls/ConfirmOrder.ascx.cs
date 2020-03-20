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
    public partial class ConfirmOrder : System.Web.UI.UserControl
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

        public string Comment
        {
            get { return txtComment.Text; }
            set { txtComment.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Generate()
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                tdFIO.Text = "<b>" + Profile.Address.FIO + "</b>";
                tdTel.Text = "<b>" + Profile.Address.Tel + "</b>";
                switch (Profile.Payment.PaymentMethod)
                {
                    case UC.BLL.Store.PaymentMethod.Cash:
                        tdPayment.Text = "<b>наличными при получении</b>";
                        trPayer.Visible = false;
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        tdPayment.Text = "<b>банковский перевод</b>";
                        trPayer.Visible = false;
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        tdPayment.Text = "<b>безналичный расчет</b>";
                        trPayer.Visible = true;
                        string payer = "";
                        if (!String.IsNullOrEmpty(Profile.Payer.Organization)) payer = payer + "Название организации: <b>" + Profile.Payer.Organization + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.UrAddress)) payer = payer + "<br />Юридический адрес: <b>" + Profile.Payer.UrAddress + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.INN)) payer = payer + "<br />ИНН: <b>" + Profile.Payer.INN + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.KPP)) payer = payer + "<br />КПП: <b>" + Profile.Payer.KPP + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.OKPO)) payer = payer + "<br />Код ОКПО: <b>" + Profile.Payer.OKPO + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.OKONH)) payer = payer + "<br />Код ОКОНХ: <b>" + Profile.Payer.OKONH + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.Account)) payer = payer + "<br />Расчетный счет: <b>" + Profile.Payer.Account + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.CorrAccount)) payer = payer + "<br />Корреспондентский счет: <b>" + Profile.Payer.CorrAccount + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.Bank)) payer = payer + "<br />Банк: <b>" + Profile.Payer.Bank + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.BIK)) payer = payer + "<br />БИК: <b>" + Profile.Payer.BIK + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.PostAddress)) payer = payer + "<br />Почтовый адрес: <b>" + Profile.Payer.PostAddress + "</b>";
                        tdPayer.Text = payer;
                        break;
                }
                string address = "";
                address = address + "Почтовый индекс: <b>" + Profile.Address.PostCode + "</b><br />";
                address = address + "Область: <b>" + Profile.Address.Oblast + "</b><br />";
                address = address + "Район: <b>" + Profile.Address.Raion + "</b><br />";
                address = address + "Город/поселок: <b>" + Profile.Address.Gorod + "</b><br />";
                address = address + "Улица: <b>" + Profile.Address.Street + "</b><br />";
                address = address + "Дом: <b>" + Profile.Address.House + "</b><br />";
                address = address + "Квартира/офис: <b>" + Profile.Address.Ofis + "</b><br />";
                address = address + "Комментарий: <b>" + Profile.Address.Comment + "</b>";
                tdAddress.Text = address;
            }
        }
    }
}
