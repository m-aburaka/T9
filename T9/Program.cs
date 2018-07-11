using System;
using System.Collections.Generic;

namespace T9
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (true)
            {
                try
                {
                    Console.WriteLine("Awaiting input");
                    var input = Console.ReadLine();
                    var output = T9Converter.ToKeys(input);
                    Console.WriteLine($"Case #{i++}: {output}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
