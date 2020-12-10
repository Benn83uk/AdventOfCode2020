using System;
using System.Linq;

namespace AdventOfCode2020.App.Joltage
{
    public class AdapterList
    {
        private readonly int[] _adapters;

        public AdapterList(params int[] adapters)
        {
            _adapters = adapters;
        }

        public AdapterDifferences Chain()
        {
            var orderedList = _adapters.Union(new int[]{0,DeviceRating()}).OrderBy(a => a).ToArray();
            return AdapterDifferences(orderedList);
        }

        private static AdapterDifferences AdapterDifferences(int[] orderedList)
        {
            var result = new AdapterDifferences(0,0,0);
            for (var i = 0; i < orderedList.Length - 1; i++)
            {
                var diff = orderedList[i + 1] - orderedList[i];
                result.AddDifference(diff);
            }

            return result;
        }

        private int DeviceRating()
        {
            return _adapters.Max() + 3;
        }

        public long NumArrangements()
        {
            var orderedList = _adapters.Union(new int[]{0,DeviceRating()}).OrderBy(a => a).ToArray();
            return NumArrangements(orderedList);
        }

        private long NumArrangements(int[] orderedList)
        {
            //Console.WriteLine($"Length: {orderedList.Length}");
            //Can only be one way to order 2 or less items
            if (orderedList.Length <= 2) return 1;
            if (orderedList.Length == 3)
            {
                return ((orderedList[2] - orderedList[0] <= 3) ? 2 : 1);
            }
            return
                ((orderedList[1] - orderedList[0] <= 3) ? NumArrangements(orderedList.Skip(1).ToArray()) : 0) +
                ((orderedList[2] - orderedList[0] <= 3) ? NumArrangements(orderedList.Skip(2).ToArray()) : 0) +
                ((orderedList[3] - orderedList[0] <= 3) ? NumArrangements(orderedList.Skip(3).ToArray()) : 0);
        }
        
        // (0) -> 2 -> 3 -> 5 -> (8)
        //                  5 -> (8) -- 1 way
        //             3 -> 5 -> 8 -- 1 way
        //        2 -> 3 -> 5 -> 8 -- 2 ways (2->3 or 2->5)
        // (0) -> 2 -> 3 -> 5 -> (8) -- 2 ways (0->2 or 0->3)
        
    }
}