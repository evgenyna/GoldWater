using System;

namespace GoldWater
{
    public static class Hadadi
    // בדיקה האם מספר זוגי או אי-זוגי 
    {
        // Returns true if n is even, false otherwise.
        public static bool IsEven(int n)
        {
            if (n < 0) n = Math.Abs(n);
            if (n == 0) return true;
            return IsOdd(n - 1);
        }

        // Returns true if n is odd, false otherwise.
        public static bool IsOdd(int n)
        {
            if (n < 0) n = Math.Abs(n);
            if (n == 0) return false;
            return IsEven(n - 1);
        }
    }

    public static class Mod
    {
        // חישוב שארית החלוקה של שני מספרים שלמים
        // Recursive modulo: returns a % b for non-negative operands.
        public static int Modulo(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Modulo by zero");
            if (a < 0) a = Math.Abs(a);
            if (a == b) return 0;
            if (a < b) return a;
            return Modulo(a - b, b);
        }
    }

    public static class OddFactorial
    // עצרת של מספרים האי-זוגיים
    {
        // Returns the product of all odd positive integers <= n.
        public static long Compute(int n)
        {
            if (n <= 1) return 1;
            if (n % 2 == 1) return n * Compute(n - 1);
            return Compute(n - 1);
        }
    }

    public static class Div
    // בדיקה האם מספר שלם מחלק מספר שלם אחר ללא שארית
    {
        // Returns true if a is divisible by b using recursive subtraction.
        public static bool IsDiv(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Division by zero");
            if (a < 0) a = Math.Abs(a);
            if (b < 0) b = Math.Abs(b);
            if (a == b) return true;
            if (a < b) return false;
            return IsDiv(a - b, b);
        }
    }

    public static class Gcd
    // מציאת המחלק המשותף הגדול ביותר של שני מספרים טבעיים
    {
        // Returns the greatest common divisor of a and b using recursive subtraction.
        public static int Compute(int a, int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException("gcd(0,0) is undefined");
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a > b) return Compute(a - b, b);
            return Compute(a, b - a);
        }
    }

    public static class Length
    // חישוב מספר הספרות במספר שלם
    {
        // Returns the number of digits in num using recursion.
        public static int IntLength(long num)
        {
            if (num < 0) num = Math.Abs(num);
            if (num == 0) 
                return 0;
            return 1 + IntLength(num / 10);
        }
    }

    public static class Exists
    // בדיקה האם ספרה מופיעה במספר
    {
        // Returns true if digit d exists in num using recursion.
        public static bool IsExists(long num, int d)
        {
            if (d < 0 || d > 9) throw new ArgumentOutOfRangeException(nameof(d), "d must be between 0 and 9");
            if (num < 0) num = Math.Abs(num);
            if (num == 0) 
                return false;
            if (num % 10 == d) 
                return true;
            return 
                IsExists(num / 10, d);
        }
    }

    public static class Dec2Bin
    // העברה מספר טבעי מייצוג עשרוני לייצוג בינארי
    {
        // Converts a decimal integer to its binary representation using recursion.
        public static string DecToBin(int n)
        {
            if (n == 0) return "0";
            bool neg = n < 0;
            long num = Math.Abs((long)n);
            string bin = ToBin(num);
            return neg ? "-" + bin : bin;
        }

        private static string ToBin(long n)
        {
            if (n == 0) return "";
            return ToBin(n / 2) + (n % 2).ToString();
        }
    }



    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Hadadi.IsEven(5));
        }
    }
}

