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

namespace UC.UI.Controls
{
    public partial class BreadCrumb : BaseWebPart
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

            }
        }

        /// <summary>
        /// Добавление активной ссылки
        /// </summary>
        /// <param name="title">заголовок ссылки</param>
        /// <param name="hyperLink">ссылка</param>
        public void AddActiveLink(string title, string link)
        {
            AddSeparator();

            TableCell cell = new TableCell();
            HyperLink hyperLink = new HyperLink();
            hyperLink.NavigateUrl = link;
            hyperLink.Text = title;
            cell.Controls.Add(hyperLink);
            rowBreadCrumb.Cells.Add(cell);
        }

        /// <summary>
        /// Добавление неактивной ссылки
        /// </summary>
        /// <param name="title">заголовок ссылки</param>
        public void AddInActiveLink(string title)
        {
            AddSeparator();

            TableCell cell = new TableCell();
            cell.Text = "<h1>" + title + "</h1>";
            rowBreadCrumb.Cells.Add(cell);
        }

        /// <summary>
        /// Добавление разделителя
        /// </summary>
        public void AddSeparator()
        {
            TableHeaderCell separator = new TableHeaderCell();
            Image image = new Image();
            image.SkinID = "Separator";
            separator.Controls.Add(image);
            rowBreadCrumb.Cells.Add(separator);
        }
    }
}