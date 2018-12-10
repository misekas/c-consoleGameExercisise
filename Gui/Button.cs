using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    class Button 
    {
        private Frame activeFrame;
        public bool isActive { get; set; } = false;
        private Frame notActiveFrame;
        private TextLine textLine;

        public Button(int x, int height, int y, int width, string buttonText) 
        {
            activeFrame = new Frame(x, height, y, width, '*');
            notActiveFrame = new Frame(x, height, y, width, '+');
            textLine = new TextLine(x + 1, y + 1 + (height - 2), width - 2, buttonText);
        }
        public void Render() 
        {
            if (isActive)
            {
                activeFrame.Render();
            }
            else
            {
                notActiveFrame.Render();
            }

            textLine.Render();
        }
        public void SetActive()
        {
            isActive = true;
        }
        public void SetInActive()
        {
            isActive = false;
        }
    }
}
