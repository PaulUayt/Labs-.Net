using System;
using System.Collections.Generic;
using MyDictionary;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new MyDictionary<int, string>();

            dict.OnAdd += ChangeInCollections;            
            dict.OnRemove += ChangeInCollections;
            dict.OnClear += ChangeInCollections;

            dict.Add(new KeyValuePair<int, string>(1, "One"));
            dict.Add(new KeyValuePair<int, string>(2, "Two"));
            dict.Add(new KeyValuePair<int, string>(3, "Three"));
            dict.Add(new KeyValuePair<int, string>(4, "Four"));
            dict.Add(new KeyValuePair<int, string>(5, "Five"));
            dict.Add(8, null);
            dict.Add(101, "101");
            /*dict.Add(102, "102");
            dict.Add(103, "103");
            dict.Add(104, "104");
            dict.Add(106, "106");
            dict.Add(105, "105");
            dict.Add(1001, "1000");
             */
            

            /*dict[15] = "Jok";*/

            Console.WriteLine("Add elements:\n");
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nCount elements: {dict.Count}");
            /*Console.WriteLine(dict.IndexOf(1));

            Console.WriteLine("\nKeys:\n");
            foreach (var item in dict.Keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nValues:\n");
            foreach (var item in dict.Values)
            {
                Console.WriteLine(item);
            }


            
            Console.WriteLine(dict[1]);

            dict.Remove(new KeyValuePair<int, string>(3, "Three"));
            dict.Remove(new KeyValuePair<int, string>(4, "Four"));
            dict.Remove(10);
            dict.Remove(102);
            dict.Remove(105);

            Console.WriteLine("\nElements after remove:\n");
            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }

            dict.Add(106, "106");
            dict.Add(105, "105");
            dict.Add(101, "101");

            //dict.TryGetValue(2, out string val);
            /*Console.WriteLine();
            Console.WriteLine(dict.TryGetValue(2, out string val) + val);


            Console.WriteLine("\nSearch elements:\n");
            Console.WriteLine("1 {0}", dict.Search(2));
            Console.WriteLine("2 {0}", dict.Search(3));
            Console.WriteLine("3 {0}", dict.Search(101));

            Console.WriteLine($"\nCount elements: {dict.Count}");

            var arr = new KeyValuePair<int, string>[dict.Count * 2];

            Console.WriteLine($"\nCopyTo:");

            dict.CopyTo(arr, 4);

            for (var i = 0; i < dict.Count * 2; i++)
            {
                Console.WriteLine(((i + 1) + " ") + (arr[i].Value));
            }

            /*Console.WriteLine("\nContains:\n");
            Console.WriteLine(dict.Contains(new KeyValuePair<int, string>(1, "One")));
            Console.WriteLine(dict.Contains(new KeyValuePair<int, string>(8, null)));
            Console.WriteLine(dict.Contains(new KeyValuePair<int, string>(8, "")));
            Console.WriteLine(dict.ContainsKey(101));
            
            Console.WriteLine("\nClear\n");
            dict.Clear();

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }*/

            Console.WriteLine("\nEnd\n");
        }

        private static void ChangeInCollections(Object sender, EventArgs e)
        {
            Console.WriteLine("Collection is changed");
        }
    }
}
