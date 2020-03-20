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
                        tdPayment.Text = "<b>��������� ��� ���������</b>";
                        trPayer.Visible = false;
                        break;
                    case UC.BLL.Store.PaymentMethod.Translation:
                        tdPayment.Text = "<b>���������� �������</b>";
                        trPayer.Visible = false;
                        break;
                    case UC.BLL.Store.PaymentMethod.Wire:
                        tdPayment.Text = "<b>����������� ������</b>";
                        trPayer.Visible = true;
                        string payer = "";
                        if (!String.IsNullOrEmpty(Profile.Payer.Organization)) payer = payer + "�������� �����������: <b>" + Profile.Payer.Organization + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.UrAddress)) payer = payer + "<br />����������� �����: <b>" + Profile.Payer.UrAddress + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.INN)) payer = payer + "<br />���: <b>" + Profile.Payer.INN + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.KPP)) payer = payer + "<br />���: <b>" + Profile.Payer.KPP + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.OKPO)) payer = payer + "<br />��� ����: <b>" + Profile.Payer.OKPO + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.OKONH)) payer = payer + "<br />��� �����: <b>" + Profile.Payer.OKONH + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.Account)) payer = payer + "<br />��������� ����: <b>" + Profile.Payer.Account + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.CorrAccount)) payer = payer + "<br />����������������� ����: <b>" + Profile.Payer.CorrAccount + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.Bank)) payer = payer + "<br />����: <b>" + Profile.Payer.Bank + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.BIK)) payer = payer + "<br />���: <b>" + Profile.Payer.BIK + "</b>";
                        if (!String.IsNullOrEmpty(Profile.Payer.PostAddress)) payer = payer + "<br />�������� �����: <b>" + Profile.Payer.PostAddress + "</b>";
                        tdPayer.Text = payer;
                        break;
                }
                string address = "";
                address = address + "�������� ������: <b>" + Profile.Address.PostCode + "</b><br />";
                address = address + "�������: <b>" + Profile.Address.Oblast + "</b><br />";
                address = address + "�����: <b>" + Profile.Address.Raion + "</b><br />";
                address = address + "�����/�������: <b>" + Profile.Address.Gorod + "</b><br />";
                address = address + "�����: <b>" + Profile.Address.Street + "</b><br />";
                address = address + "���: <b>" + Profile.Address.House + "</b><br />";
                address = address + "��������/����: <b>" + Profile.Address.Ofis + "</b><br />";
                address = address + "�����������: <b>" + Profile.Address.Comment + "</b>";
                tdAddress.Text = address;
            }
        }
    }
}
