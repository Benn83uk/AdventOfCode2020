using System.IO;

namespace AdventOfCode2020.App
{
    public class ExpenseReport
    {
        public const int INVALID_RESULT = -1;
        private readonly int[] _expenses;
        
        public ExpenseReport(params int[] expenses)
        {
            _expenses = expenses;
        }

        public ExpenseReport(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            _expenses = ConvertToIntArray(lines);
        }

        public int TwoEntriesWhichAddTo2020Multiplied()
        {
            for (var a = 0; a < _expenses.Length-2; a++)
            {
                for (var b = 1; b < _expenses.Length-1; b++)
                {
                    var result = _expenses[a] + _expenses[b];
                    if (result == 2020)
                    {
                        return _expenses[a] * _expenses[b];
                    }
                }    
            }

            return INVALID_RESULT;
        }

        private static int[] ConvertToIntArray(string[] lines)
        {
            var result = new int[lines.Length];
            for (var i = 0; i < lines.Length; i++)
            {
                result[i] = int.Parse(lines[i]);
            }

            return result;
        }
    }
}