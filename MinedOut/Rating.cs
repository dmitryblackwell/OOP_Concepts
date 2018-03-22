using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace OOP_Concepts.MinedOut
{
    class Rating
    {
        private const String SAVE_FILE = "rating.txt";
        public void save(String u,int s)
        {
            String d = DateTime.Today.ToString("dd/MM/yyyy");
            String t = DateTime.Now.ToString("h:mm:ss tt");
            String forSave = u + " " + s + " " + d + " " + t;
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
            for(int i = 0; i < rate.Length; ++i)
            {
                for(int j = 0; j<rate[0].Length; ++j)
                {
                    Console.Write(rate[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
