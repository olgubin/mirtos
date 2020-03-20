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
using UC.BLL.Parsing;

namespace UC.UI.Admin
{
    public partial class RefreshParsingCatalog : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // получение каталога по ID проверка есть ли такой раздел
                //ParsingCatalog catalog = ParsingCatalog.GetCatalogByID(CatalogID);
                //if (catalog == null)
                //    throw new ApplicationException(" аталог не найден.");

                //ƒобавл€ем текст и ссылку в хлебные крошки на каталог
                ParsingCatalog catalog = ParsingCatalog.GetCatalogByID(ProductListing1.CatalogID);

                lnkCatalogTitle.Text = catalog.Title;
                lnkCatalogTitle.NavigateUrl = "~/Admin/ManageParsingProducts.aspx?CatalogID=" + ProductListing1.CatalogID.ToString();
            }

        }
    }
}