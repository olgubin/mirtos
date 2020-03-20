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

namespace UC.UI
{
    public partial class Error : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Request.QueryString["code"] == "404")
            //    lblTitle.Text = "Страница не найдена";

            if (this.Request.QueryString["code"] == "408")
                lblTitle.Text = "Время выполнения запроса истекло. Пожалуйста повторите запрос через некоторое время.";

            if (this.Request.QueryString["code"] == "505")
                lblTitle.Text = "Ошибка при обработке запроса.";

            //lbl404.Visible = (this.Request.QueryString["code"] != null && this.Request.QueryString["code"] == "404");
            //lbl408.Visible = (this.Request.QueryString["code"] != null && this.Request.QueryString["code"] == "408");
            //lbl505.Visible = (this.Request.QueryString["code"] != null && this.Request.QueryString["code"] == "505");
            //lblError.Visible = (string.IsNullOrEmpty(this.Request.QueryString["code"]));

            //if (this.Request.QueryString["code"] != null && this.Request.QueryString["code"] == "404")
            //{
            //    Context.Response.Status = "404 Not Found";
            //}
            //else
            //{
                Context.Response.Status = "500 Internal Server Error";
            //}
        }
    }
}
