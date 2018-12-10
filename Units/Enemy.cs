using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaidimas.Units
{
    class Enemy : Unit
    {
        private int id;
        public Enemy(string name, int x, int y, int id) : base(name, x, y)
        {
            this.id = id;
        }
        public void MoveDown()
        {
            y--;
        }
        public int GetId()
        {
            return id;
        }
    }
}
