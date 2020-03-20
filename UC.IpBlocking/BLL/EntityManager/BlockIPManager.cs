using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Web;
using UC.IpBlocking.DAL;
using UC.Core;

namespace UC.IpBlocking.BLL
{
    /// <summary>
    /// Менеджер валют
    /// </summary>
    public class BlockIpManager
    {
        private const string BLOCKIPS_ALL_KEY = "UC.blockip.all-{0}";
        private const string BLOCKIPS_KEY = "UC.blockip.ip-{0}";

        public static BlockIpCollection GetBlockIps(string sortExpression)
        {
            if (sortExpression == null)
                sortExpression = "";

            string key = string.Format(BLOCKIPS_ALL_KEY,sortExpression);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (BlockIpCollection)obj2;
            }

            BlockIpCollection blockIpCollection = SqlBlockIpProvider.GetBlockIps(sortExpression);
            UCCache.Max(key, blockIpCollection);

            return blockIpCollection;
        }

        public static BlockIp GetBlockIpByIp(string Ip)
        {
            string key = string.Format(BLOCKIPS_KEY, Ip);
            object obj2 = UCCache.Get(key);
            if (obj2 != null)
            {
                return (BlockIp)obj2;
            }

            BlockIp blockIp = SqlBlockIpProvider.GetBlockIpByIp(Ip);
            UCCache.Max(key, blockIp);
            return blockIp;
        }

        public static bool CheckBlockIp(string Ip)
        {
            BlockIp blockIp = GetBlockIpByIp(Ip);

            bool ret;

            if (blockIp == null)
            {
                ret = false;
            }
            else
            {
                ret = blockIp.Block;
            }

            return ret;
        }

        public static bool CheckIgnoreIp(string Ip)
        {
            BlockIp blockIp = GetBlockIpByIp(Ip);

            bool ret;

            if (blockIp == null)
            {
                ret = false;
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        public static bool LockIp(string Ip, bool Block)
        {
            bool ret = SqlBlockIpProvider.LockIp(Ip, Block);

            UCCache.RemoveByPattern("blockip");

            return ret;
        }

        public static bool InsertBlockIp
            (
            string Ip,
            string Comment,
            DateTime DateLast,
            bool Block
            )
        {
            bool ret = SqlBlockIpProvider.InsertBlockIp
                (
                Ip,
                Comment,
                DateLast,
                Block
                );

            UCCache.RemoveByPattern("blockip");

            return ret;
        }

        public static bool UpdateBlockIp
            (
            string Ip,
            string Comment,
            DateTime DateLast,
            bool Block
            )
        {
            bool ret = SqlBlockIpProvider.UpdateBlockIp
                (
                Ip,
                Comment,
                DateLast,
                Block
                );

            UCCache.RemoveByPattern("blockip");

            return ret;
        }

        public static void DeleteBlockIp(string Ip)
        {
            bool ret = SqlBlockIpProvider.DeleteBlockIp(Ip);

            UCCache.RemoveByPattern("blockip");
        }
    }
}
