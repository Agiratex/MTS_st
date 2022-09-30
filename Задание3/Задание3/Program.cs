using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание3
{
    public static class Enumeration
    {
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            //If tailLenght isn't defined
            var result = new List<(T, int?)>();
            if (tailLength == null)
            {
                foreach (T el in enumerable)
                {
                    result.Add((el, null));
                }
                return result;
            }

            var tail = new List<T>();
            foreach (T el in enumerable)
            {
                tail.Add(el);
                if (tail.Count > tailLength)
                {
                    result.Add((tail[0], null));
                    tail.RemoveAt(0);
                }
            }
            for (int i = 0; i < tail.Count; i++)
            {
                result.Add((tail[i], tail.Count - i - 1));
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            foreach (var el in Enumeration.EnumerateFromTail(a, 0))
            {
                Console.Write($"{el} ");
            }
        }
    }
}
