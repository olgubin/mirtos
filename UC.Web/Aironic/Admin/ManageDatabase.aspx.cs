using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Profile;
using System.Text.RegularExpressions;
using UC.DAL;

namespace UC.UI.Admin
{
    public partial class ManageDatabase : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextCount();
        }

        protected void ManageDatabase_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteAnonymousUsers":
                    SiteProvider.Framework.DeleteAnonymousUsers(Globals.Settings.Framework.InnactiveDays);
                    break;
                case "DeleteInnactiveProfiles":
                    SiteProvider.Framework.DeleteInnactiveProfiles(Globals.Settings.Framework.InnactiveDays);
                    break;
                case "DeleteWebEvents":
                    SiteProvider.Framework.DeleteWebEvents();
                    break;
            }

            TextCount();
        }

        protected void TextCount()
        {
            lblAnonymousUsersCount.Text = SiteProvider.Framework.GetAnonymousUsersCount().ToString();
            lblInnactiveProfileCount.Text = SiteProvider.Framework.GetInnactivesProfileCount().ToString();
            lblWebEventsCount.Text = SiteProvider.Framework.GetWebEventsCount().ToString();
        }
    }
}