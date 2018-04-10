using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace OOP_Concepts.MinedOut
{
    class Rating
    {
        // money *2 + lifes*5 + 240/time in seconds
        private const String SAVE_FILE = "rating.txt";
        public void save(String u,int time, int m,int l)
        {
            String d = DateTime.Today.ToString("dd/MM/yyyy");
            String t = DateTime.Now.ToString("h:mm:ss tt");
            int totalScore = (480 / time) + m * 2 + l * 5;
            String forSave = u + " " + totalScore; //+ " " + d + " " + t;
            File.AppendAllText(SAVE_FILE, forSave+Environment.NewLine);
        }
        public String[][] load()
        {
            String[] lines = File.ReadAllLines(SAVE_FILE);
            String[][] result = new String[lines.Length][];
            for(int i =0;i<lines.Length; ++i)
            {
                result[i] = lines[i].Split(new char[0]);
            }
            return result;
        }

        public void print()
        {
            String[][] rate = load();
            String valueTmp = "";
            int keyTmp = 0;

            for (int write = 0; write < rate.Length; write++)
            {
                for (int sort = 0; sort < rate.Length - 1; sort++)
                {
                    int t1 = Convert.ToInt32(rate[sort][1]);
                    int t2 = Convert.ToInt32(rate[sort+1][1]);
                    if (  t1 < t2)
                    {
                        valueTmp = rate[sort + 1][0];
                        keyTmp = t2;

                        rate[sort + 1][0] = rate[sort][0];
                        rate[sort + 1][1] = rate[sort][1];

                        rate[sort][0] = valueTmp;
                        rate[sort][1] = keyTmp.ToString();
                    }
                }
            }
            for (int i = 0; i < rate.Length; ++i)
            {
                for (int j = 0; j < rate[0].Length; ++j)
                {
                    Console.Write(rate[i][j] + " ");
                }
                Console.WriteLine();
            }
            
            /*
            Dictionary<String, int> dic = new Dictionary<string, int>();
            for (int i=0; i<rate.Length; ++i)
            {
                try
                {
                    dic.Add(rate[i][0], Convert.ToInt32(rate[i][1]));
                } catch (System.ArgumentException e) { }
            }
            var list = dic.Keys;
            var l = dic.OrderBy(key => key.Key);
            var sorted = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);

            foreach (var item in sorted)
            {

                Console.WriteLine(item.Key + " - "+item.Value);
            }
            /*foreach (var item in dic.OrderBy(i => i.Key))
                Console.WriteLine(item);
            /*
            list.Sort();
            foreach (var key in list)
            {
                Console.WriteLine("{0}: {1}", key, dictionary[key]);
            }

            for (int i = 0; i < rate.Length; ++i)
            {
                for(int j = 0; j<rate[0].Length; ++j)
                {
                    Console.Write(rate[i][j]+" ");
                }
                Console.WriteLine();
            }*/
        }
    }
}
