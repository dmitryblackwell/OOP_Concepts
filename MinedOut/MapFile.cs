using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace OOP_Concepts.MinedOut
{
    partial class Map
    {
        public class DataPack
        {
            public int _id;
            public int lifes;
            public int money;
            public String[] saveMap;
        }
        private const String SAVE_FILE = "saves.json";
        public void save()
        {
            List<DataPack> data = new List<DataPack>();
            String[] mapStr = new String[lengthY];
            for (int i = 0; i < lengthY; ++i)
            {
                mapStr[i] = "";
                for (int j = 0; j < lengthX; ++j)
                    mapStr[i] += map[i, j].getSymbol();
            }
            data.Add(new DataPack()
            {
                _id = 0,
                lifes = player.getLifes(),
                money = player.giveMeYourMoney(),
                saveMap = mapStr
            });
            //"Project" -> "Manage NuGet packages" -> "Search for "newtonsoft json". -> click "install".

            string json = JsonConvert.SerializeObject(data.ToArray());

            //write string to file
            System.IO.File.WriteAllText(SAVE_FILE, json);
        }
        public void load()
        {
            using (StreamReader r = new StreamReader(SAVE_FILE))
            {
                string json = r.ReadToEnd();
                List<DataPack> data = JsonConvert.DeserializeObject<List<DataPack>>(json);
                MapInit(data[0].saveMap);
                player.setLifes(data[0].lifes);
                player.setMoney(data[0].money);
            }
        }
    }
}