using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.App.Joltage
{
    public class AdapterList
    {
        private readonly int[] _tribbanaciSequence = new[] {1, 1, 2, 4, 7, 13, 24};
        private readonly int[] _adapters;

        public AdapterList(params int[] adapters)
        {
            _adapters = adapters;
        }

        public AdapterDifferences Chain()
        {
            var orderedList = _adapters.Union(new int[] { 0, DeviceRating() }).OrderBy(a => a).ToArray();
            return AdapterDifferences(orderedList);
        }

        private static AdapterDifferences AdapterDifferences(int[] orderedList)
        {
            var result = new AdapterDifferences(0, 0, 0);
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
            var orderedList = _adapters.Union(new int[] { 0, DeviceRating() }).OrderBy(a => a).ToArray();
            return NumArrangementsByPattern(orderedList);
        }

        private long NumArrangements(int[] orderedList)
        {
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

        private long NumArrangementsByPattern(int[] orderedList)
        {
            var groupLengths = GroupsOfDiffOne(orderedList);
            return MultiplyGroupsByTribannaci(groupLengths);
        }

        private long MultiplyGroupsByTribannaci(List<int> groupLengths)
        {
            long result = 1;
            foreach (var length in groupLengths.Where(l => l > 1))
            {
                result = result * _tribbanaciSequence[length];
            }

            return result;
        }

        private static List<int> GroupsOfDiffOne(int[] orderedList)
        {
            var groupLengths = new List<int>();
            for (var i = 0; i < orderedList.Length; i++)
            {
                var currentGroup = 0;
                for (var x = i; x < orderedList.Length - 1; x++)
                {
                    if (orderedList[x + 1] - orderedList[x] == 1)
                    {
                        currentGroup++;
                    }
                    else
                    {
                        i = x;
                        break;
                    }
                }

                groupLengths.Add(currentGroup);
            }

            return groupLengths;
        }

        // (0) -> 2 -> 3 -> 5 -> (8)
        //                  5 -> (8) -- 1 way
        //             3 -> 5 -> 8 -- 1 way
        //        2 -> 3 -> 5 -> 8 -- 2 ways (2->3 or 2->5)
        // (0) -> 2 -> 3 -> 5 -> (8) -- 2 ways (0->2 or 0->3)

        //Differences
        // (0) -> 1 -> 2 -> 3 -> 4 -> (7)
        //      1    1    1    1   3
        //     [1111 = 7] = 7

        //Differences
        // (0) -> 1 -> 4 -> (7)
        //      1    3   3
        //     [1 = 1] = 1

        //Differences
        // (0) -> 1 -> 4 -> 5 ->  (8)
        //      1    3   1    3
        //     [1 = 1] [1=1]       [Answer 1]


        //Differences
        // (0) -> 1 -> 4 -> 5 -> 6 ->  (9)
        //      1    3   1    1    3
        //     [1 = 1]   [11=3]    [Answer: 3]

        //Differences
        // (0) -> 1 -> 4 -> 5 -> 6 -> 9 -> 10 -> 11 -> (14)
        //      1    3   1    1    3    1     1     3
        //     [1 = 1]   [11=3]           [11=3]
    }
}