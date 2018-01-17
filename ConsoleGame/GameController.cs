using System;


namespace ConsoleGame {
    public class GameController {

        private GuiControler _guiControler;

        private GameOverWindow gameOverWindow;

        public GameController(GuiControler guiControler) {
            _guiControler = guiControler;
            gameOverWindow = new GameOverWindow();
        }

        public void StartGame() {
            // init game
            GameScreen myGame = new GameScreen(120, 30);


            // fill game with game data.
            myGame.SetHero(new Hero(5, 5, "@"));

            Random rnd = new Random();
            int enemyCount = 0;
            for (int i = 0; i < 10; i++) {
                myGame.AddEnemy(new Enemy(enemyCount, rnd.Next(0, 10), rnd.Next(0, 10), "" + enemyCount));
                enemyCount++;
            }

            // render loop
            bool needToRender = true;

            do {
                // isvalom ekrana
                Console.Clear();

                while (Console.KeyAvailable) {
                    ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                    int hashCode = pressedChar.Key.GetHashCode();

                    switch (hashCode) {
                        case 27: //ConsoleKey.Escape:
                            needToRender = false;
                            break;
                        case 39: // ConsoleKey.RightArrow:
                            myGame.SetHeroDirection(Direction.RIGHT);
                            break;
                        case 37: // ConsoleKey.LeftArrow:
                            myGame.SetHeroDirection(Direction.LEFT);
                            break;
                        case 38: //ConsoleKey.UpArrow:
                            myGame.SetHeroDirection(Direction.UP);
                            break;
                        case 40: //ConsoleKey.DownArrow:
                            myGame.SetHeroDirection(Direction.DOWN);
                            break;
                    }
                }

                bool isDead = myGame.DoStep();

                myGame.Render();

                if (isDead) {
                    needToRender = false;
                    gameOverWindow.Render();
                }


                System.Threading.Thread.Sleep(250);
            } while (needToRender);

            Console.ReadKey();

            _guiControler.ShowMenu();
        }
    }
}