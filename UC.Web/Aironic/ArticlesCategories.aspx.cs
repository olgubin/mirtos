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
using UC.BLL.Articles;

namespace UC.UI
{
    public partial class ArticlesCategories : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //изменени заголовка и тега keywords в соответствии с разделом
                BasePage.HeaderWrite(this.Page, "—татьи о кондиционерах и климатическом оборудовании",
                    "статьи, кондиционеры, тепловые завесы, вентил€ци€, сплит-системы, климатическое оборудование, отопление, радиаторы, Daikin, Kentatsu",
                    "—татьи о климатическом оборудовании. ”стройство использование и применение климатического оборудовани€. »сследование и сравнение кондиционеров, сплит-систем, систем вентил€ции. —татьи о производител€х и брендах.");
            }
        }

        // ѕрив€зка дочерней таблицы к источнику данных
        protected void dlstCategories_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GridView gridChild = e.Item.FindControl("gvwArticlesbyCategory") as GridView;

                int catID = Convert.ToInt32(dlstCategories.DataKeys[e.Item.ItemIndex]);

                object data = Article.GetArticlesLast(5, catID);

                gridChild.DataSource = data;
                gridChild.DataBind();
            }
        }

        public string GetArticlesCount(int categoryID)
        {
            return Article.GetArticleCount(true,categoryID).ToString();
        }
    }
}