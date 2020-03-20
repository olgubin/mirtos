using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Web.Caching;

namespace UC.DAL
{
    public abstract class DataAccess
    {
        private string _connectionString = "";
        protected string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private bool _enableCaching = true;
        protected bool EnableCaching
        {
            get { return _enableCaching; }
            set { _enableCaching = value; }
        }

        private int _cacheDuration = 0;
        protected int CacheDuration
        {
            get { return _cacheDuration; }
            set { _cacheDuration = value; }
        }

        protected Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        static protected int ExecuteNonQuery(DbCommand cmd)
        {
            if (HttpContext.Current.User.Identity.Name.ToLower() == "sampleeditor")
            {
                foreach (DbParameter param in cmd.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output ||
                       param.Direction == ParameterDirection.ReturnValue)
                    {
                        switch (param.DbType)
                        {
                            case DbType.AnsiString:
                            case DbType.AnsiStringFixedLength:
                            case DbType.String:
                            case DbType.StringFixedLength:
                            case DbType.Xml:
                                param.Value = "";
                                break;
                            case DbType.Boolean:
                                param.Value = false;
                                break;
                            case DbType.Byte:
                                param.Value = byte.MinValue;
                                break;
                            case DbType.Date:
                            case DbType.DateTime:
                                param.Value = DateTime.MinValue;
                                break;
                            case DbType.Currency:
                            case DbType.Decimal:
                                param.Value = decimal.MinValue;
                                break;
                            case DbType.Guid:
                                param.Value = Guid.Empty;
                                break;
                            case DbType.Double:
                            case DbType.Int16:
                            case DbType.Int32:
                            case DbType.Int64:
                                param.Value = 0;
                                break;
                            default:
                                param.Value = null;
                                break;
                        }
                    }
                }
                return 1;
            }
            else
                return cmd.ExecuteNonQuery();
        }

        static protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        static protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        static protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        static protected bool GetBoolean(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return false;
            }
            return Convert.ToBoolean(rdr[index]);
        }

        static protected byte[] GetBytes(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (byte[])rdr[index];
        }

        static protected DateTime GetDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return DateTime.MinValue;
            }
            return (DateTime)rdr[index];
        }

        static protected DateTime? GetNullableDateTime(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (DateTime)rdr[index];
        }

        static protected decimal GetDecimal(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return decimal.Zero;
            }
            return Convert.ToDecimal(rdr[index]);
        }

        static protected double GetDouble(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0.0;
            }
            return (double)rdr[index];
        }

        static protected Guid GetGuid(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return Guid.Empty;
            }
            return (Guid)rdr[index];
        }

        static protected int GetInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return 0;
            }
            return (int)rdr[index];
        }

        static protected int? GetNullableInt(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return null;
            }
            return (int)rdr[index];
        }

        static protected string GetString(IDataReader rdr, string columnName)
        {
            int index = rdr.GetOrdinal(columnName);
            if (rdr.IsDBNull(index))
            {
                return string.Empty;
            }
            return (string)rdr[index];
        }
    }
}
