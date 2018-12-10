using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaidimas.Units;

namespace zaidimas.Screen
{
    class GameScreen
    {
        private int width;
        private int height;

        private Hero hero;
        private List<Enemy> enemies = new List<Enemy>();

        public GameScreen(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void SetHero(Hero hero)
        {
            this.hero = hero;
        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void Render()
        {
            hero.PrintInfo();
            foreach (Enemy enemy in enemies)
            {
                enemy.PrintInfo();
            }
        }

        public Hero GetHero()
        {
            return hero;
        }

        public void MoveAllEnemiesDown()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveDown();
            }
        }

        public Enemy getEnemyById(int id)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.GetId() == id)
                {
                    return enemy;
                }
            }

            return null;
        }
    }
}
