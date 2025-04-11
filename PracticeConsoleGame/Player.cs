namespace PracticeConsoleGame;

public class Player(Map map) : Entity(map)
{
    public void Move(int dx, int dy)
    {
        int x = Map.PlayerX;
        int y = Map.PlayerY;

        int newX = x + dx;
        int newY = y + dy;

        if (Map.GetTile(newX, newY))
        {
            return;
        }

        if (newX > Map.Width || newY > Map.Height || newX < 0 || newY < 0)
        {
            return;
        }

        Map.PlayerX = newX;
        Map.PlayerY = newY;
    }
}