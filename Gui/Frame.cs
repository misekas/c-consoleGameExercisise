using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    class Frame : GuiObject
    {
        private char renderChar;

        public Frame(int x, int height, int y, int width, char renderChar) : base(x, height, y, width)
        {
            this.renderChar = renderChar;
        }
        public void Render()
        {
            Console.SetCursorPosition(x, y);
            for (int j = 0; j < width; j++)
            {   
                Console.Write($"{renderChar}");
            }
            Console.WriteLine(" ");
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(x, y+1 +i);
                Console.Write($"{renderChar}");
                for (int k = 0; k <= width - 3; k++)
                {
                    Console.Write($" ");
                }
                Console.Write($"{renderChar}");
                Console.WriteLine(" ");
            }
            Console.SetCursorPosition(x, y+1+height);
            for (int l = 0; l < width; l++)
            {
                Console.Write($"{renderChar}");
            }          
        }
    }
}
