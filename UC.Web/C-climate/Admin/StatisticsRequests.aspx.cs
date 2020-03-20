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
    public partial class StatisticsRequests : BasePage
    {
        string _url = "";
        public string Url
        {
            get
            {
                if (String.IsNullOrEmpty(_url))
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["url"]))
                    {
                        _url = this.Request.QueryString["url"];
                    }
                }
                return _url;
            }
        }

        string _ip = "";
        public string IP
        {
            get
            {
                if (String.IsNullOrEmpty(_ip))
                {
                    // выбор ID раздела каталога из строки запроса
                    if (!string.IsNullOrEmpty(this.Request.QueryString["ip"]))
                    {
                        _ip = this.Request.QueryString["ip"];
                    }
                }
                return _ip;
            }
        }

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
                gvwRequests.PageSize = pageSize;
            }

            if (!String.IsNullOrEmpty(Url))
            {
                lblFiltr.Text = "Запросы обращенные к странице: " + Url;

                // добавляем описание для катаолгов, товаров и поисковых фраз
                if (Url.Contains("Departments.aspx"))
                {
                    Match m = Regex.Match(Url, "DepID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    try
                    {
                        int depID = Int32.Parse(m.Groups[1].ToString());
                        Department department = DepartmentManager.GetByDepartmentID(depID);
                        if (department != null)
                            lblFiltr.Text += " (" + department.Name + ")";
                    }
                    catch { }
                }

                if (Url.Contains("ShowProduct.aspx"))
                {
                    Match m = Regex.Match(Url, "ID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    try
                    {
                        int productID = Int32.Parse(m.Groups[1].ToString());
                        Product product = ProductManager.GetByProductID(productID);
                        if (product != null)
                            lblFiltr.Text += " (" + product.Title + ")";
                    }
                    catch { }
                }

                gvwRequests.Columns[3].Visible = false;

                objRequests.SelectMethod = "ReportRequestsByUrl";
                objRequests.SelectCountMethod = "ReportRequestsByUrlCount";
                objRequests.SelectParameters.Clear();
                objRequests.SelectParameters.Add("url", Url);
            }
            else
            {

                if (!String.IsNullOrEmpty(IP))
                {
                    lblFiltr.Text = "Запросы от хоста: " + IP;
                    gvwRequests.Columns[1].Visible = false;

                    objRequests.SelectMethod = "ReportRequestsByIP";
                    objRequests.SelectCountMethod = "ReportRequestsByIPCount";
                    objRequests.SelectParameters.Clear();
                    objRequests.SelectParameters.Add("ip", IP);
                }
                else
                {
                    if (!String.IsNullOrEmpty(FirstDate) & !String.IsNullOrEmpty(LastDate))
                    {
                        if (FirstDate == LastDate)
                            lblFiltr.Text = "Запросы за " + FirstDate;
                        else
                            lblFiltr.Text = "Запросы в период с " + FirstDate + " по " + LastDate;

                        objRequests.SelectMethod = "ReportRequestsByDate";
                        objRequests.SelectCountMethod = "ReportRequestsByDateCount";
                        objRequests.SelectParameters.Clear();
                        objRequests.SelectParameters.Add("firstDate", TypeCode.DateTime, FirstDate);
                        objRequests.SelectParameters.Add("lastDate", TypeCode.DateTime, LastDate);
                    }
                    else
                    {
                        lblFiltr.Text = "Всего " + StatisticsReport.ReportRequestsByDateCount(DateTime.Parse("1900-01-01"), DateTime.Now).ToString() + " запросов.";

                        objRequests.SelectMethod = "ReportRequestsByDate";
                        objRequests.SelectCountMethod = "ReportRequestsByDateCount";
                        objRequests.SelectParameters.Clear();
                        objRequests.SelectParameters.Add("firstDate", TypeCode.DateTime, "1900-01-01");
                        objRequests.SelectParameters.Add("lastDate", TypeCode.DateTime, DateTime.Now.ToString());
                    }
                }
            }

            gvwRequests.DataSourceID = "objRequests";

            gvwRequests.DataBind();
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwRequests.PageSize = int.Parse(ddlPerPage.SelectedValue);
            gvwRequests.PageIndex = 0;
            gvwRequests.DataBind();
        }

        protected void gvwPages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ReportRequestDetails request = e.Row.DataItem as ReportRequestDetails;

                // декодируем строку запроса чтобы корректно отображала параметры например поиска
                e.Row.Cells[3].Text = HttpUtility.UrlDecode(e.Row.Cells[3].Text, System.Text.Encoding.Default);

                // добавляем главную страницу, и делаем ссылку
                e.Row.Cells[3].Text = "<a href='.." + e.Row.Cells[3].Text + "'>" + e.Row.Cells[3].Text + "</a>";

                // добавляем ссылку на тсраницу запросов
                e.Row.Cells[1].Text = "<a href=\"StatisticsRequests.aspx?ip=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[1].Text + "</a>";

                // добавляем описание для каталогов, товаров и поисковых фраз
                if (request.Url.Contains("Departments.aspx"))
                {
                    Match m = Regex.Match(request.Url, "DepID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    try
                    {
                        int depID = Int32.Parse(m.Groups[1].ToString());
                        Department department = DepartmentManager.GetByDepartmentID(depID);
                        if (department != null)
                            e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<br/>" + department.Name;
                    }
                    catch { }
                }

                if (request.Url.Contains("ShowProduct.aspx"))
                {
                    Match m = Regex.Match(request.Url, "ID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    try
                    {
                        int productID = Int32.Parse(m.Groups[1].ToString());
                        Product product = ProductManager.GetByProductID(productID);
                        if (product != null)
                            e.Row.Cells[3].Text = e.Row.Cells[3].Text + "<br/>" + product.Title;
                    }
                    catch { }
                }

                // обрезаем строку браузера
                //string browserString = e.Row.Cells[4].Text;

                //if (browserString.Length > 50)
                //{
                //    browserString = browserString.Remove(50);
                //    e.Row.Cells[4].Text = browserString + "...";
                //}
            }
        }
    }
}