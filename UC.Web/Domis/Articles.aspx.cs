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
          BreadCrumb.AddInActiveLink("������");

          if (!this.IsPostBack)
          {
              if (!string.IsNullOrEmpty(this.Request.QueryString["CatID"]))
              {
                  Category category = Category.GetCategoryByID(Int32.Parse(this.Request.QueryString["CatID"]));

                  if (category == null)
                  {
                      Context.Response.StatusCode = 404;
                      throw new ApplicationException("������ �� �������.");
                  }

                  //�������� ��������� � ���� keywords � ������������ � ��������
                  BasePage.HeaderWrite(this.Page, category.Title,
                      category.Title + ", ������ ��� ������, ������ ��� ������, ������ ��� ������ Edelform, ������� ������, ������� ������ Edelform, ������� ������ Luxus",
                      category.Description);
              }
              else
              {
                  //lblTitle.Text = "��� ������";

                  //�������� ��������� � ���� keywords � ������������ � ��������
                  BasePage.HeaderWrite(this.Page, "������ � ������������� ������������",
                      "������ ��� ������, ������ ��� ������, ������ ��� ������ Edelform, ������� ������, ������� ������ Edelform, ������� ������ Luxus",
                      "������ � ������ ��� ������, ������� ������ � ������� �������.");

              }
          }
      }
   }
}