namespace AdventOfCode2020.App.BusTerminal
{
    //From https://github.com/RaczeQ/AdventOfCode2020/blob/bd5c5fcba101f2d2f7516eb025efaaef052408d0/ElvenTools/Utils/MathExtension.cs
    public class MathExtension
    {
        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;
        }
    }
}