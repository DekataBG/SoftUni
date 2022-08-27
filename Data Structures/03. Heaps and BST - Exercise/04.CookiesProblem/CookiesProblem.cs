using System;
using System.Linq;
//using System.Net.Http.Headers;
//using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        //public int Solve2(int minSweetness, int[] cookies)
        //{
        //    var minHeap = new MinHeap<int>();

        //    foreach (var cookie in cookies)
        //    {
        //        minHeap.Add(cookie);
        //    }

        //    var operations = 0;

        //    while (!IsConditionSatisfied(minSweetness, minHeap))
        //    {
        //        try
        //        {
        //            minHeap = Mix(minHeap);
        //        }
        //        catch (Exception)
        //        {
        //            return -1;
        //        }

        //        operations++;
        //    }

        //    return operations;
        //}

        //private bool IsConditionSatisfied(int minSweetness, MinHeap<int> heap)
        //{
        //    return minSweetness < heap.Peek();
        //}

        //private MinHeap<int> Mix(MinHeap<int> heap)
        //{
        //    var min1 = heap.ExtractMin();
        //    var min2 = heap.ExtractMin();

        //    var mixed = min1 + 2 * min2;

        //    heap.Add(mixed);

        //    return heap;
        //}

        public int Solve(int minSweetness, int[] cookies)
        {
            OrderedBag<int> cookieBag = new OrderedBag<int>();
            cookieBag.AddMany(cookies);

            int steps = 0;
            int currSweetness = cookieBag.GetFirst();
            while (currSweetness < minSweetness && cookieBag.Count > 1)
            {
                int firstCookie = cookieBag.RemoveFirst();
                int secondCookie = cookieBag.RemoveFirst();

                int newCookie = firstCookie + 2 * secondCookie;
                cookieBag.Add(newCookie);
                currSweetness = cookieBag.GetFirst();

                steps++;
            }

            return currSweetness < minSweetness ? -1 : steps;
        }
    }
}
