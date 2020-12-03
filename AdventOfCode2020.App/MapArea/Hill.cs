using System.IO;
using System.Runtime.Serialization;

namespace AdventOfCode2020.App.MapArea
{
    public class Hill
    {
        private readonly Slope[] _slopes;
        
        public Hill(params Slope[] slopes)
        {
            _slopes = slopes;
        }

        public Hill(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            _slopes = new Slope[lines.Length];
            for (var i = 0; i < lines.Length; i++)
            {
                _slopes[i] = new Slope(lines[i]);
            }
        }

        public int CountTreesOnSlope(Gradient g)
        {
            return CountTreesOnSlope(g.Right, g.Down);
        }

        private int CountTreesOnSlope(int right, int down)
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

        public int ProductOfTreesOnSlopes(params Gradient[] gradients)
        {
            var product = CountTreesOnSlope(gradients[0]);
            for (var i = 1; i < gradients.Length; i++)
            {
                product *= CountTreesOnSlope(gradients[i]);
            }

            return product;
        }
    }
}