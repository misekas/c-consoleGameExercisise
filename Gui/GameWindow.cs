using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Gui
{
    class GameWindow : Window
    {
        public Button creditsButton { get; set; }
        public Button quitButton { get; set; }
        public Button startButton { get; set; }

        private TextBlock titleTextBlock;

        public GameWindow() : base(0,40,0,100,'.')
        {
            startButton = new Button(20, 3, 25, 15, "Start");
            creditsButton = new Button(40, 3, 25, 15, "Credits");
            quitButton = new Button(60, 3, 25, 15, "Quit");
            titleTextBlock = new TextBlock(40, 10, 15, new List<String> { "Zaidimas!" });


        }
        public override void Render()
        {
            base.Render();
            startButton.Render();
            creditsButton.Render();
            quitButton.Render();
            titleTextBlock.Render();
        }
    }
}
