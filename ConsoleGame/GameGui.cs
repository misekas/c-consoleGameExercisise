using System;
using System.Collections.Generic;
using System.Transactions;

sealed class GameWindow : Window {

    private List<Button> menuButtons = new List<Button>();

    private TextBlock titleTextBlock;

    private int currentMenuItemActive;

    public readonly int menuItemCount;


    public GameWindow() : base(0, 0, 120, 30, '%') {
        titleTextBlock = new TextBlock(10, 5, 100, new List<String> {"Super duper zaidimas", "Vardas Pavardaitis kuryba!", "Made in Vilnius Coding School!"});

        menuButtons.Add(new Button(20, 13, 18, 5, "Start"));
        menuButtons.Add(new Button(50, 13, 18, 5, "Credits"));
        menuButtons.Add(new Button(80, 13, 18, 5, "Quit"));

        menuItemCount = menuButtons.Count;

        currentMenuItemActive = 0;
        menuButtons[0].SetActive();
    }

    public int GetCurrentMenuItemIndex() {
        return currentMenuItemActive;
    }

    public override void Render() {
        Console.ForegroundColor = ConsoleColor.Black;

        base.Render();

        titleTextBlock.Render();

        for (int i = 0; i < menuButtons.Count; i++) {
            menuButtons[i].Render();
        }

        Console.SetCursorPosition(0, 0);
    }

    public void SetMenuItemActine(int activeIndex) {
        menuButtons[currentMenuItemActive].SetInactive();
        currentMenuItemActive = activeIndex;
        menuButtons[currentMenuItemActive].SetActive();
    }
}

sealed class CreditWindow : Window {

    private Button backButton;

    private TextBlock creditTextBlock;

    public CreditWindow() : base(28, 10, 60, 18, '@') {
        List<String> creditData = new List<string>();

        creditData.Add("");
        creditData.Add("Game design:");
        creditData.Add("Vardas Vardaitis");
        creditData.Add("");
        creditData.Add("Programuotojas:");
        creditData.Add("Vardas Vardaitis");
        creditData.Add("");
        creditData.Add("\'Art\':");
        creditData.Add("Vardas Vardaitis");
        creditData.Add("");
        creditData.Add("Marketingas:");
        creditData.Add("Vardas Vardaitis");
        creditData.Add("");

        creditTextBlock = new TextBlock(28 + 1, 10 + 1, 60 - 1, creditData);


        backButton = new Button(28 + 20, 10 + 14, 18, 3, "Back");
        backButton.SetActive();
    }

    public override void Render() {
        Console.ForegroundColor = ConsoleColor.Black;
        
        base.Render();
        creditTextBlock.Render();
        backButton.Render();

        Console.SetCursorPosition(0, 0);
    }

}

sealed class GameOverWindow : Window {

    private Button backButton;

    private TextBlock creditTextBlock;

    public GameOverWindow() : base(28, 10, 60, 18, '@') {
        List<String> creditData = new List<string>();

        creditData.Add("");
        creditData.Add("GAME OVER!");
        creditData.Add("");
        creditData.Add("Better luck next time!");

        creditTextBlock = new TextBlock(28 + 1, 10 + 1, 60 - 1, creditData);


        backButton = new Button(28 + 20, 10 + 14, 18, 3, "Back");
        backButton.SetActive();
    }

    public override void Render() {
        Console.ForegroundColor = ConsoleColor.Black;
        
        base.Render();
        creditTextBlock.Render();
        backButton.Render();

        Console.SetCursorPosition(0, 0);
    }

}


class Window : GuiObject {

    private Frame border;

    public Window(int x, int y, int width, int height, char borderChar) : base(x, y, width, height) {
        _x = x;
        _y = y;
        _width = width;
        _height = height;

        border = new Frame(x, y, width, height, borderChar);
    }

    public override void Render() {
        border.Render();
    }
}


class Button : GuiObject {

    private Frame notActiveFrame;
    private Frame activeFrame;

    private bool isActive = false;
    private TextLine textLine;

    public Button(int x, int y, int width, int height, string buttonText) : base(x, y, width, height) {
        notActiveFrame = new Frame(x, y, width, height, '+');
        activeFrame = new Frame(x, y, width, height, '#');

        textLine = new TextLine(x + 1, y + 1 + ((height - 2) / 2), width - 2, buttonText);
    }

    public override void Render() {
        if (isActive) {
            activeFrame.Render();
        } else {
            notActiveFrame.Render();
        }

        textLine.Render();
    }

    public void SetActive() {
        isActive = true;
    }

    public void SetInactive() {
        isActive = false;
    }
}


sealed class TextBlock : GuiObject {
    private List<TextLine> textBlocks = new List<TextLine>();

    public TextBlock(int x, int y, int width, List<string> textList) : base(x, y, width, 0) {
        for (int i = 0; i < textList.Count; i++) {
            textBlocks.Add(new TextLine(x, y + i, width, textList[i]));
        }
    }

    public override void Render() {
        for (int i = 0; i < textBlocks.Count; i++) {
            textBlocks[i].Render();
        }
    }
}


class TextLine : GuiObject {
    private string _data;

    public TextLine(int x, int y, int width, string data) : base(x, y, width, 0) {
        _data = data;
    }

    public override void Render() {
        Console.SetCursorPosition(_x, _y);
        if (_width > _data.Length) {
            int offset = (_width - _data.Length) / 2;
            for (int i = 0; i < offset; i++) {
                Console.Write(' ');
            }
        }

        Console.Write(_data);
    }

}

class Frame : GuiObject {
    private char _renderChar;

    public Frame(int x, int y, int width, int height, char renderChar) : base(x, y, width, height) {
        _renderChar = renderChar;
    }


    public override void Render() {
        for (int i = 0; i < _height; i++) {
            Console.SetCursorPosition(_x, _y + i);
            if (i == 0 || i == _height - 1) {
                for (int j = 0; j < _width; j++) {
                    Console.Write(_renderChar);
                }
            } else {
                Console.Write(_renderChar);
                for (int j = 0; j < _width - 2; j++) {
                    Console.Write(' ');
                }

                Console.Write(_renderChar);
            }
        }
    }
}

abstract class GuiObject {
    protected int _x;
    protected int _y;
    protected int _width;
    protected int _height;

    public GuiObject(int x, int y, int width, int height) {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }

    public abstract void Render();

}