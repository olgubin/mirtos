using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FredCK.FCKeditorV2;
using System.Threading;
using UC;
using UC.BLL.Newsletters;

namespace UC.UI.Admin
{
    public partial class AddEditNewsletter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // если ID присутствует в запросе переключаем в режим редактировани€ новости
                // но только если пользователь принадлежит к администратору или редактору
                if (!string.IsNullOrEmpty(this.Request.QueryString["ID"]))
                {
                    if (this.User.Identity.IsAuthenticated &&
                       (this.User.IsInRole("Administrators") || this.User.IsInRole("Editors")))
                    {
                        dvwNewsletter.ChangeMode(DetailsViewMode.Edit);
                    }
                    else
                        throw new SecurityException("” ¬ас нет прав на редактирование новостей.");
                }
                UpdateTitle();
            }
        }

        protected void dvwNewsletter_ItemCreated(object sender, EventArgs e)
        {
            Control ctl = dvwNewsletter.FindControl("txtBody");
            if (ctl != null)
            {
                FCKeditor txtBody = ctl as FCKeditor;
                txtBody.BasePath = this.BaseUrl + "FCKeditor/";
            }
        }

        protected void dvwNewsletter_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            //ѕосле обновлени€ открываем карточку новости
            if (e.Keys[0] != null)
            {
                //this.Response.Redirect("~/Newsletter.aspx?ID=" + e.Keys[0].ToString());
                this.Response.Redirect("~/Admin/ManageNewsletters.aspx");
            }
        }

        protected void objCurrNewsletter_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                if (e.ReturnValue != null)
                {
                    //this.Response.Redirect("~/Newsletter.aspx?ID=" + e.ReturnValue.ToString());
                    this.Response.Redirect("~/Admin/ManageNewsletters.aspx");
                }
            }
        }

        protected void dvwNewsletter_ModeChanged(object sender, EventArgs e)
        {
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            if (dvwNewsletter.CurrentMode == DetailsViewMode.Insert)
            {
                lblTitle.Text = "ƒобавление новости";
            }
            else
            {
                lblTitle.Text = "–едактирование новости";
            }
            //lblNewArticle.Visible = (dvwArticle.CurrentMode == DetailsViewMode.Insert);
            //lblEditArticle.Visible = !lblNewArticle.Visible;
        }

        protected void dvwNewsletter_DataBound(object sender, EventArgs e)
        {
            if (dvwNewsletter.CurrentMode == DetailsViewMode.Insert)
            {
                AjaxControlToolkit.CalendarExtender cStartDateButtonExtender = dvwNewsletter.FindControl("cStartDateButtonExtender") as AjaxControlToolkit.CalendarExtender;

                if (cStartDateButtonExtender != null)
                {
                    cStartDateButtonExtender.SelectedDate = DateTime.Now;
                }
            }
        }
    }
}