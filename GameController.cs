using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaidimas.Screen;
using zaidimas.Units;

namespace zaidimas
{
    class GameController
    {
        void StartGame()
        {
            bool needToRender = true;
            GameScreen myGame = new GameScreen(30, 20);

            myGame.SetHero(new Hero("HERO", 5, 5));

            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++)
            {
                myGame.AddEnemy(new Enemy("enemy" + enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), enemyCount));
                enemyCount++;
            }

            myGame.Render();

            myGame.GetHero().MoveLeft();
            myGame.MoveAllEnemiesDown();
            Enemy secondEnemy = myGame.getEnemyById(1);
            if (secondEnemy != null)
            {
                secondEnemy.MoveDown();
            }
            do
            {
                Console.Clear();

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    switch (pressedChar.Key)
                    {
                        case ConsoleKey.Escape:
                            break;
                        case ConsoleKey.RightArrow:
                            myGame.GetHero().MoveRight();
                            break;
                        case ConsoleKey.LeftArrow:
                            myGame.GetHero().MoveLeft();
                            break;
                    }
                }

                myGame.Render();

                System.Threading.Thread.Sleep(250);
            } while (needToRender);
        }
    }
}
