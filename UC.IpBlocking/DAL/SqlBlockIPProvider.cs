using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using UC.DAL;
using UC.IpBlocking.BLL;

namespace UC.IpBlocking.DAL
{
    internal class SqlBlockIpProvider : DataAccess
    {
        public static BlockIpCollection GetBlockIps(string sortExpression)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_Get", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                sortExpression = EnsureValidSortExpression(sortExpression);
                cmd.Parameters.Add("@sortExpression", SqlDbType.NVarChar).Value = sortExpression;
                cn.Open();
                return GetBlockIpCollectionFromReader(ExecuteReader(cmd));
            }
        }

        public static BlockIp GetBlockIpByIp(string Ip)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_GetByIp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
                cn.Open();
                IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetBlockIpFromReader(reader);
                else
                    return null;
            }
        }

        //public static bool CheckBlockIp(string Ip)
        //{
        //    using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("UC_BlockIp_Check", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
        //        cmd.Parameters.Add("@Block", SqlDbType.Bit).Value = true;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret == 1);
        //    }
        //}

        //public static bool CheckIgnoreIp(string Ip)
        //{
        //    using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("UC_BlockIp_Check", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
        //        cmd.Parameters.Add("@Block", SqlDbType.Bit).Value = false;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret == 1);
        //    }
        //}

        public static bool LockIp(string Ip, bool Block)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_LockIp", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
                cmd.Parameters.Add("@Block", SqlDbType.NVarChar).Value = Block;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static bool InsertBlockIp
            (
            string Ip,
            string Comment,
            DateTime DateLast,
            bool Block
            )
        {
            BlockIp blockIp = null;

            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_Insert", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = Comment;
                cmd.Parameters.Add("@DateLast", SqlDbType.DateTime).Value = DateLast;
                cmd.Parameters.Add("@Block", SqlDbType.NVarChar).Value = Block;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
        }

        public static bool UpdateBlockIp
            (
            string Ip,
            string Comment,
            DateTime DateLast,
            bool Block
            )
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_Update", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = Comment;
                cmd.Parameters.Add("@DateLast", SqlDbType.DateTime).Value = DateLast;
                cmd.Parameters.Add("@Block", SqlDbType.NVarChar).Value = Block;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        public static bool DeleteBlockIp(string Ip)
        {
            using (SqlConnection cn = new SqlConnection(Globals.Settings.Store.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UC_BlockIp_Delete", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IP", SqlDbType.NVarChar).Value = Ip;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// ¬озвращает коллекцию разделов из ридера
        /// </summary>
        public static BlockIpCollection GetBlockIpCollectionFromReader(IDataReader reader)
        {
            BlockIpCollection blockIpCollection = new BlockIpCollection();

            while (reader.Read())
                blockIpCollection.Add(GetBlockIpFromReader(reader));

            return blockIpCollection;
        }

        /// <summary>
        /// ¬озвращает раздел из текущей записи ридера
        /// </summary>
        public static BlockIp GetBlockIpFromReader(IDataReader reader)
        {
            BlockIp blockIp = new BlockIp();
            blockIp.Ip = GetString(reader, "IP");
            blockIp.Comment = GetString(reader, "Comment");
            blockIp.DateLast = GetDateTime(reader, "DateLast");
            blockIp.DateAdd = GetDateTime(reader, "DateAdd");
            blockIp.Block = GetBoolean(reader, "Block");

            return blockIp;
        }

        /// <summary>
        /// ¬озвращает выражение сортировки дл€ поисковых запросов
        /// </summary>
        public static string EnsureValidSortExpression(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return "dateadd desc";

            string sortExpr = sortExpression.ToLower();
            if (!sortExpr.Equals("dateadd") && !sortExpr.Equals("dateadd asc") && !sortExpr.Equals("dateadd desc") &&
                !sortExpr.Equals("ip") && !sortExpr.Equals("ip asc") && !sortExpr.Equals("ip desc") &&
                !sortExpr.Equals("comment") && !sortExpr.Equals("comment asc") && !sortExpr.Equals("comment desc") &&
                !sortExpr.Equals("block") && !sortExpr.Equals("block asc") && !sortExpr.Equals("block desc") &&
               !sortExpr.Equals("datelock") && !sortExpr.Equals("datelock asc") && !sortExpr.Equals("datelock desc"))
            {
                sortExpr = "dateadd desc";
            }
            if (!sortExpr.StartsWith("dateadd"))
                sortExpr += ", dateadd desc";
            return sortExpr;
        }
    }
}
