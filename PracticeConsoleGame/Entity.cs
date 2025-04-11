namespace PracticeConsoleGame;

public class Entity(Game game)
{
    public Game Game { get; } = game;

    public int X { get; set; }
    public int Y { get; set; }

    public virtual void Move()
    {
    }

    public void Move(int dx, int dy)
    {
        int newX = X + dx;
        int newY = Y + dy;

        if (Game.Map.GetTile(newX, newY))
        {
            return;
        }

        if (newX > Game.Map.Width || newY > Game.Map.Height || newX < 0 || newY < 0)
        {
            return;
        }

        Game.Map.Entities[X, Y] = null;
        Game.Map.Entities[newX, newY] = this;

        X = newX;
        Y = newY;
    }
}
