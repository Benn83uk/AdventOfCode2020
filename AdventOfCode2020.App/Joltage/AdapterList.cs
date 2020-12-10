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
            var result = new AdapterDifferences(0,0,0);
            var orderedList = _adapters.Union(new int[]{0,DeviceRating()}).OrderBy(a => a).ToArray();
            for (var i = 0; i < orderedList.Length-1; i++)
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
    }
}