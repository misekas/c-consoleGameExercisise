using System;
using System.Threading;
using ConsoleGame;

public class GuiControler {

    private GameWindow gameWindow;
    private CreditWindow creditWindow;

    private GameController gameController;

    public GuiControler() {
        gameWindow = new GameWindow();
        creditWindow = new CreditWindow();
        gameController = new GameController(this);
    }

    public void ShowMenu() {
        gameWindow.Render();

        int keyCode;

        do {
            keyCode = Console.ReadKey().Key.GetHashCode();
        } while (keyCode != 37 && keyCode != 39 && keyCode != 13);


        if (keyCode == 37) {
            // ConsoleKey.LeftArrow
            if (gameWindow.GetCurrentMenuItemIndex() > 0) {
                gameWindow.SetMenuItemActine(gameWindow.GetCurrentMenuItemIndex() - 1);
            }

            ShowMenu();
        } else if (keyCode == 39) {
            // ConsoleKey.RightArrow
            if (gameWindow.GetCurrentMenuItemIndex() < gameWindow.menuItemCount - 1) {
                gameWindow.SetMenuItemActine(gameWindow.GetCurrentMenuItemIndex() + 1);
            }

            ShowMenu();
        } else if (keyCode == 13) {
            // ConsoleKey.Enter
            switch (gameWindow.GetCurrentMenuItemIndex()) {
                case 0:
                    gameController.StartGame();
                    break;
                case 1:
                    ShowCredits();
                    break;
                case 2:
                    // do nothing... application will exit.
                    break;
            }
        }
    }

    public void ShowCredits() {
        creditWindow.Render();

        int keyCode;

        do {
            keyCode = Console.ReadKey().Key.GetHashCode();
        } while (keyCode != 27 && keyCode != 13);

        ShowMenu();
    }
}