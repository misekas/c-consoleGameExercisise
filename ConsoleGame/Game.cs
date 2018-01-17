using System;
using System.Collections.Generic;

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

    private CellState[,] gameField;

    private Frame frame;

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
        hero.AutoMove();

        bool isDead = false;

        if (gameField[hero.x, hero.y] == CellState.DEAD) {
            isDead = true;
        }

        return isDead;
    }

    public void SetDirection(Direction right) {
        throw new NotImplementedException();
    }

    public void SetHeroDirection(Direction dir) {
        hero.SetDirection(dir);
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

    Queue<BodyPart> body = new Queue<BodyPart>();

    private Direction direction = Direction.RIGHT;

    public Hero(int x, int y, string name) : base(x, y, name) {
        //init snake
        for (int i = 0; i < 5; i++) {
            body.Enqueue(new BodyPart(x, y));
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
        BodyPart head = body.Dequeue();
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
        body.Enqueue(head);
    }


    public void SetDirection(Direction dir) {
        direction = dir;
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