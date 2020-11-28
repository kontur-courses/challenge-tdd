using System;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("eXtreme Programming rulez!");
            Console.WriteLine($"2*2 = {MathSolver.Solve("2*2")}");
            Console.ReadLine();
        }
    }
}
