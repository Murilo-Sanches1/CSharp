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

            DictionaryLogger<string, string>(dict: dict, color: ConsoleColor.Green);

            var initDict = new Dictionary<int, string>() { { 1, "Murilo" }, { 2, "Sanches" } };
            DictionaryLogger<int, string>(initDict);

            initDict.Clear();

            DictionaryLogger<int, string>(initDict);

            var sortedDict = new SortedDictionary<int, string>() { { 5, "cinco" }, { 1, "um" } };
            DictionaryLogger<int, string>(sortedDict);
        }

        public static void DictionaryLogger<Key, Value>(
            IDictionary<Key, Value> dict,
            ConsoleColor color = ConsoleColor.Red)
        {
            if (dict.Count == 0) return;

            Console.ForegroundColor = color;
            Console.WriteLine("====================================");
            foreach (KeyValuePair<Key, Value> item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
            Console.WriteLine("====================================");
            Console.ResetColor();
        }
    }
}