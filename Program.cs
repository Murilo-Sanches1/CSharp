using System;
using Sharp.Extensions;

namespace Sharp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int number = 1;
            Console.WriteLine(number.IsEven());
            number = 2;

            Console.WriteLine(number.IsEven());
            Console.WriteLine((50).IsEven());
        }
    }
}