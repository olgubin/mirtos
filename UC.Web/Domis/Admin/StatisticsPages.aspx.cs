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
using System.Web.Profile;
using System.Text.RegularExpressions;
using UC;
using UC.DAL;
using UC.BLL.Store;

namespace UC.UI.Admin
{
    public partial class StatisticsPages : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int pageSize = 50;
                if (ddlPagesPerPage.Items.FindByValue(pageSize.ToString()) == null)
                    ddlPagesPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                ddlPagesPerPage.SelectedValue = pageSize.ToString();
                gvwPages.PageSize = pageSize;

                gvwPages.DataBind();
            }
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwPages.PageSize = int.Parse(ddlPagesPerPage.SelectedValue);
            gvwPages.PageIndex = 0;
            gvwPages.DataBind();
        }

        protected void gvwPages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ReportPageDetails page = e.Row.DataItem as ReportPageDetails;

                // ���������� ������ ������� ����� ��������� ���������� ��������� �������� ������
                e.Row.Cells[1].Text = HttpUtility.UrlDecode(e.Row.Cells[1].Text, System.Text.Encoding.Default);

                // ��������� ������� ��������, � ������ ������
                e.Row.Cells[1].Text = "<a href='.." + e.Row.Cells[1].Text + "'>" + e.Row.Cells[1].Text + "</a>";

                // ��������� �������� ��� ���������, ������� � ��������� ����
                if (page.Url.Contains("Departments.aspx"))
                {
                    if (!String.IsNullOrEmpty(page.Url))
                    {
                        Match m = Regex.Match(page.Url, "DepID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        try
                        {
                            int depID = Int32.Parse(m.Groups[1].ToString());
                            Department department = DepartmentManager.GetByDepartmentID(depID);
                            if (department != null)
                                e.Row.Cells[2].Text = department.Name;
                        }
                        catch { }
                    }
                }

                if (page.Url.Contains("ShowProduct.aspx"))
                {
                    if (!String.IsNullOrEmpty(page.Url))
                    {
                        Match m = Regex.Match(page.Url, "ID=([0-9]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        try
                        {
                            int productID = Int32.Parse(m.Groups[1].ToString());
                            Product product = ProductManager.GetByProductID(productID);
                            if (product != null)
                                e.Row.Cells[2].Text = product.Title;
                        }
                        catch { }
                    }
                }
            }
        }
    }
}