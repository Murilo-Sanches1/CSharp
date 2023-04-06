using System;
using System.Collections.Generic;
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

            Dictionary<String, string> dict = new Dictionary<string, string>();
            dict.Add("key", "value");
            try
            {
                dict.Add("key", "value");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"key\" already exists.");
            }

            dict["key"] = "Outro Value";

            dict["key2"] = "Criando";

            string value = "";
            Console.WriteLine($"{(dict.TryGetValue("nonexistent", out value) ? "Existe" : "Inexistente")}");

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}