using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace OOP_Concepts.MinedOut
{
    class Map
    {
        private Player player;
        private Cell[,] map;
        private int lengthX, lengthY;
        public bool getPlayersAlive() { return player.getLifes() > 0; }

        private void movePlayer(int whereTo) { player.movePlayer(ref map, whereTo); }
        public void movePlayerLeft() { movePlayer((int)Player.Move.Left); }
        public void movePlayerRight() { movePlayer((int)Player.Move.Right); }
        public void movePlayerUp() { movePlayer((int)Player.Move.Up); }
        public void movePlayerDown() { movePlayer((int)Player.Move.Down); }
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
            data.Add(new DataPack() {
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
        private void MapInit(String[] MapStart)
        {
            lengthX = MapStart[0].Length;
            lengthY = MapStart.Length;
            map = new Cell[lengthY,lengthX];
            player = new Player();

            for (int i = 0; i < lengthY; ++i)
                for (int j = 0; j < lengthX; ++j)
                {
                    map[i, j] = new Cell(MapStart[i][j]);
                    if (map[i, j].isThisPlayer())
                        player = new Player(j, i);
                }
        }

        public Map(String[] map) {
            MapInit(map);
            fillRandom();
        }
        private void fillRandom()
        {

        }
        public void drawMap()
        {
            // TODO SetCursorPosition 
            for (int i = 0; i < lengthY; ++i)
            {
                for (int j = 0; j < lengthX; ++j)
                {
                    if (map[i, j].isThisPlayer())
                        Console.Write(player.getBombsAroundPlayer(map));
                    else
                        map[i, j].print();
                }
                Console.Write("\n");
            }

            Console.WriteLine("\n");
            Console.WriteLine("Lifes: " + player.getLifes());
            Console.WriteLine("Money: " + player.giveMeYourMoney());
        }
    }
}
