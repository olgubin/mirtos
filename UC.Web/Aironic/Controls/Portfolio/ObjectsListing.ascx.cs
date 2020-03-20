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
using UC.UI;
using UC.BLL.Gallery;

namespace UC.UI.Controls
{
    public partial class ObjectsListing : BaseWebPart
    {
        private int _RepeatColumns = -1;
        public int RepeatColumns
        {
            get { return _RepeatColumns; }
            set { _RepeatColumns = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                DoBinding();
        }

        protected void DoBinding()
        {
            int RepeatColumns = (this.RepeatColumns == -1 ? 2 : this.RepeatColumns);

            PortfolioCollection portfolioCollection = PortfolioManager.GetPortfolio();

            CreateTable(portfolioCollection);
        }

        protected void CreateTable(PortfolioCollection portfolioCollection)
        {
            if (portfolioCollection.Count > 0)
            {
                int k = 0;

                int rowCount = (int)Math.Ceiling(portfolioCollection.Count / (decimal)RepeatColumns);

                for (int i = 0; i < rowCount; i++)
                {
                    TableRow first_row = new TableRow();
                    TableRow second_row = new TableRow();

                    for (int j = 0; j < RepeatColumns; j++)
                    {
                        TableHeaderCell first_cell = new TableHeaderCell();
                        TableCell second_cell = new TableCell();

                        if (k < portfolioCollection.Count)
                        {
                            first_cell.Text = portfolioCollection[k].Description;
                             
                            Image img = new Image();
                            img.GenerateEmptyAlternateText = true;
                            img.ImageUrl = portfolioCollection[k].ImageUrl;

                            second_cell.Controls.Add(img);

                            k++;
                        }

                        first_row.Cells.Add(first_cell);
                        second_row.Cells.Add(second_cell);
                    }

                    tblObjects.Rows.Add(first_row);
                    tblObjects.Rows.Add(second_row);
                }
            }
        }
    }
}