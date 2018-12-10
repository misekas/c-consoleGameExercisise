using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    public class GuiObject
    {
        protected int height;
        protected int width;
        protected int x;
        protected int y;

        public GuiObject(int x, int height, int y, int width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }
    }
}
