namespace AdventOfCode2020.App.MapArea
{
    public class Hill
    {
        private readonly Slope[] _slopes;
        
        public Hill(params Slope[] slopes)
        {
            _slopes = slopes;
        }

        public int CountTreesOnSlope(int right, int down)
        {
            var treeCount = 0;
            var x = 0;
            for (var y = 0; y < _slopes.Length; y += down)
            {
                if (_slopes[y].HasTreeAt(x)) treeCount++;
                x += right;
            }
            return treeCount;
        }
    }
}