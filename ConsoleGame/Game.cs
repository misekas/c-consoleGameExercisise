using System;
using System.Collections.Generic;
using System.Linq;

enum Direction {
    LEFT,
    RIGHT,
    UP,
    DOWN
}

enum CellState {
    EMPTY = 0,
    HERO = 1,
    COLLECTABLE = 2,
    DEAD = 9
}

class GameScreen {
    private int width;
    private int height;

    private Hero hero;
    private List<Enemy> enemies = new List<Enemy>();

    private List<Collectable> collectables = new List<Collectable>();

    private CellState[,] gameField;

    private Frame frame;

    private int collectableCount = 0;
    private Random rnd = new Random();

    public GameScreen(int width, int height) {
        this.width = width;
        this.height = height;

        frame = new Frame(0, 0, width, height, '#');

        gameField = new CellState[width, height];
        for (int i = 0; i < width; i++) {
            gameField[i, 0] = CellState.DEAD;
            gameField[i, height - 1] = CellState.DEAD;
        }

        for (int i = 0; i < height; i++) {
            gameField[0, i] = CellState.DEAD;
            gameField[width - 1, i] = CellState.DEAD;
        }
    }

    public void SetHero(Hero hero) {
        this.hero = hero;
    }

    public void AddEnemy(Enemy enemy) {
        enemies.Add(enemy);
    }

    public void Render() {
        Console.ForegroundColor = ConsoleColor.Blue;
        frame.Render();


        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int c = 0; c < collectables.Count; c++) {
            collectables[c].Render();
        }

        hero.Render();


        SuperConsole.ResetCursor();
        //foreach (Enemy enemy in enemies) {
        //    enemy.Render();
        //}
    }

    public Hero GetHero() {
        return hero;
    }

    public void MoveAllEnemiesDown() {
        foreach (Enemy enemy in enemies) {
            enemy.MoveDown();
        }
    }

    public Enemy getEnemyById(int id) {
        foreach (Enemy enemy in enemies) {
            if (enemy.GetId() == id) {
                return enemy;
            }
        }

        return null;
    }

    public bool DoStep() {
        BodyPart oldTail = hero.GetTail();
        hero.AutoMove();

        if (gameField[hero.x, hero.y] == CellState.COLLECTABLE) {
            RemoveCollectable(hero.x, hero.y);
            hero.AddTail(2);
            SpawnCollectables(2);
        }

        gameField[hero.x, hero.y] = CellState.HERO;

        BodyPart newTail = hero.GetTail();
        if (oldTail.x != newTail.x || oldTail.y != newTail.y) {
            gameField[oldTail.x, oldTail.y] = CellState.EMPTY;
        }

        bool isDead = false;

        if (gameField[hero.x, hero.y] == CellState.DEAD || gameField[hero.x, hero.y] == CellState.HERO) {
            isDead = true;
        }

        return isDead;
    }

    public void SpawnCollectables(int count) {
        for (int i = 0; i < count; i++) {
            AddCollectable(new Collectable(collectableCount, rnd.Next(1, GetWidth() - 1), rnd.Next(1, GetHeight()), "$"));
            collectableCount++;
        }
    }

    private void RemoveCollectable(int x, int y) {
        for (int i = 0; i < collectables.Count; i++) {
            Collectable collectable = collectables[i];
            if (collectable.x == x && collectable.y == y) {
                collectables.Remove(collectable);
                break;
            }
        }
    }

    public void SetDirection(Direction right) {
        throw new NotImplementedException();
    }

    public void SetHeroDirection(Direction dir) {
        hero.SetDirection(dir);
    }

    public int GetWidth() {
        return width;
    }

    public int GetHeight() {
        return height;
    }

    public void AddCollectable(Collectable collectable) {
        collectables.Add(collectable);
        if (gameField[collectable.x, collectable.y] == CellState.EMPTY) {
            gameField[collectable.x, collectable.y] = CellState.COLLECTABLE;
        }
    }
}


class Unit {

    public int x;
    public int y;
    protected string name;

    public Unit(int x, int y, string name) {
        this.x = x;
        this.y = y;
        this.name = name;
    }

    public void PrintInfo() {
        Console.WriteLine($" Unit {name} is at {x}x{y}");
    }
}

class Hero : Unit {

    private List<BodyPart> body = new List<BodyPart>();

    private Direction direction = Direction.RIGHT;

    public Hero(int x, int y, string name) : base(x, y, name) {
        //init snake
        for (int i = 0; i < 5; i++) {
            body.Add(new BodyPart(x, y));
        }
    }

    public void MoveRight() {
        x++;
    }

    public void MoveLeft() {
        x--;
    }

    private void MoveDown() {
        y++;
    }

    private void MoveUp() {
        y--;
    }

    public void Render() {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (BodyPart bodyPart in body) {
            SuperConsole.WriteAt(bodyPart.x, bodyPart.y, name);
        }
    }

    public void AutoMove() {
        BodyPart head = body[0];
        body.RemoveAt(0);
        switch (direction) {
            case Direction.LEFT:
                MoveLeft();
                break;
            case Direction.RIGHT:
                MoveRight();
                break;
            case Direction.UP:
                MoveUp();
                break;
            case Direction.DOWN:
                MoveDown();
                break;
        }

        head.x = x;
        head.y = y;

        body.Add(head);
    }


    public void SetDirection(Direction dir) {
        direction = dir;
    }

    public void AddTail(int bodyPartCount) {
        BodyPart last = body[0];

        for (int j = 0; j < bodyPartCount; j++) {
            body.Insert(0, new BodyPart(last.x, last.y));
        }
    }

    public BodyPart GetTail() {
        return body[0];
    }
}

class BodyPart {

    public int x;
    public int y;

    public BodyPart(int x, int y) {
        this.x = x;
        this.y = y;
    }

}


class Enemy : Unit {

    private int id;

    public Enemy(int id, int x, int y, string name) : base(x, y, name) {
        this.id = id;
    }

    public void MoveDown() {
        y++;
    }

    public int GetId() {
        return id;
    }

    public void Render() {
        SuperConsole.WriteAt(x, y, name);
    }
}

class Collectable : Unit {

    private int id;

    public Collectable(int id, int x, int y, string name) : base(x, y, name) {
        this.id = id;
    }

    public int GetId() {
        return id;
    }

    public void Render() {
        SuperConsole.WriteAt(x, y, name);
    }
}