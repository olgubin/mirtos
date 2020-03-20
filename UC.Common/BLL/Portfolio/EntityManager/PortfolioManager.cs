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
    /// Менеджер галереи объектов
    /// </summary>
    public class PortfolioManager
    {
        private const string PORTFOLIO_ALL_KEY = "UC.portfolio.all";

        /// <summary>
        /// Получить список объектов
        /// </summary>
        /// <returns>коллекция объектов</returns>
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
        /// Получает объект по идентификатору
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор объекта</param>
        /// <returns>Класс объекта</returns>
        public static Portfolio GetByPortfolioID(int PortfolioID)
        {
            Portfolio portfolio = SqlPortfolioProvider.GetByPortfolioID(PortfolioID);

            return portfolio;
        }

        /// <summary>
        /// Удаляет объект
        /// </summary>
        /// <param name="ProductAttributeID">идентификатор объекта</param>
        public static void DeletePortfolio(int PortfolioID)
        {
            bool ret = SqlPortfolioProvider.DeletePortfolio(PortfolioID);

            new RecordDeletedEvent("Portfolio", PortfolioID, null).Raise();

            UCCache.RemoveByPattern(PORTFOLIO_ALL_KEY);
        }

        /// <summary>
        /// Добавить объект
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
        /// Обновить объект
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
