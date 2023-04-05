using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqInternals.Demo
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items,
            Func<T, bool> predicate)
        {
            foreach(var item in items)
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
    }
}
