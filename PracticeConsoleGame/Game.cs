namespace PracticeConsoleGame;

public class Game
{
    private Map map;
    private MapRenderer renderer;

    public Game(EventLoop loop, Map map)
    {
        this.map = map;
        renderer = new(map);
        renderer.Redraw();

        loop.LeftKeyPress += () => Move(-1, 0);
        loop.RightKeyPress += () => Move(1, 0);
        loop.UpKeyPress += () => Move(0, -1);
        loop.DownKeyPress += () => Move(0, 1);
    }

    private void Move(int dx, int dy)
    {
        int x = map.PlayerX;
        int y = map.PlayerY;

        int newX = x + dx;
        int newY = y + dy;
    
        if (map.GetTile(newX, newY))
        {
            return;
        }

        if (newX > map.Width || newY > map.Height)
        {
            return;
        }

        map.PlayerX = newX;
        map.PlayerY = newY;

        renderer.Redraw();
    }
}
