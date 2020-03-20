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
          BreadCrumb.AddInActiveLink("—татьи");

          if (!this.IsPostBack)
          {
              if (!string.IsNullOrEmpty(this.Request.QueryString["CatID"]))
              {
                  Category category = Category.GetCategoryByID(Int32.Parse(this.Request.QueryString["CatID"]));

                  if (category == null)
                  {
                      Context.Response.StatusCode = 404;
                      throw new ApplicationException("–аздел не найдена.");
                  }

                  //изменени заголовка и тега keywords в соответствии с разделом
                  BasePage.HeaderWrite(this.Page, category.Title,
                      category.Title + ", мебель дл€ ванной, мебель дл€ ванной, мебель дл€ ванной Edelform, душевые кабины, душевые кабины Edelform, душевые кабины Luxus",
                      category.Description);
              }
              else
              {
                  //lblTitle.Text = "¬се статьи";

                  //изменени заголовка и тега keywords в соответствии с разделом
                  BasePage.HeaderWrite(this.Page, "—татьи о климатическом оборудовании",
                      "мебель дл€ ванной, мебель дл€ ванной, мебель дл€ ванной Edelform, душевые кабины, душевые кабины Edelform, душевые кабины Luxus",
                      "—татьи о мебели дл€ ванной, дизайне ванной и душевых кабинах.");

              }
          }
      }
   }
}