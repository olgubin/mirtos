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
using UC;
using UC.UI;
using UC.BLL.Articles;

namespace UC.UI.Controls
{
    public partial class ArticleBox : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            repArticleItems.DataSource = Article.GetArticlesLast(Globals.Settings.Articles.LastArticleSize);
            repArticleItems.DataBind();
        }
    }
}