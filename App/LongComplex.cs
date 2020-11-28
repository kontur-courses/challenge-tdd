using System;

namespace App
{
    public struct LongComplex
    {
        public long Real { get; }
        public long Imaginary { get; }

        public LongComplex(long real, long imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static LongComplex Add(LongComplex a, LongComplex b)
        {
            return new LongComplex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static LongComplex Subtract(LongComplex a, LongComplex b)
        {
            return new LongComplex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static LongComplex Multiply(LongComplex a, LongComplex b)
        {
            var real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            var imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new LongComplex(real, imaginary);
        }

        public static LongComplex Zero = new LongComplex(0, 0);

        public override string ToString()
        {
            if (Imaginary == 0)
                return $"{Real}";

            var imaginaryAbs = Math.Abs(Imaginary);
            var imaginaryString = imaginaryAbs == 1 ? "i" : $"{imaginaryAbs}i";

            if (Real == 0)
                return Imaginary >= 0 ? imaginaryString : $"-{imaginaryString}";

            return Imaginary >= 0 ? $"{Real}+{imaginaryString}" : $"{Real}-{imaginaryString}";
        }

        public static LongComplex Parse(string str)
        {
            if (str.EndsWith("i"))
            {
                var strWithoutI = str.Substring(0, str.Length - 1);
                if (strWithoutI.Contains("+"))
                {
                    var parts = strWithoutI.Split("+");
                    return new LongComplex(
                        long.Parse(parts[0].Trim()),
                        ParseImaginary(parts[1]));
                }
                if (strWithoutI.Length > 0 && strWithoutI.IndexOf("-", 1) >= 0)
                {
                    var parts = strWithoutI.Split("-");
                    var real = long.Parse(parts[parts.Length - 2].Trim());
                    if (parts.Length == 3)
                        real *= -1;
                    return new LongComplex(real,
                        -ParseImaginary(parts[parts.Length - 1]));
                }
                return new LongComplex(0, ParseImaginary(strWithoutI));
            }
            else
            {
                var real = long.Parse(str);
                return new LongComplex(real, 0);
            }
        }

        private static long ParseImaginary(string str)
        {
            str = str.Trim();
            if (str == "-")
                return -1L;
            if (str == string.Empty)
                return 1L;
            return long.Parse(str);
        }
    }
}
