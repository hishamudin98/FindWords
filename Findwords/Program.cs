using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static readonly int MAX_CHAR = 26;
        static String getKey(String str)
        {
            bool[] visited = new bool[MAX_CHAR];

            // Store all unique characters of current
            // word in key
            for (int j = 0; j < str.Length; j++)
                visited[str[j] - 'a'] = true;

            String key = "";

            for (int j = 0; j < MAX_CHAR; j++)
                if (visited[j])
                    key = key + (char)('a' + j);

            return key;
        }

        static void wordsWithSameCharSet(String[] words, int n)
        {
            Dictionary<String, List<int>> Hash = new Dictionary<String, List<int>>();

            // Traverse all words
            for (int i = 0; i < n; i++)
            {
                String key = getKey(words[i]);

                if (Hash.ContainsKey(key))
                {
                    List<int> get_all = Hash[key];
                    get_all.Add(i);
                    Hash[key] = get_all;
                }
                else
                {
                    List<int> new_all = new List<int>();
                    new_all.Add(i);
                    Hash.Add(key, new_all);
                }
            }
            int category = Hash.Keys.Count;
            Console.WriteLine("Found " + category + " groups:");

            foreach (KeyValuePair<String, List<int>> it in Hash)
            {
                List<int> get = it.Value;
                Console.Write("- ");


                foreach (int v in get)
                {
                    if (v == get.Last())
                    {
                        Console.Write(words[v]);
                    }
                    else
                    {
                        Console.Write(words[v] + ", ");
                    }
                }
                Console.WriteLine();

            }


        }

        static void Main(string[] args)
        {

            //var fileContent = File.ReadAllText(/*args[0]*/);

            string[] lines = File.ReadAllLines(@"" + args[0] + "");
            //string[] lines = File.ReadAllLines(@"D:\Users\Hishamudin Ali\Desktop\words.txt");

            //String[] words = { "ton", "not", "ont",
            //"tno", "bin", "nib",
            //          "bni", "nbi"};

            int n = lines.Length;

            wordsWithSameCharSet(lines, n);
            Console.ReadKey();
        }

    }
}
