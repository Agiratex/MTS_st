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
            var result = Enumerable.Empty<(T, int?)>();
            if (tailLength == null)
            {
                foreach (T el in enumerable)
                {
                    result = result.Append((el, null));
                }
                return result;
            }

            //Calculate tale lenght in case tailLenght > length(enumerable)
            int numElements = enumerable.Count();
            int? tail;
            if (tailLength > numElements)
            {
                tail = numElements - 1;
                tailLength = numElements;
            }
            else
            {
                tail = tailLength - 1;
            }

            //Enumerating from tail
            int counter = 0;
            foreach (T el in enumerable)
            {
                if (counter >= numElements - tailLength)
                {
                    result = result.Append((el, tail));
                    tail--;
                }
                else
                {
                    result = result.Append((el, null));
                }
                counter++;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            foreach (var el in Enumeration.EnumerateFromTail(a, 6))
            {
                Console.Write($"{el} ");
            }
        }
    }
}
