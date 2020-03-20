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
using System.Text.RegularExpressions;

namespace UC.UI.Controls
{
    //public class PagingEventArgs : EventArgs
    //{
    //    int _selectedPage;
    //    public int SelectedPage
    //    {
    //        get { return _selectedPage; }
    //    }

    //    public PagingEventArgs(int selectedPage)
    //    {
    //        _selectedPage = selectedPage;
    //    }
    //}

    public class PagingPage
    {
        int _pageNumber;
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        string _pageView;
        public string PageView
        {
            get { return _pageView; }
            set { _pageView = value; }
        }

        public PagingPage(int pageNumber, string pageView)
        {
            this.PageNumber = pageNumber;
            this.PageView = pageView;
        }
    }

    public partial class Paging : System.Web.UI.UserControl
    {
        //текуща€ страница
        string _sessionKey = "";
        public string SessionKey
        {
            get { return _sessionKey; }
            set { _sessionKey = value; }
        }

        //текуща€ страница
        int _pageIndex = -1;
        public int PageIndex
        {
            get
            {
                if (_pageIndex == -1)
                {
                    if (!String.IsNullOrEmpty(this.Request.QueryString["p"]))
                    {
                        _pageIndex = Int32.Parse(this.Request.QueryString["p"]);
                        Session[SessionKey] = _pageIndex;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(SessionKey))
                        {
                            if (Session[SessionKey] != null)
                            {
                                _pageIndex = (int)Session[SessionKey];
                            }
                        }
                    }
                }

                if (_pageIndex < 1) _pageIndex = 1;

                if (_pageIndex > PagesCount) _pageIndex = 1;

                return _pageIndex;
            }
            set
            {
                _pageIndex = value;

                if (_pageIndex < 1) _pageIndex = 1;

                if (!String.IsNullOrEmpty(SessionKey))
                {
                    Session[SessionKey] = value;
                }
            }
        }

        //устанавливаетс€ программно
        int _productCount = 0;
        public int ProductCount
        {
            get { return _productCount; }
            set
            {
                _productCount = value;
                lblProductCount.Text = _productCount.ToString();
            }
        }

        //устанавливаетс€ программно
        int _maximumRow;
        public int MaximumRow
        {
            get { return _maximumRow; }
            set { _maximumRow = value; }
        }

        //расчетное значение
        int _pagesCount = 0;
        public int PagesCount
        {
            get
            {
                _pagesCount = (int)Math.Ceiling((double)ProductCount / (double)MaximumRow);
                return _pagesCount;
            }
            set { _pagesCount = value; }
        }

        int _startRowIndex;
        public int StartRowIndex
        {
            get
            {
                //_startRowIndex = PageIndex * MaximumRow;
                _startRowIndex = (PageIndex - 1) * MaximumRow;
                return _startRowIndex;
            }
        }

        //устанавливаетс€ программно
        string _browseUrl;
        public string BrowseUrl
        {
            get
            {
                if (String.IsNullOrEmpty(_browseUrl))
                {
                    //foreach (string name in this.Request.QueryString)
                    //{
                    //    _browseUrl = name;
                    //}

                    if (String.IsNullOrEmpty(this.Request.QueryString["p"]))
                    {
                        _browseUrl = this.Request.Url.PathAndQuery;
                    }
                    else
                    {
                        _browseUrl = Regex.Replace(this.Request.Url.PathAndQuery, @"(\?|&)p=([0-9]+)", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                    }

                    if (_browseUrl.Contains("?"))
                    {
                        _browseUrl += "&";
                    }
                    else
                    {
                        _browseUrl += "?";
                    }
                }

                return _browseUrl;
            }
            set
            {
                _browseUrl = value;
            }
        }

        string _titleCount = "¬сего товаров";
        public string TitleCount
        {
            get { return _titleCount; }
            set { _titleCount = value; }
        }

        //public delegate void PageClickedEventHandler(object sender, PagingEventArgs e);

        //public event PageClickedEventHandler PageClicked;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.RegisterRequiresControlState(this);
        }

        protected override void LoadControlState(object savedState)
        {
            object[] ctlState = (object[])savedState;
            this.PageIndex = (int)ctlState[0];
            this.ProductCount = (int)ctlState[1];
            this.MaximumRow = (int)ctlState[2];
            this.SessionKey = (string)ctlState[3];
            this.BrowseUrl = (string)ctlState[4];
        }

        protected override object SaveControlState()
        {
            object[] ctlState = new object[5];
            ctlState[0] = this.PageIndex;
            ctlState[1] = this.ProductCount;
            ctlState[2] = this.MaximumRow;
            ctlState[3] = this.SessionKey;
            ctlState[4] = this.BrowseUrl;
            return ctlState;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //при первой загрузке по умолчанию устанавливаетс€ 1 страница, прорисовываем пейджинг
            lblTitleCount.Text = TitleCount;

            PagingRender();
        }

        protected void PageInc(Object sender, CommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Prev":
            //        {
            //            if (PageIndex > 0)
            //                PageIndex -= 1;
            //            break;
            //        }
            //    case "Next":
            //        {
            //            if (PageIndex < PagesCount - 1)
            //                PageIndex += 1;
            //            break;
            //        }
            //}

            //PagingRender();
        }

        protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //int selectPage = 0;

            //if (e.CommandArgument.ToString() == "...")
            //{
            //    if (e.Item.ItemIndex == 0)
            //    {
            //        LinkButton lbtn = rptPages.Items[1].FindControl("lbtnPage") as LinkButton;

            //        selectPage = Int32.Parse(lbtn.Text) - 1;

            //        if (selectPage < 1)
            //            selectPage = 1;
            //    }
            //    else
            //    {
            //        LinkButton lbtn = rptPages.Items[rptPages.Items.Count - 2].FindControl("lbtnPage") as LinkButton;

            //        selectPage = Int32.Parse(lbtn.Text) + 1;

            //        if (selectPage > PagesCount)
            //            selectPage = PagesCount;
            //    }
            //}
            //else
            //{
            //    selectPage = Int32.Parse(e.CommandArgument.ToString());
            //}

            //PageIndex = selectPage - 1;

            //PagingRender();

            ////генерирование событи€ выбора страницы
            //if (PageClicked != null)
            //{
            //    PagingEventArgs args = new PagingEventArgs(PageIndex);

            //    PageClicked(this, args);
            //}
        }

        public void PagingRender(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            MaximumRow = pageSize;
            PagingRender();
        }

        /// <summary>
        /// »спользуетс€ если необходимо очистить данные о страницах в сессии
        /// </summary>
        public void PagingRender(int pageIndex, int pageSize, string sessionKey)
        {
            BasePage.PurgeSessionItems(sessionKey);

            PageIndex = pageIndex;
            MaximumRow = pageSize;
            PagingRender();
        }

        public void PagingRender(int pageIndex)
        {
            if (pageIndex < PagesCount)
            {
                PageIndex = pageIndex;
            }
            else
            {
                PageIndex = 0;
            }
            PagingRender();
        }

        /// <summary>
        /// »спользуетс€ если необходимо очистить данные о страницах в сессии
        /// </summary>
        public void PagingRender(int pageIndex, string sessionKey)
        {
            BasePage.PurgeSessionItems(sessionKey);

            if (pageIndex < PagesCount)
            {
                PageIndex = pageIndex;
            }
            else
            {
                PageIndex = 1;
            }
            PagingRender();
        }

        public void PagingRender()
        {
            int currentPageIndex = PageIndex;

            if (PagesCount > 1)
            {
                rptPages.Visible = true;

                int firstpage = 0;

                if (currentPageIndex < 3)
                {
                    firstpage = 1;
                }
                else
                {
                    if (PagesCount - currentPageIndex < 2)
                    {
                        firstpage = PagesCount - 4;
                    }
                    else
                    {
                        firstpage = currentPageIndex - 2;
                    }
                }

                if (firstpage < 1) firstpage = 1;

                List<PagingPage> pages = new List<PagingPage>();

                if (firstpage > 1)
                {
                    pages.Add(new PagingPage(firstpage - 1, "..."));
                }

                for (int i = firstpage; i <= firstpage + 4; i++)
                {
                    if (i <= PagesCount)
                    {
                        pages.Add(new PagingPage(i, i.ToString()));
                    }
                }

                if (firstpage + 4 < PagesCount)
                {
                    pages.Add(new PagingPage(firstpage + 5, "..."));
                }

                rptPages.DataSource = pages;
                rptPages.DataBind();
            }
            else
            {
                rptPages.Visible = false;
            }

            lblPageIndex.Text = _pageIndex.ToString();
            lblPagesCount.Text = _pagesCount.ToString();

            lnkPrevTop.Visible = (PageIndex != 1);
            lnkPrevTop.NavigateUrl = BrowseUrl + "p=" + (PageIndex - 1).ToString();
            lnkNextTop.Visible = (PagesCount - 1) < 0 ? false : (PageIndex != PagesCount);
            lnkNextTop.NavigateUrl = BrowseUrl + "p=" + (PageIndex + 1).ToString();
        }

        protected string SetCSS(object dataItem)
        {
            string css = "";
            if (dataItem.ToString() != "...")
            {
                if (Int32.Parse(dataItem.ToString()) == PageIndex)
                {
                    css = "select";
                }
            }

            return css;
        }

        protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink lnk = e.Item.FindControl("lnkPage") as HyperLink;
                if (lnk != null)
                {
                    if (((PagingPage)e.Item.DataItem).PageNumber != PageIndex)
                    {
                        lnk.NavigateUrl = BrowseUrl + "p=" + ((PagingPage)e.Item.DataItem).PageNumber.ToString();
                    }
                }
            }
        }
    }
}