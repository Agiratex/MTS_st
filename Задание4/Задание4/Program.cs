using System;
using System.Collections.Generic;
using System.Linq;

namespace Задание4
{
    class Program
    {
        static IEnumerable<int> MergeSort(IEnumerable<int> unsorted)
        {
            if (unsorted.Count() < 2)
            {
                return unsorted;
            }
            var leftPart = MergeSort(unsorted.Take(unsorted.Count() / 2)); 
            var rightPart = MergeSort(unsorted.Skip(unsorted.Count() / 2));

            var leftEnum = leftPart.GetEnumerator();
            leftEnum.MoveNext();
            var rightEnum = rightPart.GetEnumerator();
            rightEnum.MoveNext();
            var sorted = Enumerable.Empty<int>();
            bool leftEmpty = false;
            bool rightEmpty = false;

            while(!leftEmpty & !rightEmpty)
            {
                if (rightEnum.Current > leftEnum.Current)
                {
                    sorted = sorted.Append(leftEnum.Current);
                    if(!leftEnum.MoveNext())
                    {
                        leftEmpty = true;
                    }
                }
                else
                {
                    sorted = sorted.Append(rightEnum.Current);
                    if(!rightEnum.MoveNext())
                    {
                        rightEmpty = true;
                    }
                }
            };

            if(leftEmpty)
            {
                do
                {
                    sorted = sorted.Append(rightEnum.Current);
                } while (rightEnum.MoveNext());
            }else
            {
                do
                {
                    sorted = sorted.Append(leftEnum.Current);
                } while (leftEnum.MoveNext());
            }
            return sorted;
        }
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (!inputStream.Any())
            {
                throw new ArgumentOutOfRangeException("Void collection");
            }
            var outputStream = inputStream.Where(el => el <= maxValue); //t = O(n), memory = O(n)
            int minValue = outputStream.Max() - sortFactor;             //t = O(n), memory = O(1)
            outputStream = outputStream.Where(el => el >= minValue);    //t = O(n), memory = O(n)

            //return outputStream.OrderBy(el => el);                    //t = O(n*log(n))
            return MergeSort(outputStream);                             //t = o(n*log(n))
        }
        static void Main(string[] args)
        {
            int[] a = new int[5] { 5, 4, 3, 2, 1};
            foreach (int el in Sort(a, 5, 5))
            {
                Console.Write($"{el} ");
            }
        }
    }
}
