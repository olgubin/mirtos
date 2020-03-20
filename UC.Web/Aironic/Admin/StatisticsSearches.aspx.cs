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
using System.Web.Profile;
using System.Text.RegularExpressions;
using UC;
using UC.DAL;
using UC.BLL.Statistics;
using UC.BLL.Store;

namespace UC.UI.Admin
{
    public partial class StatisticsSearches : BasePage
    {
        string _firstDate = "";
        public string FirstDate
        {
            get
            {
                if (String.IsNullOrEmpty(_firstDate))
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["firstdate"]))
                    {
                        _firstDate = this.Request.QueryString["firstdate"];
                    }
                }
                return _firstDate;
            }
        }

        string _lastDate = "";
        public string LastDate
        {
            get
            {
                if (String.IsNullOrEmpty(_lastDate))
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["lastdate"]))
                    {
                        _lastDate = this.Request.QueryString["lastdate"];
                    }
                }
                return _lastDate;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int pageSize = 50;
                if (ddlPerPage.Items.FindByValue(pageSize.ToString()) == null)
                    ddlPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                ddlPerPage.SelectedValue = pageSize.ToString();
                gvwSearches.PageSize = pageSize;
            }

            if (!String.IsNullOrEmpty(FirstDate) & !String.IsNullOrEmpty(LastDate))
            {
                lblFiltr.Text = "Приходы с поисковиков в период с " + FirstDate + " по " + LastDate;

                objSearches.SelectMethod = "ReportSearchesByDate";
                objSearches.SelectCountMethod = "ReportSearchesByDateCount";
                objSearches.SelectParameters.Clear();
                objSearches.SelectParameters.Add("firstDate", TypeCode.DateTime, FirstDate);
                objSearches.SelectParameters.Add("lastDate", TypeCode.DateTime, LastDate);
            }
            else
            {
                lblFiltr.Text = "Всего " + StatisticsReport.ReportSearchesByDateCount(DateTime.Parse("1900-01-01"), DateTime.Now).ToString() + " приходов.";

                objSearches.SelectMethod = "ReportSearchesByDate";
                objSearches.SelectCountMethod = "ReportSearchesByDateCount";
                objSearches.SelectParameters.Clear();
                objSearches.SelectParameters.Add("firstDate", TypeCode.DateTime, "1900-01-01");
                objSearches.SelectParameters.Add("lastDate", TypeCode.DateTime, DateTime.Now.ToString());
            }

            gvwSearches.DataSourceID = "objSearches";

            gvwSearches.DataBind();
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwSearches.PageSize = int.Parse(ddlPerPage.SelectedValue);
            gvwSearches.PageIndex = 0;
            gvwSearches.DataBind();
        }

        protected void gvwSearches_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // добавляем ссылку на тсраницу запросов
                e.Row.Cells[1].Text = "<a href=\"StatisticsRequests.aspx?ip=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[1].Text + "</a>";
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ReportRequestDetails request = e.Row.DataItem as ReportRequestDetails;

            //    // декодируем строку запроса чтобы корректно отображала параметры например поиска
            //    e.Row.Cells[3].Text = HttpUtility.UrlDecode(e.Row.Cells[3].Text, System.Text.Encoding.Default);

            //    // добавляем главную страницу, и делаем ссылку
            //    e.Row.Cells[3].Text = "<a href='.." + e.Row.Cells[3].Text + "'>" + e.Row.Cells[3].Text + "</a>";


            //    // добавляем описание для каталогов, товаров и поисковых фраз
            //    if (request.Url.Contains("BrowseProducts.aspx"))
            //    {
            //        Match m = Regex.Match(request.Url, "DepID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //        try
            //        {
            //            int depID = Int32.Parse(m.Groups[1].ToString());
            //            Department department = Department.GetDepartmentByID(depID);
            //            if (department != null)
            //                e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<br/>" + department.Title;
            //        }
            //        catch { }
            //    }

            //    if (request.Url.Contains("ShowProduct.aspx"))
            //    {
            //        Match m = Regex.Match(request.Url, "ID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //        try
            //        {
            //            int productID = Int32.Parse(m.Groups[1].ToString());
            //            Product product = Product.GetProductByID(productID);
            //            if (product != null)
            //                e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<br/>" + product.Title;
            //        }
            //        catch { }
            //    }

            //    // обрезаем строку браузера
            //    //string browserString = e.Row.Cells[4].Text;

            //    //if (browserString.Length > 50)
            //    //{
            //    //    browserString = browserString.Remove(50);
            //    //    e.Row.Cells[4].Text = browserString + "...";
            //    //}
            //}
        }
    }
}