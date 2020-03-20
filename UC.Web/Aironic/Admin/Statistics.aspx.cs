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
using UC;
using UC.DAL;
using UC.BLL.Statistics;

namespace UC.UI.Admin
{
    public partial class Statistics : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //int pageSize = Globals.Settings.Search.PageSize;
                //if (ddlRequestsPerPage.Items.FindByValue(pageSize.ToString()) == null)
                //    ddlRequestsPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                //ddlRequestsPerPage.SelectedValue = pageSize.ToString();
                //gvwRequests.PageSize = pageSize;

                //gvwRequests.DataBind();
            }
        }

        protected void gvwStatisticsAll_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // ��������� ������ �� ���������� � ������
                e.Row.Cells[5].Text = "<a href=\"StatisticsSites.aspx\" alt=\"���������� ��������\">" + e.Row.Cells[5].Text + "</a>";

                // ��������� ������ �� ���������� �����������
                e.Row.Cells[6].Text = "<a href=\"StatisticsSearches.aspx\" alt=\"���������� ��������\">" + e.Row.Cells[6].Text + "</a>";

                // ��������� ������ �� ���������� ��������
                e.Row.Cells[1].Text = "<a href=\"StatisticsRequests.aspx\" alt=\"���������� �������\">" + e.Row.Cells[1].Text + "</a>";
            }
        }

        protected void gvwStatistics_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                StatisticsDetails statistic = e.Row.DataItem as StatisticsDetails;
                if (statistic != null)
                {
                    string firstDate = statistic.FirstDate.ToString("d");
                    string lastDate = statistic.LastDate.ToString("d");

                    // ��������� ������ �� ���������� � ������
                    e.Row.Cells[5].Text = "<a href=\"StatisticsSites.aspx?firstdate=" + firstDate + "&lastdate=" + lastDate + "\" alt=\"���������� ��������\">" + e.Row.Cells[5].Text + "</a>";

                    // ��������� ������ �� ���������� �����������
                    e.Row.Cells[6].Text = "<a href=\"StatisticsSearches.aspx?firstdate=" + firstDate + "&lastdate=" + lastDate + "\" alt=\"���������� ��������\">" + e.Row.Cells[6].Text + "</a>";

                    // ��������� ������ �� ���������� ��������
                    e.Row.Cells[1].Text = "<a href=\"StatisticsRequests.aspx?firstdate=" + firstDate + "&lastdate=" + lastDate + "\" alt=\"���������� �������\">" + e.Row.Cells[1].Text + "</a>";
                }
            }
        }
}
}