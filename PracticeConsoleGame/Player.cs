namespace PracticeConsoleGame;

public class Player(Map map) : Entity(map)
{
    public void Move(int dx, int dy)
    {
        int newX = X + dx;
        int newY = Y + dy;

        if (Map.GetTile(newX, newY))
        {
            return;
        }

        if (newX > Map.Width || newY > Map.Height || newX < 0 || newY < 0)
        {
            return;
        }

        Map.Entities[X, Y] = null;
        Map.Entities[newX, newY] = this;

        X = newX;
        Y = newY;
    }
}