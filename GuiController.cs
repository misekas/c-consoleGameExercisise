using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaidimas.Gui;

namespace zaidimas
{
    class GuiController
    {
        private GameWindow gameWindow;
        private CreditWindow creditWindow;
        private GameController gameController;

        public GuiController()
        {
            gameWindow = new GameWindow();
            creditWindow = new CreditWindow();
            gameController = new GameController();

            //Frame testWindow = new Frame(0, 20, 0, 40, '.');
            //testWindow.Render();
        }
        public void ShowMenu()
        {
            //gameWindow.startButton.SetActive();
            gameWindow.Render();

            int pressedButton2;
            
            
                do
                {
                    ConsoleKeyInfo pressedButton = Console.ReadKey(true);
                    pressedButton2 = pressedButton.Key.GetHashCode();
                    //Console.WriteLine(pressedButton.KeyChar);
                } while (pressedButton2 != 39 && pressedButton2 != 37 && pressedButton2 != 13);

                if (pressedButton2 == 39)
                {
                if (true)
                {

                }
                    gameWindow.creditsButton.SetActive();
                    gameWindow.startButton.SetInActive();
                    gameWindow.Render();
                   
                    Console.WriteLine("->");
                    ShowMenu();
                }
                else if (pressedButton2 == 37)
                {
                   
                    Console.WriteLine("<-");
                    ShowMenu();
                }
                else if (pressedButton2 == 13)
                {

                }
         

            Console.SetCursorPosition(0, 0);
        }
    }
}
