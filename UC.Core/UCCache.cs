using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace UC.Core
{
    public class UCCache
    {
        private static readonly Cache _cache;

        static UCCache()
        {
            HttpContext current = HttpContext.Current;
            if (current != null)
            {
                _cache = current.Cache;
            }
            else
            {
                _cache = HttpRuntime.Cache;
            }
        }

        private UCCache()
        {
        }

        /// <summary>
        /// ������� ���� ���
        /// </summary>
        public static void Clear()
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                _cache.Remove(enumerator.Key.ToString());
            }
        }
        /// <summary>
        /// �������� �������� ��������������� � ������
        /// </summary>
        /// <param name="key">�������� ��������</param>
        /// <returns>������ ��������������� � ������</returns>
        public static object Get(string key)
        {
            return _cache[key];
        }

        /// <summary>
        /// ��������� ���� � ������ � ���
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="obj">������</param>
        public static void Max(string key, object obj)
        {
            Max(key, obj, null);
        }

        /// <summary>
        /// ��������� ��������� ������� � ���
        /// </summary>
        /// <param name="key">����</param>
        /// <param name="obj">������</param>
        /// <param name="dep">��������� ���</param>
        public static void Max(string key, object obj, CacheDependency dep)
        {
            if (obj != null)
            {
                _cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
            }
        }

        /// <summary>
        /// ������� �������� �� �����
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// ������� �������� �� ���� �� �������
        /// </summary>
        /// <param name="pattern">������</param>
        public static void RemoveByPattern(string pattern)
        {
            IDictionaryEnumerator enumerator = _cache.GetEnumerator();
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    _cache.Remove(enumerator.Key.ToString());
                }
            }
        }
    }
}
