using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using UC.DAL.Gallery;
using UC.Core;

namespace UC.BLL.Gallery
{
    /// <summary>
    /// �������� ������� ��������
    /// </summary>
    public class PortfolioManager
    {
        private const string PORTFOLIO_ALL_KEY = "UC.portfolio.all";

        /// <summary>
        /// �������� ������ ��������
        /// </summary>
        /// <returns>��������� ��������</returns>
        public static PortfolioCollection GetPortfolio()
        {
            string key = PORTFOLIO_ALL_KEY;
            object obj = UCCache.Get(key);
            if (obj != null)
            {
                return (PortfolioCollection)obj;
            }

            PortfolioCollection portfolioCollection = SqlPortfolioProvider.GetPortfolio();

            UCCache.Max(key, portfolioCollection);

            return portfolioCollection;
        }

        /// <summary>
        /// �������� ������ �� ��������������
        /// </summary>
        /// <param name="ProductAttributeID">������������� �������</param>
        /// <returns>����� �������</returns>
        public static Portfolio GetByPortfolioID(int PortfolioID)
        {
            Portfolio portfolio = SqlPortfolioProvider.GetByPortfolioID(PortfolioID);

            return portfolio;
        }

        /// <summary>
        /// ������� ������
        /// </summary>
        /// <param name="ProductAttributeID">������������� �������</param>
        public static void DeletePortfolio(int PortfolioID)
        {
            bool ret = SqlPortfolioProvider.DeletePortfolio(PortfolioID);

            new RecordDeletedEvent("Portfolio", PortfolioID, null).Raise();

            UCCache.RemoveByPattern(PORTFOLIO_ALL_KEY);
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        public static Portfolio InsertPortfolio
            (
            string Description,
            string ImageUrl,
            int DisplayOrder
            )
        {
            Portfolio portfolio = SqlPortfolioProvider.InsertPortfolio
                (
                Description, 
                ImageUrl, 
                DisplayOrder
                );

            UCCache.RemoveByPattern(PORTFOLIO_ALL_KEY);

            return portfolio;
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        public static Portfolio UpdatePortfolio
            (
            int PortfolioID,
            string Description,
            string ImageUrl,
            int DisplayOrder
            )
        {
            Portfolio portfolio = SqlPortfolioProvider.UpdatePortfolio
                (
                PortfolioID,
                Description,
                ImageUrl,
                DisplayOrder
                );

            UCCache.RemoveByPattern(PORTFOLIO_ALL_KEY);

            return portfolio;
        }
    }
}
