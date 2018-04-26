using System;
using System.Threading.Tasks;

namespace OOP_Concepts.BallGame
{
    class GamePlay
    {
        private String[] MapStr =
        {
            "##################",
            "#                #",
            "#   @            #",
            "#            @ ###",
            "#     /        . #",
            "#  @           ###",
            "#       @        #",
            "##################"
        };
        Map map;
        public GamePlay()
        {
            map = new Map(MapStr);
            Run();
        }
        private void Run()
        {
            bool isExit = false;
            while (map.isGameOn() && !isExit)
            {
                Console.Clear(); // все стираем
                map.draw();// Выводим нашу карту
                // Ждем пол секунды пока пользователь подвинет щит
                long StartTime = DateTime.Now.Millisecond;

                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                Task.Factory.StartNew(() => cki = Console.ReadKey())
                .Wait(TimeSpan.FromSeconds(1));
                switch (cki.Key)
                {
                    case ConsoleKey.LeftArrow:
                        map.moveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        map.moveRight();
                        break;
                    case ConsoleKey.UpArrow:
                        map.moveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        map.moveDown();
                        break;
                    case ConsoleKey.E:
                        isExit = true;
                        break;
                }

                map.BallStep(); // двигаем мячик
            }
        }
    }
}
