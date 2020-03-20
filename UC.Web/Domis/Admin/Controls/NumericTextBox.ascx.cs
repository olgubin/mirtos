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

namespace UC.UI.Admin.Controls
{
    public partial class NumericTextBox : System.Web.UI.UserControl
    {
        public int Value
        {
            get
            {
                return int.Parse(txtValue.Text);
            }
            set
            {
                txtValue.Text = value.ToString();
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return rfvValue.ErrorMessage;
            }
            set
            {
                rfvValue.ErrorMessage = value;
            }
        }

        public string RangeErrorMessage
        {
            get
            {
                return rvValue.ErrorMessage;
            }
            set
            {
                rvValue.ErrorMessage = value;
            }
        }

        public string MinimumValue
        {
            get
            {
                return rvValue.MinimumValue;
            }
            set
            {
                rvValue.MinimumValue = value;
            }
        }

        public string MaximumValue
        {
            get
            {
                return rvValue.MaximumValue;
            }
            set
            {
                rvValue.MaximumValue = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvValue.ValidationGroup;
            }
            set
            {
                txtValue.ValidationGroup = value;
                rfvValue.ValidationGroup = value;
                rvValue.ValidationGroup = value;
            }
        }

        public Unit Width
        {
            get
            {
                return txtValue.Width;
            }
            set
            {
                txtValue.Width = value;
            }
        }

        public string CssClass
        {
            get
            {
                return txtValue.CssClass;
            }
            set
            {
                txtValue.CssClass = value;
            }
        }
    }
}
