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
                //�������� ��������� � ���� keywords � ������������ � ��������
                BasePage.HeaderWrite(this.Page, "������ � ������������� � ������������� ������������",
                    "������, ������������, �������� ������, ����������, �����-�������, ������������� ������������, ���������, ���������, Daikin, Kentatsu",
                    "������ � ������������� ������������. ���������� ������������� � ���������� �������������� ������������. ������������ � ��������� �������������, �����-������, ������ ����������. ������ � �������������� � �������.");
            }
        }

        // �������� �������� ������� � ��������� ������
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