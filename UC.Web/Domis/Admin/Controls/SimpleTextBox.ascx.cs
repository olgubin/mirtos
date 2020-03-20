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
    public partial class SimpleTextBox : System.Web.UI.UserControl
    {
        public string Text
        {
            get
            {
                return txtValue.Text;
            }
            set
            {
                txtValue.Text = value;
            }
        }

        public string ErrorMessage
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
            }
        }
    }
}
