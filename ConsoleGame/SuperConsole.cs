using System;

public class SuperConsole {

    public static void WriteAt(int x, int y, string str) {
        Console.SetCursorPosition(x, y);
        Console.Write(str);
    }

    public static void ResetCursor() {
        Console.SetCursorPosition(0, 0);
    }
}