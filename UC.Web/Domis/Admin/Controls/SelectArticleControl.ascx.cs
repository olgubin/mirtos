using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using UC.BLL.Articles;

namespace UC.UI.Admin.Controls
{
    public partial class SelectArticleControl : System.Web.UI.UserControl
    {
        private int selectArticleId;
        public int SelectArticleID
        {
            get
            {
                if (this.ddlArticles.SelectedItem != null)
                {
                    return int.Parse(this.ddlArticles.SelectedItem.Value);
                }
                else
                    return 0;
            }
            set
            {
                this.selectArticleId = value;

                List<Article> articles = Article.GetArticles();

                bool find = false;
                foreach (Article item in articles)
                {
                    if (item.ID == value)
                    {
                        find = true;
                        break;
                    }
                }

                if (find)
                {
                    this.ddlArticles.SelectedValue = value.ToString();
                }
                else
                {
                    this.ddlArticles.SelectedValue = "0";
                }
            }
        }

        public void BindData()
        {
            //ddlArticles.Items.Clear();

            List<Article> articles = Article.GetArticles();

            ddlArticles.DataSource = articles;

            this.ddlArticles.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public string CssClass
        {
            get
            {
                return ddlArticles.CssClass;
            }
            set
            {
                ddlArticles.CssClass = value;
            }
        }
    }
}