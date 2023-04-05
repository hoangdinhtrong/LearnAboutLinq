using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInternals.Demo.Extensions
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// WHERE EXTENSION IN LINQ
        /// </summary>
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }

            //// SOLUTION 2
            //List<T> list = new List<T>();
            //foreach (var item in items)
            //{
            //    if (predicate(item))
            //    {
            //        list.Add(item);
            //    }
            //}
            //return list;
        }

        /// <summary>
        /// SELECT EXTENSION IN LINQ
        /// </summary>
        public static IEnumerable<TResult> NewSelect<T, TResult>(this IEnumerable<T> items,
            Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }

        /// <summary>
        /// SELECT MANY EXTENSION IN LINQ
        /// </summary>
        public static IEnumerable<TResult> NewManySelect<T, TResult>(this IEnumerable<T> items,
            Func<T, IEnumerable<TResult>> selector)
        {
            foreach (var item in items)
            {
                foreach(var innerItem in selector(item))
                {
                    yield return innerItem;
                }
            }
        }
    }
}
