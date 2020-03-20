using System;

namespace Controls
{
    public partial class NotFound404 : System.Web.UI.UserControl
    {
        public new bool Visible
        {
            set
            {
                pnl404.Visible = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}