using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaidimas.Gui;
using zaidimas.Screen;
using zaidimas.Units;

namespace zaidimas
{
    class Program
    {
        static void Main()
        {
            GuiController guiControler = new GuiController();
            guiControler.ShowMenu();
            Console.ReadKey();
        }
    }
}
