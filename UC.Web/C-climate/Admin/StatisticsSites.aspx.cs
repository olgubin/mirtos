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
    public partial class StatisticsSites : BasePage
    {
        string _firstDate = "";
        public string FirstDate
        {
            get
            {
                if (String.IsNullOrEmpty(_firstDate))
                {
                    // ����� ID ������� �������� �� ������ �������
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
                    // ����� ID ������� �������� �� ������ �������
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
                gvwSites.PageSize = pageSize;
            }

            if (!String.IsNullOrEmpty(FirstDate) & !String.IsNullOrEmpty(LastDate))
            {
                lblFiltr.Text = "������� � ����������� � ������ � " + FirstDate + " �� " + LastDate;

                objSites.SelectMethod = "ReportSitesByDate";
                objSites.SelectCountMethod = "ReportSitesByDateCount";
                objSites.SelectParameters.Clear();
                objSites.SelectParameters.Add("firstDate", TypeCode.DateTime, FirstDate);
                objSites.SelectParameters.Add("lastDate", TypeCode.DateTime, LastDate);
            }
            else
            {
                lblFiltr.Text = "����� " + StatisticsReport.ReportSitesByDateCount(DateTime.Parse("1900-01-01"), DateTime.Now).ToString() + " ��������.";

                objSites.SelectMethod = "ReportSitesByDate";
                objSites.SelectCountMethod = "ReportSitesByDateCount";
                objSites.SelectParameters.Clear();
                objSites.SelectParameters.Add("firstDate", TypeCode.DateTime, "1900-01-01");
                objSites.SelectParameters.Add("lastDate", TypeCode.DateTime, DateTime.Now.ToString());
            }

            gvwSites.DataSourceID = "objSites";

            gvwSites.DataBind();
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwSites.PageSize = int.Parse(ddlPerPage.SelectedValue);
            gvwSites.PageIndex = 0;
            gvwSites.DataBind();
        }

        protected void gvwSites_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // ��������� ������ �� �������� ��������
                e.Row.Cells[1].Text = "<a href=\"StatisticsRequests.aspx?ip=" + e.Row.Cells[1].Text + "\">" + e.Row.Cells[1].Text + "</a>";

                // ��������� ������ �� ����
                e.Row.Cells[3].Text = "<a href=\"http://" + e.Row.Cells[3].Text + "\">" + e.Row.Cells[3].Text + "</a>";

                // ��������� ������ �� url c �����
                e.Row.Cells[4].Text = "<a href=\"" + e.Row.Cells[4].Text + "\">" + e.Row.Cells[4].Text + "</a>";
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ReportRequestDetails request = e.Row.DataItem as ReportRequestDetails;

            //    // ���������� ������ ������� ����� ��������� ���������� ��������� �������� ������
            //    e.Row.Cells[3].Text = HttpUtility.UrlDecode(e.Row.Cells[3].Text, System.Text.Encoding.Default);

            //    // ��������� ������� ��������, � ������ ������
            //    e.Row.Cells[3].Text = "<a href='.." + e.Row.Cells[3].Text + "'>" + e.Row.Cells[3].Text + "</a>";


            //    // ��������� �������� ��� ���������, ������� � ��������� ����
            //    if (request.Url.Contains("Departments.aspx"))
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

            //    // �������� ������ ��������
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