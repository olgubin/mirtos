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
using UC.BLL.Articles;

namespace UC.UI
{
   public partial class BrowseArticles : BasePage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!this.IsPostBack)
          {
              if (!string.IsNullOrEmpty(this.Request.QueryString["CatID"]))
              {
                  Category category = Category.GetCategoryByID(Int32.Parse(this.Request.QueryString["CatID"]));

                  if (category == null)
                  {
                      Context.Response.StatusCode = 404;
                      throw new ApplicationException("Раздел не найдена.");
                  }

                  //lblTitle.Text = category.Title;

                  //изменени заголовка и тега keywords в соответствии с разделом
                  BasePage.HeaderWrite(this.Page, category.Title,
                      category.Title + ", статьи, статьи о диктофонах, статьи о цифровых диктофонах, диктофоны, Климатическое оборудование, Климатическое оборудование Гном, диктофоны Гном",
                      category.Description);
              }
              else
              {
                  //lblTitle.Text = "Все статьи";

                  //изменени заголовка и тега keywords в соответствии с разделом
                  BasePage.HeaderWrite(this.Page, "Статьи о климатическом оборудовании",
                      "статьи, статьи о диктофонах, статьи о цифровых диктофонах, диктофоны, Климатическое оборудование, Климатическое оборудование Гном, диктофоны Гном",
                      "Статьи о диктофонах. Климатическое оборудование Гном.");

              }
          }
      }
   }
}