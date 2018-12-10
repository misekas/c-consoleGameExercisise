using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    class Window : GuiObject
    {
        private Frame border;

        public Window(int x, int height, int y, int width, char borderChar ) : base(x, height, y, width)
        {
            //this.x = x;
            //this.y = y;
            //this.height = height;
            //this.width = width;
            border = new Frame(x, height, y, width, borderChar);
        }
        public virtual void Render()
        {
            border.Render();
        }
    }
}
