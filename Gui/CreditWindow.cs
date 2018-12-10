using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    class CreditWindow : Window
    {
        private Button backButton;
        private TextBlock creditTextBlock;

        public CreditWindow() : base(0, 40, 0, 100, '.')
        {
            backButton = new Button(40, 3, 10, 15, "Back");
        }
        public override void Render()
        {
            base.Render();
            backButton.Render();
        }
    }
}
