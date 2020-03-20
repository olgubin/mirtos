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
using UC.BLL.Statistics;
using UC.DAL;
using UC.IpBlocking.BLL;

namespace UC.UI.Admin
{
    public partial class StatisticsHosts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int pageSize = Globals.Settings.Search.PageSize;
                if (ddlHostPerPage.Items.FindByValue(pageSize.ToString()) == null)
                    ddlHostPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
                ddlHostPerPage.SelectedValue = pageSize.ToString();
                gvwHosts.PageSize = pageSize;

                HostCount.Text = UC.BLL.Statistics.Host.GetHostCount().ToString();

                gvwHosts.DataBind();
            }
        }

        protected void ddlRequestsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwHosts.PageSize = int.Parse(ddlHostPerPage.SelectedValue);
            gvwHosts.PageIndex = 0;
            gvwHosts.DataBind();
        }

        private void DeselectIgnoreHosts()
        {
            gvwIgnoreHosts.SelectedIndex = -1;
            gvwIgnoreHosts.DataBind();
            gvwHosts.DataBind();
            HostCount.Text = UC.BLL.Statistics.Host.GetHostCount().ToString();
            dvwIgnoreHosts.ChangeMode(DetailsViewMode.Insert);
        }

        protected void gvwIgnoreHosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvwIgnoreHosts.ChangeMode(DetailsViewMode.Edit);
        }

        protected void gvwIgnoreHosts_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DeselectIgnoreHosts();
        }

        protected void gvwIgnoreHosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    ImageButton btn_visible = e.Row.Cells[4].Controls[0] as ImageButton;

                    //ImageButton btn_visible = e.Row.FindControl("imgBlock") as ImageButton;

                    if ((bool)DataBinder.Eval(e.Row.DataItem, "Block"))
                    {
                        btn_visible.ImageUrl = "~/Images/unvis.gif";
                        btn_visible.ToolTip = "Игнорировать";
                    }
                    else
                    {
                        btn_visible.ImageUrl = "~/Images/vis.gif";
                        btn_visible.ToolTip = "Блокировать";
                    }
                }
            }
        }

        protected void gvwIgnoreHosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Block")
            {
                if (Request["x"] == null || Request["y"] == null)
                {
                    Response.End();
                }

                string ip = Convert.ToString(gvwIgnoreHosts.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
                //string ip = Convert.ToString(e.CommandArgument);

                BlockIp blockIp = BlockIpManager.GetBlockIpByIp(ip);

                BlockIpManager.LockIp(blockIp.Ip, !blockIp.Block);

                gvwIgnoreHosts.SelectedIndex = -1;
                gvwIgnoreHosts.DataBind();
            }
        }

        protected void dvwIgnoreHosts_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            string ip = e.Values["IP"].ToString();

            UC.BLL.Statistics.Request.DeleteRequestsByHost(ip);

            DeselectIgnoreHosts();
        }

        protected void dvwIgnoreHosts_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            DeselectIgnoreHosts();
        }

        protected void dvwIgnoreHosts_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
                DeselectIgnoreHosts();
        }

        protected void dvwIgnoreHosts_ItemCreated(object sender, EventArgs e)
        {
            foreach (Control ctl in dvwIgnoreHosts.Rows[dvwIgnoreHosts.Rows.Count - 1].Controls[0].Controls)
            {
                if (ctl is LinkButton)
                {
                    LinkButton lnk = ctl as LinkButton;
                    if (lnk.CommandName == "Insert" || lnk.CommandName == "Update")
                        lnk.ValidationGroup = "Option";
                }
            }
        }

        protected void gvwHosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // добавляем ссылку на тсраницу запросов
                e.Row.Cells[0].Text = "<a href=\"StatisticsRequests.aspx?ip=" + e.Row.Cells[0].Text + "\">" + e.Row.Cells[0].Text + "</a>";
            }
        }

        protected void gvwHosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Lock")
            {
                if (Request["x"] == null || Request["y"] == null)
                {
                    Response.End();
                }

                string ip = Convert.ToString(gvwHosts.DataKeys[Convert.ToInt32(e.CommandArgument)][0]);
                //string ip = Convert.ToString(e.CommandArgument);

                Host host = Host.GetHostByIP(ip);

                BlockIpManager.InsertBlockIp(ip, String.Format("Запросов: {0} c {1} по {2}", host.RequestCount, host.FirstDate.ToString("dd/MM/yy"), host.LastDate.ToString("dd/MM/yy")), host.LastDate, true);

                UC.BLL.Statistics.Request.DeleteRequestsByHost(ip);

                DeselectIgnoreHosts();
            }
        }
    }
}