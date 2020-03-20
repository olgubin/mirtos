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
        /// Очищает весь кэш
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
        /// Получает значение ассоциированное с ключом
        /// </summary>
        /// <param name="key">Ключевое значение</param>
        /// <returns>Объект ассоциированный с ключом</returns>
        public static object Get(string key)
        {
            return _cache[key];
        }

        /// <summary>
        /// Добавляет ключ и объект в кэш
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="obj">объект</param>
        public static void Max(string key, object obj)
        {
            Max(key, obj, null);
        }

        /// <summary>
        /// Добавляет зависимые объекты в кэш
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="obj">объект</param>
        /// <param name="dep">зависимый кэш</param>
        public static void Max(string key, object obj, CacheDependency dep)
        {
            if (obj != null)
            {
                _cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);
            }
        }

        /// <summary>
        /// Удаляет значение по ключу
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// Удаляет значения из кэша по шаблону
        /// </summary>
        /// <param name="pattern">шаблон</param>
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
