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
    public partial class Banner : System.Web.UI.UserControl
    {
        private string _keywordFilter;
        public string KeywordFilter
        {
            get { return _keywordFilter; }
            set
            {
                AdRotator.KeywordFilter = value;
                _keywordFilter = value;
            }
        }

        private string _advertisementFile;
        public string AdvertisementFile
        {
            get { return _advertisementFile; }
            set
            {
                AdRotator.AdvertisementFile = value;
                _advertisementFile = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
